using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private GameObject cam;
    private float shaketime;
    private float shakestrength;
    private float ex;
    private float why;
    private float fade;
    


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
            ceiling.SetActive(false);
            StartCoroutine(Leaving());
            limit.currentHealth = 3;
        }

        if( moving)
        {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed, this.transform.position.y, this.transform.position.z);
        }
        if (jumpy)
        {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * -1, this.transform.position.y, this.transform.position.z);
        }

        if (shaketime > 0)
        {
            shaketime -= Time.deltaTime;

            ex = Random.Range(-1f, 1f) * shakestrength;
            why = Random.Range(-1f, 1f) * shakestrength;

            cam.transform.position += new Vector3(ex, why, 0f);
            shakestrength = Mathf.MoveTowards(shakestrength, 0f, fade * Time.deltaTime);

        }

    }

    private IEnumerator Testing()
    {
        yield return new WaitForSeconds(5f);
        //ScreenShake(.5f, 1f);
        StartCoroutine(NoDicePls());
    }

    private IEnumerator StartFight()
    { 
        yield return new WaitForSeconds(3);
        ScreenShake(.5f, 1f);
        Instantiate(b1, spawn.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private IEnumerator Ghostie()
    {

        ScreenShake(1f, 2f);
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
        ScreenShake(1f, 3f);
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
        yield return new WaitForSeconds(6);
        moving = false;
        yield return new WaitForSeconds(2);
        jumpy = true;
        yield return new WaitForSeconds(3);

        hitbox.enabled = true;

        /*jumpy = true;
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
        */
    }

    private void FinalPhase()
    {
        final.SetActive(true);
    }

    private void ScreenShake(float _tim, float _pow)
    {
        shaketime = _tim;
        shakestrength = _pow;

        fade = shakestrength / shaketime;
    }

}
