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
        for(int i = 0; i < 12; i++)
        {
            if (PlayerPrefs.GetInt(GameObject.FindGameObjectWithTag("Player").GetComponent<player>().fragmentSaveNames[i]) == 1 && i == Frag)
            {
                Destroy(this.gameObject);
            }
        }
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
            collision.gameObject.GetComponent<player>().UnlockFragment(Frag);
            Destroy(this.gameObject);


        }


        else if (collision.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
}
