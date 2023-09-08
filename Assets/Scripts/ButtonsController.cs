using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void StartGameEasy()
    {
        FindObjectOfType<Configuration>().WaitTime = 0.50f;
        SceneManager.LoadScene(1);
    }
    public void StartGameMedium()
    {
        FindObjectOfType<Configuration>().WaitTime = 0.25f;
        SceneManager.LoadScene(1);
    }
    public void StartGameHard()
    {
        FindObjectOfType<Configuration>().WaitTime = 0.1f;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
