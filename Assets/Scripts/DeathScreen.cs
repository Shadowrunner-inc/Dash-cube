//Author: Nate Hales
//Simple Dath screen code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {


	void OnGUI(){
		if (GUI.Button (BuildContinueButton (), "Try Again?")) {
			print ("Reloading Game");
			LoadGameScene ();
		}
		if (GUI.Button (BuildQuitButton (), "Quit")) {
			print ("Terminate Program!");
			QuitGame ();

		}
	}


	Rect BuildContinueButton(){
		Rect ContinueButton = new Rect();
		float buttonX, buttonY;

		ContinueButton.height = .1f * Screen.height; // set the height to 10% the screens size
		ContinueButton.width = .15f* Screen.width; // set the width to 15% the screen size
		buttonY = .65f * Screen.height;
		buttonX = .45f * Screen.width;
		//Set up the Buttons posistion
		ContinueButton.x = buttonX;
		ContinueButton.y = buttonY;
		return ContinueButton;
	}

	Rect BuildQuitButton(){
		Rect QuitButton = new Rect();
		float buttonX, buttonY;

		QuitButton.height = .1f * Screen.height; // set the height to 10% the screens size
		QuitButton.width = .15f* Screen.width; // set the width to 15% the screen size
		buttonY = .65f * Screen.height;
		buttonX = .65f * Screen.width;
		//Set up the Buttons posistion
		QuitButton.x = buttonX;
		QuitButton.y = buttonY;
		return QuitButton;
	}

	void LoadGameScene(){ SceneManager.LoadScene ("Main Menu"); }

	void QuitGame(){ Application.Quit(); }
}
