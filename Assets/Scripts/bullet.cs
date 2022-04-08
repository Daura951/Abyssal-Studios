using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        //Please no touchie the transport layer -V
        Physics2D.IgnoreLayerCollision(6, 7, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        Destroy(this.gameObject);


        else if (collision.gameObject.tag == "Wall")
         Destroy(this.gameObject);

        else if (collision.gameObject.tag == "ExWall")
                Destroy(this.gameObject);

        else if (collision.gameObject.tag == "NWall")
            Destroy(this.gameObject);


        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")

        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        if(collision.gameObject.tag == "EShot")
        {
            Destroy(this.gameObject);
        }

        if(this.gameObject.tag != "EShot")
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().canShoot = true;
    }
}
