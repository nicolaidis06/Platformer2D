using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //The level that this portal pretends to load.
    //New position and rotation for the player of the next level.
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Vector3 spawnRotation;
    [SerializeField] private int targetLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.currentScene = targetLevel;
            GameManager.instance.LoadNewLevel(targetLevel, spawnPosition, spawnRotation);
        }
    }
}
