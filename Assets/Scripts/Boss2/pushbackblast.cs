using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbackblast : MonoBehaviour
{
    [SerializeField] private int speed;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 13, true);
        //Add layer collisons at some point - V
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DeleteThis());
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(this.gameObject);

        else if (collision.gameObject.tag == "Wall")
            Destroy(this.gameObject);

        else if (collision.gameObject.tag == "ExWall")
            Destroy(this.gameObject);

        else if (collision.gameObject.tag == "NWall")
            Destroy(this.gameObject);
    }

    private IEnumerator DeleteThis()
    {

        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }
}
