using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;
    //Singleton pattern.
    //1. Only 1 instance of AudioManager.
    //2. Accesible from any kind of entity into your project.
    public static AudioManager instance = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //Won't be destroyed through scenes.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clipToPlay)
    {
        SFXSource.PlayOneShot(clipToPlay);
    }
}
