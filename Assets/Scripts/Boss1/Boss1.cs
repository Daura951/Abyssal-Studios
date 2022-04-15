using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{


    private Animator anim;

    //Large jump attack -V
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private int vertSpeed;
    [SerializeField] private int horSpeed;
    [SerializeField] private int bigLeapCD;
    private Vector3 initialDirection;
    private bool rightSide;
    private float bigLeapAva;

    //Small jump attack -V
    [SerializeField] private Transform leftMinor;
    [SerializeField] private Transform rightMinor;
    [SerializeField] private float hopCD;
    [SerializeField] private float verthop;
    private float hopAva;

    //Shooting and the such -V
    [SerializeField] private Transform stinger;
    [SerializeField] private GameObject shot;
    [SerializeField] private float shotCooldown;
    private float shotAva;

    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;


    private void Awake()
    {
        initialDirection = this.transform.localScale;
        rightSide = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        bigLeapAva += Time.deltaTime;
        hopAva += Time.deltaTime;

        if (bigLeapAva > bigLeapCD)
        {
            anim.SetTrigger("BigLeap");
        }

        if (hopAva > hopCD)
        {
            anim.SetTrigger("Shorthop");
        }
        else
        {
            anim.ResetTrigger("Shorthop");
        }

        if (PlayerInSight())
        {
            anim.SetTrigger("sight");
        }

        else
        {
            anim.ResetTrigger("sight");
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")

        {
            collision.gameObject.GetComponent<Health>().TakeDamage(3);
        }
    }

    public void BigLeap()
    {

        if (rightSide)
        {

            if (this.transform.position.x > leftBound.position.x)
            {

                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);

                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * -1 * horSpeed, this.transform.position.y + Time.deltaTime * vertSpeed, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                rightSide = false;
                anim.ResetTrigger("BigLeap");
                bigLeapAva = 0;
                anim.SetTrigger("finished");
  
            }
            
          
        }

        else
        {
            if (this.transform.position.x < rightBound.position.x)
            {

                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);

                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * 1 * horSpeed, this.transform.position.y + Time.deltaTime * vertSpeed, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                rightSide = true;
                anim.ResetTrigger("BigLeap");
                bigLeapAva = 0;
                anim.SetTrigger("finished");

            }

        }
        
    }

    public void LittleLeapPart1()
    {
        if (rightSide)
        {

            if (this.transform.position.x > rightMinor.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * -1 * horSpeed, this.transform.position.y + Time.deltaTime * verthop, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(rightMinor.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                anim.SetTrigger("hop");
            }
        }

        else
        {
            if (this.transform.position.x < leftMinor.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * 1 * horSpeed, this.transform.position.y + Time.deltaTime * verthop, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(leftMinor.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                anim.SetTrigger("hop");
            }
        }
    }
    public void LittleLeapPart2()
    {
        anim.ResetTrigger("hop");
        if (rightSide)
        {

            if (this.transform.position.x > leftMinor.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * -1 * horSpeed, this.transform.position.y + Time.deltaTime * verthop, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(leftMinor.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                anim.SetTrigger("hop");
            }
        }

        else
        {
            if (this.transform.position.x < rightMinor.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * 1 * horSpeed, this.transform.position.y + Time.deltaTime * verthop, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(rightMinor.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                anim.SetTrigger("hop");
            }
        }
    }
    public void LittleLeapPart3()
    {
        anim.ResetTrigger("hop");
        if (rightSide)
        {

            if (this.transform.position.x > leftBound.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * -1 * horSpeed, this.transform.position.y + Time.deltaTime * verthop, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(leftBound.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                anim.SetTrigger("hop");

            }
        }

        else
        {
            if (this.transform.position.x < rightBound.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * -1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * 1 * horSpeed, this.transform.position.y + Time.deltaTime * verthop, this.transform.position.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(initialDirection.x) * 1, initialDirection.y, initialDirection.z);
                this.transform.position = new Vector3(rightBound.position.x, this.transform.position.y + Time.deltaTime, this.transform.position.z);
                anim.SetTrigger("hop");
            }
        }
    }



    public void ShotsFired()
    {
       if (rightSide)
        {
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, 0f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, -5f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, -15f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, -25f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, -45f));//, this.transform);
        }
        else
        {
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 0f, -5f));
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 0f, -15f));
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 0f, -25f));
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 0f, -45f));
            /*Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, 0f));//, this.transform);    
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, 5f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, 15f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, 25f));//, this.transform);
            Instantiate(shot, stinger.position, Quaternion.Euler(0f, 180f, 45f));//, this.transform);*/

        }
    }


    private bool PlayerInSight()
    {
        RaycastHit2D hit =
              Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
              new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
              0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    private void ResetFinish()
    {
        anim.ResetTrigger("finished");
    }

    public void ToggleSide()
    {
        rightSide = !rightSide;
        anim.SetTrigger("end");
    }

    private void OnDestroy()
    { 
            PlayerPrefs.SetInt("Boss1", 1);
            SceneManager.LoadScene(4);
        }



    }
