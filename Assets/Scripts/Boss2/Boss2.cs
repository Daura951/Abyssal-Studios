using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    // Movement -V
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private Transform upperBound;
    [SerializeField] private float speed;
    private bool rightSide;
    private bool moving;
    private Vector3 initialDirection;

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
    [SerializeField] private BoxCollider2D onStage;
    [SerializeField] private float range2;
    [SerializeField] private float vert2;
    [SerializeField] private float colliderDistance2;

    //Forward Shot -V
    [SerializeField] private Transform shootie;
    [SerializeField] private Transform player;


    [SerializeField] private Animator anims;
    [SerializeField] private int divelimit;
    private float divetimer;
    private bool divaAva;
    private bool sight;
    private bool attacking;

    //Movement Attacks
    [SerializeField] private GameObject leftwave;
    private bool stage;
    [SerializeField] private GameObject rightswoop;

    //Health switching
    [SerializeField] private Health limit;
    [SerializeField] private GameObject mainstage;
    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;
    private int phase;

    [SerializeField] private bool hack;



    void Start()
    {
        rightSide = true;
        initialDirection = this.transform.localScale;
        moving = true;
        divaAva = false;
        leftwave.SetActive(false);
        rightswoop.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        phase = 1;
 
    }
    // Update is called once per frame
    void Update()
    {
        divetimer += Time.deltaTime;
        if (divetimer > divelimit)
        {
            divaAva = true;
        }

       if(rightSide)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
        }
        else
        {
            this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
        }
    
        
       if (moving)
       {
            if (rightSide)
            {

                if (this.transform.position.x >= leftBound.position.x)
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
                if (this.transform.position.x <= rightBound.position.x)
                {
                    MoveInDirection(1);
                }
                else
                {
                    ChangeDirection();
                }

            }
        }
      

        if (PlayerInSight())
        {
            anims.SetTrigger("Sight");
            sight = true;
            print("how");
        }
        else
        {
            anims.ResetTrigger("Sight");
            sight = false;
            print("why");
        }

        if (PlayerOnStage())
        {
            stage = true;
            print("yessir");
        }
        else
        {
            stage = false;
            print("nosir");
        }

        if (!hack)
        {

            if (limit.currentHealth > 6)
            {

            }
            else if (limit.currentHealth > 3)
            {
                anims.SetTrigger("phase2");

            }
            else if(limit.currentHealth<0)
            {
                PlayerPrefs.SetInt("Boss2", 1);
                SceneManager.LoadScene(2);
            }
            else
            {
                anims.SetTrigger("phase3");
            }
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

        mainstage.SetActive(false);
        stage1.SetActive(false);
        if(phase == 3)
        {
            stage2.SetActive(false);
        }

        StartCoroutine(Leave());

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
        rightswoop.SetActive(true);

    }

    //another main platform attack with more vertical less pararabole
    private void WavySwoop()
    {
        rightSide = true;
        leftwave.SetActive(true);

    }

    private void ForwardShot()
    {
        //have enemy look toward player and fire straight at them
        if (rightSide)
        {
            Instantiate(ouch, shootie.position, Quaternion.Euler(0f, 0f, 90f));
        }
        else
        {
            Instantiate(ouch, shootie.position, Quaternion.Euler(0f, 0f, -90f));
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
              Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
              new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z),
              0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }

    private bool PlayerOnStage()
    {
        RaycastHit2D hit =
              Physics2D.BoxCast(onStage.bounds.center + transform.right * range2 * transform.localScale.x * colliderDistance2,
              new Vector3(onStage.bounds.size.x * range2, onStage.bounds.size.y * vert2, onStage.bounds.size.z),
              0, Vector2.left, 0, playerLayer);

      

        return hit.collider != null;
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(onStage.bounds.center + transform.right * range2 * transform.localScale.x * colliderDistance2,
           new Vector3(onStage.bounds.size.x * range2, onStage.bounds.size.y * vert2 , onStage.bounds.size.z));
    }

    private IEnumerator Shooting()
    {
        if (!sight)
        {
            Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(2);
        }
        if (!sight)
        {
            Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(2);
        }
        if (!sight)
        {
            Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(2);
        }
        if (!sight)
        {
            Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(2);
        }
        if (!sight)
        {
            Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(2);
        }
        //add anim end trigger - V
    }

    private IEnumerator Leave()
    {
        yield return new WaitForSeconds(5);
        mainstage.SetActive(true);
        if(phase == 2)
        {
            stage2.SetActive(true);
            anims.SetTrigger("endcycle2");
        }

        if(phase == 3)
        {
            stage3.SetActive(true);
            anims.SetTrigger("endcycle3");
        }


        anims.ResetTrigger("phase3");
        anims.ResetTrigger("phase2");


    }

    private IEnumerator GetOut()
    {
        ForwardShot();
        yield return new WaitForSeconds(2);
    }

    private void MoveInDirection(int _direction)
    {

        anims.SetBool("moving", true);

        this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * _direction, initialDirection.y, initialDirection.z);

        this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * _direction * speed, this.transform.position.y, this.transform.position.z);

    }

    private void ChangeDirection()
    {
        anims.SetBool("moving", false);
      
        rightSide = !rightSide;

        StartCoroutine(LeftStart());
      


    }

    private void Attack()
    {
        moving = false;
        if (player.position.x > this.transform.position.x)
        {
            rightSide = true;
            StartCoroutine(GetOut());
        }

        else
        {
            rightSide = false;
            StartCoroutine(GetOut());
        }
    }

    private void MoveAgain()
    {
        moving = true;
    }

    private IEnumerator LeftStart()
    {
        yield return new WaitForSeconds(2);
        if (stage & divaAva & rightSide)
        {
            moving = false;
            attacking = true;
            anims.SetTrigger("Attack");
        }
        if(stage & divaAva & !rightSide)
        {
            moving = false;
            attacking = true;
            anims.SetTrigger("attack");
        }
     
    }

    private void PathReset()
    {
        leftwave.SetActive(false);
        rightswoop.SetActive(false);
        anims.ResetTrigger("Attack");
        anims.ResetTrigger("attack");
        divaAva = false;
        attacking = false;
        moving = true;
        divetimer = 0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")

        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }

    private void Phase2()
    {
        moving = false;
        attacking = true;
        phase = 2;
        PushBack();
    }

    private void Phase3()
    {
        moving = false;
        attacking = true;
        phase = 3;
        PushBack();

    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Boss2", 1);
        SceneManager.LoadScene(1);
    }
}
