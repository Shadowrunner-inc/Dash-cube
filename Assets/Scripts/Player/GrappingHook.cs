using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// TODO: Rebuild this so it hooks to the nearest thing in the direction the player clicked.
/// </summary>

public class GrappingHook : MonoBehaviour {

    DistanceJoint2D joint;
	HingeJoint2D chain;
    Vector3 targetPos;
    RaycastHit2D hit;
	

	bool hooked = false;

     LineRenderer HookLine;
	public GameObject hookPrefab;

    float Hookdistance = 10f;
    public float m_cantpullDistance=2f;
    public LayerMask mask;
    public float Speed = 0.2f;

	public string hookButton = "Fire1";
	public string unhookButton = "Fire2";

    Transform crossHair;
	string verticalCtrl;

    public int MoveNum = 3; //Number of time the player can hook on
    public float hookTime = 3f; // amount of time the player can remain suspened.

    public float timeKeeper; //Used as a timer.


	//bool m_hooking = false;
     
    // Use this for initialization
    void Start () {
        GameObject pHook = (GameObject)Instantiate(hookPrefab, Vector3.zero, Quaternion.identity);

        HookLine = pHook.GetComponent<LineRenderer>(); //
        HookLine.enabled = false;
		
        ///without incontrol.
        crossHair = GetComponent<Playercontrol>().crosshair;
        Hookdistance = GetComponent<Playercontrol>().aimDistance;

        joint = GetComponent<DistanceJoint2D> ();  
        joint.enabled = false;

       
        timeKeeper = hookTime; //Set the Timer.
	}


	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetButtonDown(hookButton) && MoveNum > 0) {
            print("Clicked");
          
			targetPos = crossHair.position;
            
			hit = Physics2D.Raycast (transform.position, targetPos - transform.position, Mathf.Infinity, mask);
            
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D> () != null && hit.collider.tag == "Evo") {
                MoveNum--; //Decrement the number of moves left.
				timeKeeper = hookTime; //Rest the timer

                print("Attached to" + hit.collider.name);
				joint.enabled = true;

                joint.connectedAnchor = new Vector2 ((hit.point.x - hit.collider.transform.position.x) / hit.collider.transform.localScale.x,
					(hit.point.y - hit.collider.transform.position.y) / hit.collider.transform.localScale.y);

                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D> ();
				joint.distance = Vector2.Distance (transform.position, hit.point);
                
                hooked = true;

                HookLine.enabled = true;
				HookLine.SetPosition (0, transform.position);
				HookLine.SetPosition (1, hit.point);
					}
			}

        if (hooked)
        {
            
            HookLine.enabled = true;
            HookLine.SetPosition(0, transform.position);

            RaycastHit2D cantPull = Physics2D.Raycast(transform.position, targetPos - transform.position, m_cantpullDistance, mask);

            if (joint.distance > 0.5f && !cantPull) { joint.distance -= Speed; }


            timeKeeper -= Time.deltaTime;//Tick down using time
			if (timeKeeper <= 0f || Input.GetButtonDown(unhookButton)) { UnHook(); }

        }

      
    }

	public void UnHook(){
		joint.enabled = false;
		HookLine.enabled = false;
		hooked = false;
        timeKeeper = hookTime; //Rest the timer
	}


}
