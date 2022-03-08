using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isRight = true;

    //general Player movement
    public float speed;
    public float jumpForce;
    public Transform bulletOrigin;
    public GameObject bullet;

    private float moveX;
    public upgradeSelection upgrades;


    //Hi, I'm invading your project! -Joseph Leung
    //Hi Joseph!

    //for dash
    private bool isDashUnlocked = true; //will change and logic for fragment amt will be in
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int dir;


    //For Wall Jumping
    private bool isWallJumpUnlocked = true;
    private bool isTouchingFront;
    private bool wallSliding;
    public float wallSlidingSpeed;

    private bool wallJumping;
    public float XWallForce;
    public float YWallForce;
    public float wallJumpTime;
    //

    //For Bomb
    private bool isBombUnlocked = true;
    private bool thrown = false;
    public GameObject bomb;
    public Rigidbody2D bombRB;
    public float bombSpeed;
    //

    //For Animations 
    private Animator plyanim;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        plyanim = GetComponent<Animator>();


        if (!isRight)
        {
            dir = 1;
        }

        else if (isRight)
        {
            dir = 2;
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if(isRight && moveX < 0)
        {
            Flip();
            //Add animation trigger here????-V
        }
        else if (!isRight && moveX > 0)
        {
            Flip();

        }

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        plyanim.SetBool("moving", moveX != 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bulletInst = Instantiate(bullet, bulletOrigin.position, Quaternion.identity);
            if (isRight)
            {
                bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            }
            else bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * jumpForce);
            isGrounded = !isGrounded;
        }

        if(upgrades.isActives[0] && isDashUnlocked)
        {
            dash();
        }

        //print(upgrades.isActives[2] + " " + isBombUnlocked + " " + Input.GetKeyDown(KeyCode.X) + " " + !thrown);
        if(upgrades.isActives[2] && isBombUnlocked && Input.GetKeyDown(KeyCode.X) && !thrown)
        {
            GameObject bombInst = Instantiate(bomb, bulletOrigin.position, Quaternion.identity);
              if (isRight)
              {
                bombInst.GetComponent<Rigidbody2D>().velocity = new Vector2(5, -1);
              }
            else bombInst.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -1);

            thrown  = !thrown;
        }

      

    }

    void Flip()
    {
        isRight = !isRight;
        this.transform.Rotate(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            dashTime = startDashTime;
        }
        if(collision.gameObject.tag=="Wall" && upgrades.isActives[1] && isWallJumpUnlocked)
        {
            isGrounded = true;
        }

        /* Replaced this with a Killplane script I thought it 
        would be easier if we had to use it again. -V
        else if (collision.gameObject.tag == "Death") { }
            //Application.LoadLevel(1);*/
    }

    private void dash()
    {
        if (dir == 0)
        {
            if (!isRight && Input.GetKeyDown(KeyCode.X))
            {
                dir = 1;
            }

            else if (isRight && Input.GetKeyDown(KeyCode.X))
            {
                dir = 2;
            }
               
        }

        else
        {
            if (dashTime <= 0)
            {
                dir = 0;

                if(isGrounded)
                    dashTime = startDashTime;
            }

            else
            {
                dashTime -= Time.deltaTime;
            }

            if (dir == 1)
                rb.AddForce(Vector2.left * dashSpeed);


            else if (dir == 2)
                rb.AddForce(Vector2.right * dashSpeed);
        }
    }


    public void setThrown(bool newThrown)
    {
        thrown = newThrown;
    }
}
