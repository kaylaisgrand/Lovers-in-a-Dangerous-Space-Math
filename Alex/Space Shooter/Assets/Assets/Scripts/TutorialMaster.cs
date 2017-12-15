using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialMaster : MonoBehaviour
{

  public GameObject Spawn;
  public GameObject[] ButtonArray = new GameObject[5];
  private SpawnerScript SpwnScript;
  public Text Txt;
  public Text Counter;
  public Text WaveCount;
  public Text TimerText;
  public GameObject IncorrectScreen;
  public GameObject PauseScreen;
  public bool ActivateTimer;
  public float myCoolTimer = 10;


  // public int LifeCount = 3; //if lifecount = 0, player loses, Game Over.
  public int a = 2;
  public int b = 5;
  public int c = 10;


  public void NewMultiplyProblem()
  {

    Txt.GetComponent<Text>().text = a.ToString() + " X " + b.ToString() + " = ?";
  }
  public void SecondMultiplyProblem()
  {
    a = 3; b = 4; c = 12;
    Txt.GetComponent<Text>().text = a.ToString() + " X " + b.ToString() + " = ?";
  }

  public void SetAnswers()
  {

    ButtonArray[1].GetComponentInChildren<Text>().text = c.ToString();

    ButtonArray[0].GetComponentInChildren<Text>().text = "8";  //Set all other buttons
    ButtonArray[0].GetComponent<Button>().interactable = false;

    ButtonArray[2].GetComponentInChildren<Text>().text = "14";
    ButtonArray[2].GetComponent<Button>().interactable = false;

    ButtonArray[3].GetComponentInChildren<Text>().text = "16";
    ButtonArray[3].GetComponent<Button>().interactable = false;

    ButtonArray[4].GetComponentInChildren<Text>().text = "6";
    ButtonArray[4].GetComponent<Button>().interactable = false;
  }

  public void SecondSetAnswers()
  {

    ButtonArray[1].GetComponentInChildren<Text>().text = "2";
    ButtonArray[0].GetComponent<Button>().interactable = true;
    ButtonArray[2].GetComponent<Button>().interactable = true;
    ButtonArray[3].GetComponent<Button>().interactable = true;
    ButtonArray[4].GetComponent<Button>().interactable = true;

    ButtonArray[0].GetComponentInChildren<Text>().text = "13";  //Set all other buttons
    ButtonArray[2].GetComponentInChildren<Text>().text = "15";
    ButtonArray[3].GetComponentInChildren<Text>().text = "20";
    ButtonArray[4].GetComponentInChildren<Text>().text = "7";
  }

  public void PrintIntro()
  {
    IncorrectScreen.GetComponentInChildren<Text>().text = "Welcome to the Tutorial!";

  }

  // Use this for initialization
  void Start()
  {

    PauseScreen.SetActive(false);
    SpwnScript = Spawn.GetComponent<SpawnerScript>();

    PrintIntro();

    SpwnScript.SpawnRowOne(); // Spawn Row 1
    SpwnScript.SpawnRowTwo();
    SpwnScript.SpawnRowThree();
    SpwnScript.SpawnRowFour();

    NewMultiplyProblem();

    SetAnswers();

  }

  // Update is called once per frame
  void Update()
  {

  }
}

