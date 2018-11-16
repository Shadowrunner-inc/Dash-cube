/// Author: Nate Hales
/// Level loader. Triggers the next scene to load whin the player enters the trigger box.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public string m_Scene;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.CompareTag ("Player"))
			SwitchScenes ();
	}

	void SwitchScenes(){
		SceneManager.LoadScene (m_Scene);
	}
}
