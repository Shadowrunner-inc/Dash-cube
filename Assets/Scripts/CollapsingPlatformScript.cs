using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatformScript : MonoBehaviour {

    public Transform movingPlatform;
    public Transform endPosition, startPosition;
    public float speed;

    float lerpPosition = 0f;
    bool bIsFalling, direction;
    
    // Use this for initialization
    void Start() {
        if (startPosition == null || endPosition == null) { enabled = false; }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        print("DOn't stand HERE!");
        if (other.gameObject.CompareTag("Player")) bIsFalling = true; //Start falling
    }

    // Update is called once per frame
    void Update(){
        if (bIsFalling)
        {
            if (direction)
            {
                if (lerpPosition <= 1.0f)
                {
                    lerpPosition += speed * Time.deltaTime;
                }
                else
                {
                    direction = !direction;
                }
            }
            else
            {
                if (lerpPosition >= 0f)
                {
                    lerpPosition -= speed * Time.deltaTime;
                }
                else
                {
                    direction = !direction;
                }
            }

            movingPlatform.position = Vector3.Lerp(startPosition.position, endPosition.position, lerpPosition);
            if (movingPlatform.position == endPosition.position)
            {
                bIsFalling = false;
                gameObject.AddComponent<Rigidbody2D>();
            }
        }

    }



}
