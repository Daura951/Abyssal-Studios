using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{

    [SerializeField] private int location;

    
   void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("HI!");
            SceneManager.LoadScene(location);
        }


        else if (collision.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            print(":(");
        }

        //Need to stop colliding with enemy -V
    }
}
