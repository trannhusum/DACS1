using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static MoveCamera Instance { get; private set; }
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> points;
    private State state;

    private int currentIndex = 0;
    private bool isReversing = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(Instance);
        state = State.BeforeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.BeforeStart)
        {
            MoveBetweenPoints();
        }
        else
        {

        }
    }
    private void MoveBetweenPoints()
    {
        Vector3 currentPoint = points[currentIndex].position;

        Vector3 v0 = currentPoint - transform.position;
        if (v0.magnitude < 0.1f)
        {
            if (currentIndex >= points.Count - 1)
            {
                isReversing = true;
            }
            else if (currentIndex <= 0)
            {
                isReversing = false;
            }
            currentIndex += isReversing ? -1 : 1;
            currentPoint = points[currentIndex].position;
        }
        Vector3 directionVector = v0.normalized;
        transform.Translate(directionVector * speed * Time.deltaTime);
    }
    public enum State{
        BeforeStart,
        AfterStart,
        
    }
}
