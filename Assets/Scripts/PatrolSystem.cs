using System.Collections.Generic;
using UnityEngine;

public class PatrolSystem : MonoBehaviour
{
    [SerializeField] private Transform patrolPath;
    [SerializeField] float speed;

    private List<Vector3> patrolPoints = new List<Vector3>();

    private int currentIndex;

    void Awake()
    {
        foreach (Transform child in patrolPath)
        {
            //list of points to patrol
            patrolPoints.Add(child.position);
            Debug.Log(child.name);
        }
        transform.eulerAngles = transform.position.x > patrolPoints[currentIndex].x ? new Vector3(0, 180, 0) : Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //position is equal to the calculation of the MoveTowards method.
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentIndex], speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentIndex])
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        currentIndex = (currentIndex + 1) % patrolPoints.Count;

        transform.eulerAngles = transform.position.x > patrolPoints[currentIndex].x ? new Vector3(0, 180, 0) : Vector3.zero;
    }
}
