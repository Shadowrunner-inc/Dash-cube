//Author: Nate hales
//Signals the activation of the pause menu
using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
	public GameObject pauseM; // declare needed menus here.


void Update () {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				print ("paused.");
				pauseM.SetActive (true);
				Time.timeScale = 0.0f;
			}
	
	}
}
