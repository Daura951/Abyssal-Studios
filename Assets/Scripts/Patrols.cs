using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrols : MonoBehaviour
{
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;

    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;

    private bool leftFace;


    private Vector3 initialDirection;

    private void Awake()
    {
        initialDirection = enemy.localScale;
    }
    
    private void Update()
    {
        if (leftFace)
        {

            if (enemy.position.x >= leftBound.position.x)
            {
                MoveInDirection(-1);
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
                MoveInDirection(1);
            }
            else
            {
                ChangeDirection();
            }

        }

    } 

    private void MoveInDirection(int _direction)
    {
       enemy.localScale = new Vector3(Mathf.Abs(initialDirection.x) * _direction, initialDirection.y, initialDirection.z);
        
       enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
        
    }

    private void ChangeDirection()
    {
        leftFace = !leftFace;
    }

}
