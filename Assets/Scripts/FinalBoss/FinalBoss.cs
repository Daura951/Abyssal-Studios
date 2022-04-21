using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{

    [SerializeField] private Health limit;
    [SerializeField] private Animator anims;
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject final;

    [SerializeField] private GameObject b1;
    [SerializeField] private GameObject b2;
    [SerializeField] private GameObject ceiling;
    [SerializeField] private GameObject b3;

    [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D hitbox;
    private SpriteRenderer sprites;
    private bool moving;
    private bool jumpy;
    


    // Start is called before the first frame update
    void Start()
    {
        ceiling.SetActive(false);
        final.SetActive(false);
        hitbox.enabled = false;
        moving = false;
        jumpy = false;

        sprites = GetComponent<SpriteRenderer>();
        StartCoroutine(StartFight());
        //StartCoroutine(Testing());
    }

    // Update is called once per frame
    void Update()
    {
 
        if(limit.currentHealth == 8)
        {
            StartCoroutine(Ghostie());
            limit.currentHealth = 7;
        }
        else if (limit.currentHealth == 6)
        {
            StartCoroutine(NoDicePls());
            limit.currentHealth = 5;
        }
        else if(limit.currentHealth == 4)
        {
            StartCoroutine(Leaving());
            limit.currentHealth = 3;
        }

        if( moving)
        {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed, this.transform.position.y, this.transform.position.z);
        }
        if (jumpy)
        {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed * -1, this.transform.position.y, this.transform.position.z);
        }


    }

    private IEnumerator Testing()
    {
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.3f, .3f, .3f, 1);


        yield return new WaitForSeconds(3);
        moving = true;
        yield return new WaitForSeconds(3);
        FinalPhase();
        yield return new WaitForSeconds(4);
        moving = false;
        yield return new WaitForSeconds(4);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);

        hitbox.enabled = true;

        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
    }

    private IEnumerator StartFight()
    { 
        yield return new WaitForSeconds(3);
        Instantiate(b1, spawn.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private IEnumerator Ghostie()
    {

        yield return new WaitForSeconds(.25f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.25f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.25f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.25f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.25f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.25f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(3);
        Instantiate(b2, spawn.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private IEnumerator NoDicePls()
    {

        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(3);
        ceiling.SetActive(true);
        Instantiate(b3, spawn.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private IEnumerator Leaving()
    {

        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(.5f);
        sprites.color = new Color(.5f, .5f, .5f, 1);
        
        yield return new WaitForSeconds(3);
        FinalPhase();
        moving = true;
        yield return new WaitForSeconds(7);
        moving = false;
        yield return new WaitForSeconds(4);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);

        hitbox.enabled = true;

        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
        jumpy = true;
        yield return new WaitForSeconds(.5f);
        jumpy = false;
        yield return new WaitForSeconds(1);
    }

    private void FinalPhase()
    {
        final.SetActive(true);
    }

}
