using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] private GameObject wanderer;
    [SerializeField] private float speed;
    [SerializeField] private bool flipping;

    Node[] pathing;
    private static Vector3 currentPosition;
    private static Vector3 startPosition;
    private Vector3 initialDirection;
    private int currentNode;
    private float timer;
   

    // Start is called before the first frame update
    void Start()
    {
        pathing = GetComponentsInChildren<Node>();
       
        CheckNode();
        print("startingagain");
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        timer += Time.deltaTime * speed;

        if (flipping)
        {
            wanderer.transform.localScale = new Vector3((initialDirection.x) * -1, initialDirection.y, initialDirection.z);
        }
        
        if (wanderer.transform.position != currentPosition)
        {
            wanderer.transform.position = Vector3.Lerp(startPosition, currentPosition, timer);
        }
        else
        {
            /*if (currentNode == 0 & flipping)
            {
                wanderer.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
            } */
            if (currentNode < pathing.Length - 1)
            {
                currentNode++;
                CheckNode();
            }
        }
    }

    private void CheckNode()
    {
        startPosition = wanderer.transform.position;
        timer = 0;
        currentPosition = pathing[currentNode].transform.position;
    }

    private void DrawLine()
    {
        for(int i=0; i < pathing.Length; i++)
        {
            if(i < pathing.Length - 1)
            {
                Debug.DrawLine(pathing[i].transform.position, pathing[i + 1].transform.position, Color.yellow);
            }
        }
    }

    private void OnDisable()
    {
        currentNode = 0;
        currentPosition = pathing[0].transform.position;
    }

    private void OnEnable()
    {
        startPosition = wanderer.transform.position;
        initialDirection = wanderer.transform.localScale;
    }
}
