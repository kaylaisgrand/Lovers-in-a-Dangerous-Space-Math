using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TutorialClick : MonoBehaviour
{

  public GameObject Master;
  public GameObject Spawn;
  //   public GameObject arrow;
  //   public GameObject arrow2;
  //   public GameObject arrow3;
  //   public GameObject arrow4;
  private SpawnerScript SpwnScript;

  public SpawnerScript spawner;
  
  private TutorialMaster MstrScript;

  public void Reset()
  {
    MstrScript = Master.GetComponent<TutorialMaster>();
    MstrScript.NewMultiplyProblem();
    MstrScript.SetAnswers();
  }

  public void SecondReset()
  {
    MstrScript = Master.GetComponent<TutorialMaster>();
    MstrScript.SecondMultiplyProblem();
    MstrScript.SecondSetAnswers();
  }

  public void ButtonAnswer()
  {
    MstrScript = Master.GetComponent<TutorialMaster>();
    SpwnScript = Spawn.GetComponent<SpawnerScript>();

    string theButtonValue = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

    if (theButtonValue == MstrScript.c.ToString()) //Tutorial makes the user answer correctly
    {
      SpwnScript.PlayerFireFirstRow();
      // Dialogue - Mo says Good Job!

      //Correct 1->8
      SpwnScript.Invoke("RemoveRowFour", 1);
      SpwnScript.Invoke("SpawnRowOne", 1);
      Invoke("SecondReset", 1);
    }
    else // Tutorial makes the user answer incorrectly
    {
      SpwnScript.EnemyFire();
      //

    }
    //Invoke("Reset", 1);
  }

  public void DisplayIncorrect()
  {
    //Shows the incorrect screen and resets the timer back to 10 sec
    MstrScript = Master.GetComponent<TutorialMaster>();
    MstrScript.IncorrectScreen.GetComponentInChildren<Text>().text = "Incorrect. \n \n The correct answer to \n " + MstrScript.a.ToString() + " X " + MstrScript.b.ToString() + " is " + MstrScript.c.ToString();
    MstrScript.IncorrectScreen.SetActive(true);
    MstrScript.ActivateTimer = false;
  }

  public void CloseIncorrect()
  {
    //closes the window and resets timer
    MstrScript = Master.GetComponent<TutorialMaster>();
    MstrScript.IncorrectScreen.SetActive(false);
    MstrScript.myCoolTimer = 10;
    MstrScript.ActivateTimer = true;
    Reset();
  }
  public void DisplayPause()
  {
    //Shows the pause screen and resets the timer back to 10 sec
    MstrScript = Master.GetComponent<TutorialMaster>();
    MstrScript.PauseScreen.SetActive(true);
    MstrScript.ActivateTimer = false;
  }

  public void ClosePause()
  {
    //closes the window and resets timer
    MstrScript = Master.GetComponent<TutorialMaster>();
    MstrScript.PauseScreen.SetActive(false);
    //MstrScript.myCoolTimer = 10;
    MstrScript.ActivateTimer = true;
    //MstrScript.Txt.SetActive (false);
  }


  public void LoadNextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  public void LoadMainMenu()
  {
    SceneManager.LoadScene("Splash Screen");
    LoadingScreenManager.LoadScene("Splash Screen");

  }


  public void Start()
  {
    //LifeCount = 3;
    //CorrectCount = 0;
    MstrScript = Master.GetComponent<TutorialMaster>();

  }


  public void Update()
  {




  }




}

