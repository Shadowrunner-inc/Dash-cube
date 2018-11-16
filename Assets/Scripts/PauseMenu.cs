//Author: Nate hales
//Pause menu button ui Logic
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Button rBtn, qBtn, rsBtn, mMBtn; // declare resume, quit, and restart buttons.
	public GameObject pauseM, checkM;
	public string[] checkMText; // string for check menu text.
	int checkValue; // int for check menu yes button.
	public bool isPaused;
	public int mMlevel;

	void Update () {
		if (isPaused == true && Input.GetKeyDown (KeyCode.Escape)) {
			pauseM.SetActive (false);
			checkValue = 0;
			Time.timeScale = 1.0f;
			isPaused = false;
		} else {
			isPaused = true;
		}

		if (checkM.gameObject.activeSelf == true) {
			qBtn.GetComponent<Button> ().enabled = false;
			rBtn.GetComponent<Button> ().enabled = false;
			rsBtn.GetComponent<Button> ().enabled = false;
		}
	}

	public void clickResume(){
		pauseM.SetActive (false);
		Time.timeScale = 1.0f;
		isPaused = false;
	}

	public void clickRestart(){
		checkM.SetActive (true);
		checkM.GetComponentInChildren<Text>().text = checkMText[1];
		checkValue = 2;
	}

	public void clickQuit(){
		checkM.SetActive (true);
		checkM.GetComponentInChildren<Text>().text = checkMText[0];
		checkValue = 1;
	}

	public void checkYes(){

        if (checkValue == 1) {
			isPaused = false;
			Application.Quit();
		}

		if (checkValue == 2) {
			Scene currentlevel = SceneManager.GetActiveScene (); // gets curent scene name;
			Time.timeScale = 1.0f;
			isPaused = false;
			SceneManager.LoadScene (currentlevel.name); // reloads current scene;
		}

		if (checkValue == 3) {
            Time.timeScale = 1.0f;
			isPaused = false;
			SceneManager.LoadScene(mMlevel); // loads main menu.
        }
	}

	public void cancelCheck(){
		checkM.SetActive (false);
		checkValue = 0;
		qBtn.GetComponent<Button> ().enabled = true;
		rBtn.GetComponent<Button> ().enabled = true;
		rsBtn.GetComponent<Button> ().enabled = true;
	}

	public void clickMM() {
        checkM.SetActive(true);
		checkM.GetComponentInChildren<Text> ().text = checkMText [2];
        checkValue = 3;
    }
}
