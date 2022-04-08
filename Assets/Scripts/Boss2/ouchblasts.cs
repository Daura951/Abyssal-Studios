using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ouchblasts : MonoBehaviour
{
    [SerializeField] private int speed;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        Physics2D.IgnoreLayerCollision(0, 13, true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        StartCoroutine(DeleteThis());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")

        {       
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }
    
    private IEnumerator DeleteThis()
    {

        yield return new WaitForSeconds(30);
        Destroy(this.gameObject);

    }
}
