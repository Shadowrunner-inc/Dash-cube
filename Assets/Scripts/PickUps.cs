//Author: Nate Hales
//Simple Trigger for pick ups
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {

	public int hookValue = 3;

	void OnTriggerEnter2D(Collider2D ob){
	
		if(ob.CompareTag ("Player")){
			ob.GetComponent <GrappingHook>().MoveNum += hookValue;
			Destroy (gameObject);
		}
	}
}
