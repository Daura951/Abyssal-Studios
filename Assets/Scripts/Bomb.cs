using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update

    public float detonationTime;
    public player pylr;
    void Start()
    {
        pylr = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detonationTime > 0)
        {
            detonationTime -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
            pylr.setThrown(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ExWall")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            pylr.setThrown(false);
        }
    }
}
