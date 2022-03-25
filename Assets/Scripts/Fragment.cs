using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    [SerializeField] private int Frag;
    private int collect;
    public GameObject FragUI;



    void Start()
    {

    }
    
    void Update()
    {

        collect = GameObject.FindGameObjectWithTag("Player").GetComponent<Fraglog>().CheckFrag(Frag);
        if (collect > 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            collision.gameObject.GetComponent<Fraglog>().UpdateFrag(Frag);
            Destroy(this.gameObject);


        }


        else if (collision.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
}
