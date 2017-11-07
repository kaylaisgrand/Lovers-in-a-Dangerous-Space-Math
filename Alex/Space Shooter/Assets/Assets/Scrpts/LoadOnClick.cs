using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene(string levelName)
    {
		SceneManager.LoadScene(levelName);
    }
}
