using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{

  public Text ScoreBoard;

  public void LoadNextLevel()
  {

    string levelloaded = PersistentManagerScript.Instance.LevelName;

    switch (levelloaded)
    {

      case "Alex Level 1":
        SceneManager.LoadScene("Level 2");
        LoadingScreenManager.LoadScene("Level 2");
        break;
      case "Level 2":
        SceneManager.LoadScene("Level 3");
        LoadingScreenManager.LoadScene("Level 3");
        break;
      case "Level 3":
        SceneManager.LoadScene("Level 4");
        LoadingScreenManager.LoadScene("Level 4");
        break;
      case "Level 4":
        SceneManager.LoadScene("Level 5");
        LoadingScreenManager.LoadScene("Level 5");
        break;
      case "Level 5":
        SceneManager.LoadScene("Level 6");
        LoadingScreenManager.LoadScene("Level 6");
        break;
      case "Level 6":
        SceneManager.LoadScene("Dialogue Scne-Dividerfirst");
        LoadingScreenManager.LoadScene("Dialogue Scne-Dividerfirst");
        break;
      case "Level 7":
        SceneManager.LoadScene("Level 8");
        LoadingScreenManager.LoadScene("Level 8");
        break;
      case "Level 8":
        SceneManager.LoadScene("Level 9");
        LoadingScreenManager.LoadScene("Level 9");
        break;
      case "Level 9":
        SceneManager.LoadScene("Level 10");
        LoadingScreenManager.LoadScene("Level 10");
        break;
      case "Level 10":
        SceneManager.LoadScene("Level 11");
        LoadingScreenManager.LoadScene("Level 11");
        break;
      case "Level 11":
        SceneManager.LoadScene("Level 12");
        LoadingScreenManager.LoadScene("Level 12");
        break;
      case "Level 12":
        SceneManager.LoadScene("Dialogue Scne-Dividerfight");
        LoadingScreenManager.LoadScene("Dialogue Scne-Dividerfight");
        break;
      case "Boss Fight":
        SceneManager.LoadScene("Credits");
        LoadingScreenManager.LoadScene("Credits");
        break;
      default:
        print("something went wrong");
        break;
    }
  }

  // Use this for initialization
  void Start()
  {

    float percentage = (float)((float)PersistentManagerScript.Instance.NumCorrect / (float)PersistentManagerScript.Instance.QuestionCount * 100);

    ScoreBoard.GetComponent<Text>().text = PersistentManagerScript.Instance.NumCorrect.ToString() +
      " Correct \n " + PersistentManagerScript.Instance.NumWrong.ToString() + " Wrong \n out of " +
    PersistentManagerScript.Instance.QuestionCount.ToString() + " questions \n " + percentage.ToString("f0") + "% Accuracy";


  }

  // Update is called once per frame
  void Update()
  {

  }
}
