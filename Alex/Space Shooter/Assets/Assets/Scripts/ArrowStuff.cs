using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStuff : MonoBehaviour
{

  // Use this for initialization
  public GameObject arrowimg;
  public bool hide = true;
  void Start()
  {
    arrowimg.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void show()
  {
    arrowimg.SetActive(true);
}
}
