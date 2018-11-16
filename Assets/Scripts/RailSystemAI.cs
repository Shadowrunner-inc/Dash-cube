using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSystemAI : MonoBehaviour {
	public Transform movingPlatform;
	public Transform endPosition, startPosition;
	public float speed;

	float lerpPosition = 0f;
	bool direction;
   


    // Use this for initialization
    void Start()
    {
		if(startPosition == null || endPosition == null){enabled = false;}

    }

    // Update is called once per frame
    void Update()
	{
		if (direction) {
			if (lerpPosition <= 1.0f) {
				lerpPosition += speed * Time.deltaTime;
			} else {
				direction = !direction;
			}
		} else {
			if (lerpPosition >= 0f) {
				lerpPosition -= speed * Time.deltaTime;
			} else {
				direction = !direction;
			}
		}
		movingPlatform.position = Vector3.Lerp(startPosition.position, endPosition.position, lerpPosition);
    }


}
