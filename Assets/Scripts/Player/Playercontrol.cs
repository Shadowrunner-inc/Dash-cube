using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playercontrol : MonoBehaviour {
	public string mouseAxisX = "Mouse X_P1";
	public string mouseAxisY = "Mouse Y_P1";

	public float aimDistance = 4f;// Distance the player can hook to

	//rigidboday for player
	public Rigidbody2D rigi;
	
	public SpriteRenderer sprite;

	public BoxCollider2D my_collider;
    
	//bullet object that player will shoot
	public Transform crosshair;
	public Transform gunPlacement;

    [SerializeField] GameObject lasersightPrefab;
    LineRenderer laserSight;
	
	[SerializeField]GrappingHook Hooking;

    
	// Use this for initialization
	void Start () {
		
		rigi = GetComponent<Rigidbody2D> ();
        GameObject pLaserSight = (GameObject)Instantiate(lasersightPrefab, Vector3.zero, Quaternion.identity);
        laserSight = pLaserSight.GetComponent<LineRenderer>();
        Hooking = GetComponent<GrappingHook>();
    }

    private void OnEnable() { if (laserSight) { laserSight.enabled = true; } }
    private void OnDisable() { if (laserSight) { laserSight.enabled = false; } }

    void FixedUpdate () {  Aim(); }
		

	void Aim(){
		
		///Mouse control
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 newPos = new Vector3 (mousePosition.x, mousePosition.y, 0.0f);
        crosshair.position = transform.position + aimDistance * Vector3.Normalize(newPos - transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, crosshair.position - transform.position, aimDistance);

		if (hit && hit.collider.name != gameObject.name) // Don't hit yourself stupid!!
        {
            laserSight.SetPosition(0, transform.position);
            laserSight.SetPosition(1, new Vector3(hit.point.x,hit.point.y,0f));
            laserSight.endColor = new Color(255f,0f,0f,255f);
        }
        else {
            laserSight.SetPosition(0, transform.position);
            laserSight.SetPosition(1, crosshair.position);
            laserSight.endColor = new Color(255f, 0f, 0f, 0f);
        }
       
        gunPlacement.position = transform.position + 0.6f * Vector3.Normalize (newPos - transform.position);
	}

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.parent.GetComponent<RailSystemAI>() != null) {
            gameObject.transform.parent = other.transform;
        }    
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        if (transform.parent != null) {
            if (other.transform.parent.GetComponent<RailSystemAI>() != null)
            {
                gameObject.transform.parent = null;
            }
        }
    }

}
