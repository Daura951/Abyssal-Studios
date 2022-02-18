using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrols : MonoBehaviour
{
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private Transform upperBound;
    [SerializeField] private Transform lowerBound;

    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    [SerializeField] private float flySpeed;
    [SerializeField] private bool flying;

    private bool leftFace;
    private bool risingEdge;

    private int flap;
    private Vector3 initialDirection;

    private void Awake()
    {
        initialDirection = enemy.localScale;
        flap = 1;
        risingEdge = true;
    }
    
    private void Update()
    {
        if (leftFace)
        {

            if (enemy.position.x >= leftBound.position.x)
            {
                MoveInDirection(-1, flap);
            }
            else
            {
                ChangeDirection();
            }

        }
        else
        {
            if (enemy.position.x <= rightBound.position.x)
            {
                MoveInDirection(1, flap);
            }
            else
            {
                ChangeDirection();
            }

        }

        if (flying)
        {
            if (risingEdge)
            {
                if (enemy.position.y >= upperBound.position.y)
                {
                    flap = -1;
                    risingEdge = false;
                }
            }

            else
            {
                if (enemy.position.y <= lowerBound.position.y)
                {
                    flap = 1;
                    risingEdge = true;
                }
            }
        }

    } 

    private void MoveInDirection(int _direction, int _fly)
    {
       enemy.localScale = new Vector3(Mathf.Abs(initialDirection.x) * _direction, initialDirection.y, initialDirection.z);
        
       enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y +Time.deltaTime * _fly * flySpeed, enemy.position.z);
        
    }

    private void ChangeDirection()
    {
        leftFace = !leftFace;
    }

}
