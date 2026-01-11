using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton: Only one instance of it is possible.
    //Accesible from any script of the project.
    //Previous player data is stored.

    public Vector3 SavedPosition { get; private set; } = new Vector3(0, 0f, 0);
    public Vector3 SavedRotation { get; set; }

    public int currentScene = 1;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNewLevel(int levelIndex, Vector3 spawnPosition, Vector3 spawnRotation)
    {
        //Sort of SaveData between scenes.
        SavedPosition = spawnPosition;
        SavedRotation = spawnRotation;
        SceneManager.LoadScene(levelIndex);
    }
}
