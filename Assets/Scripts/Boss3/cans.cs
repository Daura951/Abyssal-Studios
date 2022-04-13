using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cans : MonoBehaviour
{
    [SerializeField] private int speed;
    private int damage;


    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        StartCoroutine(DeleteThis());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")

        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

    }
    private IEnumerator DeleteThis()
    {

        yield return new WaitForSeconds(20);
        Destroy(this.gameObject);


    }
}
