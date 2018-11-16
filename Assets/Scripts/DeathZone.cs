using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D victim){
        if (victim.CompareTag("Player"))
            //print ("yo");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
