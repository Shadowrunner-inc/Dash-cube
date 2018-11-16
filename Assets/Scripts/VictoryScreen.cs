//Author: Nate Hales
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {


	void OnGUI(){
		if (GUI.Button (BuildMainMenuButton (), "Main Menu")) {
				print ("Back to Main Menu");
				LoadMMenuScene ();
		}
		if (GUI.Button (BuildQuitButton (), "Quit")) {
				print ("Terminate Program!");
				QuitGame ();

		}
	}


	Rect BuildMainMenuButton(){
		Rect MainMenuButton = new Rect();
		float buttonX, buttonY;

		MainMenuButton.height = .1f * Screen.height; // set the height to 10% the screens size
		MainMenuButton.width = .15f* Screen.width; // set the width to 15% the screen size
		buttonY = .65f * Screen.height;
		buttonX = .45f * Screen.width;
		//Set up the Buttons posistion
		MainMenuButton.x = buttonX;
		MainMenuButton.y = buttonY;
		return MainMenuButton;
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

	void LoadMMenuScene(){ SceneManager.LoadScene ("Main Menu"); }

	void QuitGame(){ Application.Quit(); }
}
