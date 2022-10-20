using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.N)& Input.GetKey(KeyCode.I) & Input.GetKey(KeyCode.C) & Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(4);
        }
    }

}
