using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public bool isExecuting;

    private void Awake()
    {
        StartCoroutine(TurnOn());
    }

    private IEnumerator TurnOn()
    {
        while (true == true)
        {
            Debug.Log("Green");
            yield return new WaitForSeconds(5f);
            Debug.Log("Yellow");
            yield return new WaitForSeconds(1.5f);
            Debug.Log("Red");
            yield return new WaitForSeconds(5f);
        }
    }
}
