using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    // Movement -V
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private Transform upperBound;
    [SerializeField] private Transform lowerBound;

    //[SerializeField] private Transform enemyleft;
    //[SerializeField] private Transform enemyright;
    [SerializeField] private float speed;
    [SerializeField] private float flySpeed;
    [SerializeField] private float idle;
    private bool rightSide;
    private bool moving;
    private Vector3 initialDirection;
    private int flap;
    private bool risingEdge;
    private float idleTime;

    //Pushback -V
    [SerializeField] private GameObject blasts;
    [SerializeField] private Transform center;

    //Downward attacks -V
    [SerializeField] private GameObject ouch;

    //Gizmos stuff - V
    [SerializeField] private float range;
    [SerializeField] private float vert;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    //Forward Shot -V
    [SerializeField] private Transform shootie;
    [SerializeField] private Transform player;

    //Scene Change -V
    [SerializeField] private GameObject mainPlatform;
    [SerializeField] private GameObject section1;
    [SerializeField] private GameObject section2;
    [SerializeField] private GameObject section3;
    private int scene;

    [SerializeField] private Animator anims;


    void Start()
    {
        rightSide = true;
        initialDirection = this.transform.localScale;
        flap = 1;
        risingEdge = true;
        moving = true;
        // SceneChange();
        //DownwardShot();
        //ForwardShot();
        //PushBack();
    }
    // Update is called once per frame
    void Update()
    {
        if (rightSide)
        {

            if (this.transform.position.x >= leftBound.position.x)
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
            if (this.transform.position.x <= rightBound.position.x)
            {
                MoveInDirection(1, flap);
            }
            else
            {
                ChangeDirection();
            }

        }

        if (risingEdge)
        {
            if (this.transform.position.y >= upperBound.position.y)
            {
                flap = -1;
                risingEdge = false;
            }
        }
        else
        {
            if (this.transform.position.y <= lowerBound.position.y)
            {
                flap = 1;
                risingEdge = true;
            }
        }

        if (PlayerInSight())
        {
           moving = false; 
           if(player.position.x > this.transform.position.x)
           {
               rightSide = true;
               //ForwardShot();
               StartCoroutine(GetOut());
           }

           else
           {
               rightSide = false;
               //ForwardShot();
               StartCoroutine(GetOut());
           }
        }
        else
       {
            moving = true;
       }

        //if()
        if (this.transform.position.x - leftBound.position.x > rightBound.position.x - this.transform.position.x)
        {

        }
    }

    //After enough damage knocks player away
    private void PushBack()
    {
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, 85f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, -85f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, 45f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, -45f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);

        //Ending anim trigger here -V
    }


    
    //attacks player while climbing up
    private void DownwardShot()
    {
        StartCoroutine(Shooting());
    }

    //Attacks player on main platform
    private void SwoopingAttack()
    {
       
    }

    //another main platform attack with more vertical less pararabole
    private void WavySwoop()
    {

    }

    private void ForwardShot()
    {
        //have enemy look toward player and fire straight at them
        Instantiate(ouch, shootie.position, Quaternion.Euler(0f, 0f, 90f), this.transform);
    }

    private void SceneChange()
    {
        StartCoroutine(Leave());
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
              Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
              new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z),
              0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y , boxCollider.bounds.size.z));
    }


    private IEnumerator Shooting()
    {
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2); 
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);

        //add anim end trigger - V
    }

    private IEnumerator Leave()
    {
        PushBack();
        yield return new WaitForSeconds(1);
        mainPlatform.SetActive(false);
        //edit to put things back
        yield return new WaitForSeconds(5);
        mainPlatform.SetActive(true);
       
    }

    private IEnumerator GetOut()
    {
        ForwardShot();
        yield return new WaitForSeconds(2);
    }

    private void MoveInDirection(int _direction, int _fly)
    {
        idleTime = 0;
        anims.SetBool("moving", true);

        this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * _direction, initialDirection.y, initialDirection.z);

        this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * _direction * speed, this.transform.position.y + Time.deltaTime * _fly * flySpeed, this.transform.position.z);

    }

    private void ChangeDirection()
    {
        anims.SetBool("moving", false);
        //idleTime += Time.deltaTime;

        rightSide = !rightSide;

        /*if (idleTime > idle)
        {
            rightSide = !rightSide;
        }
        */
    }



}
