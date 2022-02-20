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

    //Hi, I'm invading your project! -Joseph Leung
    //for dash
    private bool isDashUnlocked = true; //will change and logic for fragment amt will be in
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int dir;
    //

    //For Wall Jumping
    private bool isWallJumpUnlocked;
    private bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;
    public upgradeSelection upgrades;

    private bool wallJumping;
    public float XWallForce;
    public float YWallForce;
    public float wallJumpTime;

    //

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


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
        moveX = Input.GetAxisRaw("Horizontal");

        if(isRight && moveX < 0)
        {
            Flip();
        }
        else if (!isRight && moveX > 0)
        {
            Flip();
        }

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
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

        if (upgrades.isActives[1] && isWallJumpUnlocked)
        {
            wallJump();
        }
       
    }

    void Flip()
    {
        isRight = !isRight;
        this.transform.Rotate(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                dashTime = startDashTime;
                break;

            case "Wall":
                isTouchingFront = true;

                if(upgrades.isActives[1])
                    isGrounded = true;
                break;

            default:
                break;

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


    private void wallJump()
    {
        if (isTouchingFront && !isGrounded && moveX != 0)
        {
            wallSliding = true;
        }
        else wallSliding = false;

        if(wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.Space) && wallSliding)
        {
            wallJumping = true;
            Invoke("SetWJumpToFalse", wallJumpTime);
        }

        if(wallJumping)
        {
            rb.velocity = new Vector2(XWallForce * -moveX, YWallForce);
        }
    }

    private void setWJumpToFalse()
    {
        wallJumping = false;
    }
}
