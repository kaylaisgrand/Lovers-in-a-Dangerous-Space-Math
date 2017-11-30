using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public GameObject Music;


    public void LoadScene(string levelName)
    {
		SceneManager.LoadScene(levelName);
        LoadingScreenManager.LoadScene(levelName);
    }
    
	public void TryAgain(){

		string level = PersistentManagerScript.Instance.LevelName;
		SceneManager.LoadScene (level);
	}

	public void LoadNextLevel(){

		string levelLoaded = PersistentManagerScript.Instance.LevelName;

		switch (levelLoaded) {

			case "Alex Level 1":  
				SceneManager.LoadScene ("Level 2");
				LoadingScreenManager.LoadScene ("Level 2");
				break;

			case "Level 2":
				SceneManager.LoadScene ("Level 3");
				LoadingScreenManager.LoadScene ("Level 3");
				break;

			case "Level 3":
				SceneManager.LoadScene ("Level 4");
				LoadingScreenManager.LoadScene ("Level 4");
				break;

			case "Level 4":
				SceneManager.LoadScene ("Level 5");
				LoadingScreenManager.LoadScene ("Level 5");
				break;

			case "Level 5":
				SceneManager.LoadScene ("Level 6");
				LoadingScreenManager.LoadScene ("Level 6");
				break;

			case "Level 6":
				SceneManager.LoadScene ("Level 7");
				LoadingScreenManager.LoadScene ("Level 7");
				break;

			case "Level 7":
				SceneManager.LoadScene ("Level 8");
				LoadingScreenManager.LoadScene ("Level 8");
				break;

			case "Level 8":
				SceneManager.LoadScene ("Level 9");
				LoadingScreenManager.LoadScene ("Level 9");
				break;

			case "Level 9":
				SceneManager.LoadScene ("Level 10");
				LoadingScreenManager.LoadScene ("Level 10");
				break;

			case "Level 10":
				SceneManager.LoadScene ("Level 11");
				LoadingScreenManager.LoadScene ("Level 11");
				break;

			case "Level 11":
				SceneManager.LoadScene ("Level 12");
				LoadingScreenManager.LoadScene ("Level 12");
				break;

			case "Level 12":
				SceneManager.LoadScene ("Boss Fight");
				LoadingScreenManager.LoadScene ("Boss Fight");
				break;

			case "Boss Fight":
				SceneManager.LoadScene ("Credits");
				LoadingScreenManager.LoadScene ("Credits");
				break;

			default:
				print ("there was an error");
				break;
		}


	}

	public void DisableMusic(bool j){

		if (j) {
			Music.SetActive (false);
		} else
			Music.SetActive (true);

	}
}
