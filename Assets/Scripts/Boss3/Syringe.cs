using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    [SerializeField] private GameObject juice;
    [SerializeField] private GameObject syr;
    [SerializeField] private GameObject pump;

    // Start is called before the first frame update
    void Start()
    {
        juice.SetActive(false);
        StartCoroutine(Juicer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Juicer()
    {
        yield return new WaitForSeconds(3);
        juice.SetActive(true);
        StartCoroutine(DeleteThis());

    }

    private IEnumerator DeleteThis()
    {
        yield return new WaitForSeconds(3);
        syr.GetComponent<SpriteRenderer>().enabled = false;
        syr.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(pump);
        yield return new WaitForSecondsRealtime(13);
        Destroy(this.gameObject);

    }
}
