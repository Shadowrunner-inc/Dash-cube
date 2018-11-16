//Author: Nate hales
//Trigger logic to signal the loading of the victory scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictroyBox : MonoBehaviour {


	void OnTriggerEnter(Collider ob){
		if (ob.CompareTag ("Player")) {
			SceneManager.LoadScene ("Win Scene");
		}
	}
}
