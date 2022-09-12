using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField]
    private FloatSO Value;
  public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void update()
    {
        Value.Value = 2;
    }
}
