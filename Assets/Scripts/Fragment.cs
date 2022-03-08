using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    [SerializeField] private int Frag;
    private int collect;


    void Start()
    {
        
       /* collect = GameObject.FindWithTag("player").GetComponent<Fraglog>().CheckFrag(Frag);
        if(collect > 0)
        {
            Destroy(this.gameObject);
        }*/ 

    }
    
    void Update()
    {

        collect = GameObject.FindWithTag("Player").GetComponent<Fraglog>().CheckFrag(Frag);
        if (collect > 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Fraglog>().UpdateFrag(Frag);
        }


        else if (collision.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
}
