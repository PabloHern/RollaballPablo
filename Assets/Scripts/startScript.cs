using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  public void changeScene(int index)
  {
    SceneManager.LoadScene(index);
  }
  public void quitGame()
  {
    Application.Quit();

  }
  void Update()
  {

  }
}
