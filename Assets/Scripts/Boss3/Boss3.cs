using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss3 : MonoBehaviour
{

    [SerializeField] private Transform launchposition;
    [SerializeField] private GameObject cans;
    private int totalcans;

    [SerializeField] private GameObject heart;

    [SerializeField] private GameObject die;

    [SerializeField] private GameObject syringe;

    [SerializeField] private int health;
    public bool hurtable;
    private int attack;
    [SerializeField]private Animator anim;

    [SerializeField] private GameObject c;
    [SerializeField] private GameObject h;
    [SerializeField] private GameObject d;
    [SerializeField] private GameObject s;
    [SerializeField] private GameObject b;

    private bool cn;
    private bool he;
    private bool di;
    private bool sy;
    private bool bo;


    void Start()
    {
        hurtable = false;
        //StartCoroutine(Testing());
        c.SetActive(false);
        h.SetActive(false);
        d.SetActive(false);
        s.SetActive(false);
        b.SetActive(false);

        cn = false;
        he = false;
        di = false;
        sy = false;
        bo = false;

    }

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            Destroy(this.gameObject);
            anim = GetComponent<Animator>();
            PlayerPrefs.SetInt("Boss3", 1);
            SceneManager.LoadScene(2);
        }

        if(cn)
        {
            c.SetActive(true);
        }
        else
        {
            c.SetActive(false);
        }


        if(he)
        {
            h.SetActive(true);
        }
        else
        {
            h.SetActive(false);
        }

        if(di)
        {
            d.SetActive(true);
        }
        else
        {
            d.SetActive(false);
        }


        if(sy)
        {
            s.SetActive(true);
        }
        else
        {
            s.SetActive(false);
        }

        if(bo)
        {
            b.SetActive(true);
        }
        else
        {
            b.SetActive(false);
        }


    }

    private void ChooseAttack()
    {
        
        attack = Random.Range(0, 5);
        print(attack);

        if (attack == 0)
        {
            anim.SetTrigger("beer");
            cn = true;
    
        }
        else if (attack == 1)
        {
            anim.SetTrigger("dice");
            di = true;

        }
        else if (attack == 2)
        {
            anim.SetTrigger("syringe");

            sy = true;

        }
        else if (attack == 3)
        {
            anim.SetTrigger("love");
            he = true;

        }
        else if (attack == 4)
        {
            anim.SetTrigger("bomb");

            bo = true;
        }
    }
    
    
    //spawns beer cans that roll to the left of the screen,  
    private void BeerCans()
    {
        totalcans = Random.Range(1, 11);
        StartCoroutine(StartRolling());
    }

    //spawns a pair of dice that bounce around the screen
    private void Dice()
    {
        StartCoroutine(SnakeEyes());
    }

    //spawns an arching syringe, maybe an area of effect at the end of it dont quote me on that tho
    private void Syringe()
    {
        Instantiate(syringe, launchposition.position, Quaternion.Euler(0f, 0f, 0f));
    }

    //Spawns a heart that moves in wave like structure or a heart beat line idk yet
    private void Love()
    {
        Instantiate(heart, launchposition.position, Quaternion.Euler(0f, 0f, 0f));
    }

    //gives the player a chance to hit the boss
    private void Bomb()
    {
        hurtable = true;
        StartCoroutine(Hurtable());
    }

    private IEnumerator Hurtable()
    {
        yield return new WaitForSecondsRealtime(3);
        hurtable = false;
        anim.ResetTrigger("bomb");

    }

    private IEnumerator StartRolling()
    {
        for(int i = 0; i < totalcans; i++)
        {
            Instantiate(cans, launchposition.position, Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(3);

        }

        anim.ResetTrigger("beer");
    }

   private IEnumerator SnakeEyes()
    {
        Instantiate(die, launchposition.position, Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(1);
        Instantiate(die, launchposition.position, Quaternion.Euler(0f, 0f, 0f));

    }

    private IEnumerator Testing()
    {

        yield return new WaitForSeconds(3);
        Instantiate(syringe, launchposition.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            if(hurtable)
            {
                hurtable = false;
                health = health - 1;
                print("hmm");
                anim.ResetTrigger("bomb");
            }

        }

    }

    private void BigReset()
    {
        anim.ResetTrigger("beer");
        anim.ResetTrigger("dice");
        anim.ResetTrigger("syringe");
        anim.ResetTrigger("love");
        anim.ResetTrigger("bomb");
        
        cn = false;
        he = false;
        di = false;
        sy = false;
        bo = false;
        
    }

}
