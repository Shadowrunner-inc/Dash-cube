//Author: Nate hales
// Main Menu GUI logic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;
using System.Runtime.InteropServices;

public class MMenuCode : MonoBehaviour {

    public String levelName;
    [SerializeField] Rect playRect, QuitRect;

	void OnGUI(){


		if (GUI.Button (BuildPlayButton (), "Play game!")) {
			print ("Starting the game");
			LoadGameScene ();
		}
		if (GUI.Button (BuildQuitButton (), "Quit")) {
			print ("Terminate Program!");
			QuitGame ();

		}
	}


	Rect BuildPlayButton(){
		Rect PlayButton = new Rect();
		float buttonX, buttonY;

		PlayButton.height = playRect.height * Screen.height; // set the height to 10% the screens size
		PlayButton.width = playRect.width* Screen.width; // set the width to 15% the screen size
		buttonY = playRect.y * Screen.height;
		buttonX = playRect.x * Screen.width;
		//Set up the Buttons posistion
		PlayButton.x = buttonX;
		PlayButton.y = buttonY;
		return PlayButton;
	}

	Rect BuildQuitButton(){
		Rect QuitButton = new Rect();
		float buttonX, buttonY;

		QuitButton.height = QuitRect.height * Screen.height; // set the height to 10% the screens size
		QuitButton.width = QuitRect.width* Screen.width; // set the width to 15% the screen size
		buttonY = QuitRect.y * Screen.height;
		buttonX = QuitRect.x * Screen.width;
		//Set up the Buttons posistion
		QuitButton.x = buttonX;
		QuitButton.y = buttonY;
		return QuitButton;
	}


	void LoadGameScene(){ SceneManager.LoadScene (levelName);	}

	void QuitGame(){ Application.Quit(); }

}
