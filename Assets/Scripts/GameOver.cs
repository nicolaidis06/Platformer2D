using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        if (GameManager.instance.currentScene == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (GameManager.instance.currentScene == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene("Level3");
        }
    }
    public void OnQuitButtonClicked()
    {
        //Only works in the build of the game.
        Application.Quit();
    }
}
