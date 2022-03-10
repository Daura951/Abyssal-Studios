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

    //For graple
    private bool isGrapleUnlocked = true;
    public LineRenderer line;
    private DistanceJoint2D joint;
    private Vector3 targetPos;
    private RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public float step = 0.02f;
    public bool isGrappling = false;
    public Vector2 grapple;


    //Fragments -V
    public GameObject FragUI;
    public static GameObject Alpha;
    public static GameObject Bravo;
    public static GameObject Charlie;
    public static GameObject Delta;
    public static GameObject Echo;
    public static GameObject Foxtrot;
    public static GameObject Gamma;
    public static GameObject Hotel;
    public static GameObject India;
    public static GameObject Juliet;
    public static GameObject Kilo;
    public static GameObject Lima;
    private int totalFrags;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;

        if (!isRight)
        {
            dir = 1;
        }

        else if (isRight)
        {
            dir = 2;
        }

        FragUI = GameObject.FindWithTag("Fragment");
        Alpha = FragUI.transform.GetChild(12).gameObject;
        Alpha.SetActive(false);
        Bravo = FragUI.transform.GetChild(2).gameObject;
        Bravo.SetActive(false);
        Charlie = FragUI.transform.GetChild(3).gameObject;
        Charlie.SetActive(false);
        Delta = FragUI.transform.GetChild(4).gameObject;
        Delta.SetActive(false);
        Echo = FragUI.transform.GetChild(5).gameObject;
        Echo.SetActive(false);
        Foxtrot = FragUI.transform.GetChild(6).gameObject;
        Foxtrot.SetActive(false);
        Gamma = FragUI.transform.GetChild(7).gameObject;
        Gamma.SetActive(false);
        Hotel = FragUI.transform.GetChild(8).gameObject;
        Hotel.SetActive(false);
        India = FragUI.transform.GetChild(9).gameObject;
        India.SetActive(false);
        Juliet = FragUI.transform.GetChild(10).gameObject;
        Juliet.SetActive(false);
        Kilo = FragUI.transform.GetChild(11).gameObject;
        Kilo.SetActive(false);
        Lima = FragUI.transform.GetChild(1).gameObject;
        Lima.SetActive(false);

    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");


        if (isRight && moveX < 0)
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

        if (upgrades.isActives[0] && isDashUnlocked)
        {
            dash();
        }

        //print(upgrades.isActives[2] + " " + isBombUnlocked + " " + Input.GetKeyDown(KeyCode.X) + " " + !thrown);
        if (upgrades.isActives[2] && isBombUnlocked && Input.GetKeyDown(KeyCode.X) && !thrown)
        {
            GameObject bombInst = Instantiate(bomb, bulletOrigin.position, Quaternion.identity);
            if (isRight)
            {
                bombInst.GetComponent<Rigidbody2D>().velocity = new Vector2(5, -1);
            }
            else bombInst.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -1);

            thrown = !thrown;
        }

        if (upgrades.isActives[3] && isGrapleUnlocked)
        {

            if (joint.distance > .5f)
                joint.distance -= step;


            if (Input.GetKeyDown(KeyCode.X))
            {
                targetPos = grapple;
                targetPos.z = 0;
                print(targetPos);

                hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

                if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    joint.enabled = true;

                    Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                    connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                    connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;

                    joint.connectedAnchor = connectPoint;

                    joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();

                    joint.distance = Vector2.Distance(transform.position, hit.point);

                    line.enabled = true;



                }
            }

            if (line.enabled)
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }

            if (joint.enabled)
                line.SetPosition(1, joint.connectedBody.transform.TransformPoint(joint.connectedAnchor));

            if (Input.GetKey(KeyCode.X))
            {

                line.SetPosition(0, transform.position);
            }


            if (Input.GetKeyUp(KeyCode.X))
            {
                joint.enabled = false;
                targetPos = new Vector3(0, 0, 0);
                grapple = new Vector2(0, 0);
                line.enabled = false;
            }
        }

        //To look at the collected fragments -V
        if (Input.GetKey(KeyCode.F))
        {
            FragUI.SetActive(true);
        }
        else
        {
            FragUI.SetActive(false);
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
        if (collision.gameObject.tag == "Wall" && upgrades.isActives[1] && isWallJumpUnlocked)
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

                if (isGrounded)
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
