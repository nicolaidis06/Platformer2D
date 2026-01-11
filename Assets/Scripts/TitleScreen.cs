using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //Despite the script's name, it works both for the title and ending screens.
    public void OnPlayButtonClicked()
    {
        GameManager.instance.currentScene = 1;
        SceneManager.LoadScene("Level1");
    }
    public void OnQuitButtonClicked()
    {
        //Only works in the build of the game.
        Application.Quit();
    }
}
