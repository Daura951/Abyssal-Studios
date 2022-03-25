using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbshot : MonoBehaviour
{
    [SerializeField] private int speed;
    private int damage = 1;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 7, true);
        Physics2D.IgnoreLayerCollision(13, 8, true);
        Physics2D.IgnoreLayerCollision(13, 13, true);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
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


        if (collision.gameObject.tag == "Player")

        {
            //Destroy(this.gameObject);
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
