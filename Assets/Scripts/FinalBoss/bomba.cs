using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    [SerializeField] private GameObject adios;
    [SerializeField] private GameObject adios2;

    [SerializeField] private GameObject cam;
    private float shaketime;
    private float shakestrength;
    private float ex;
    private float why;
    private float fade;

    private AudioSource bombSource;

    // Start is called before the first frame update
    void Start()
    {
        bombSource = GameObject.FindGameObjectWithTag("BombSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shaketime > 0)
        {
            shaketime -= Time.deltaTime;

            ex = Random.Range(-1f, 1f) * shakestrength;
            why = Random.Range(-1f, 1f) * shakestrength;

            cam.transform.position += new Vector3(ex, why, 0f);
            shakestrength = Mathf.MoveTowards(shakestrength, 0f, fade * Time.deltaTime);

        }
    }

    private void OnEnable()
    {
        StartCoroutine(Perish());
    }

    private IEnumerator Perish()
    {

        yield return new WaitForSecondsRealtime(5);
        bombSource.Play();
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        ScreenShake(2f, 7f);
        adios.SetActive(false);
        adios2.SetActive(false);
        yield return new WaitForSecondsRealtime(10);
        Destroy(this.gameObject);

    }

    private void ScreenShake(float _tim, float _pow)
    {
        shaketime = _tim;
        shakestrength = _pow;

        fade = shakestrength / shaketime;
    }

}
