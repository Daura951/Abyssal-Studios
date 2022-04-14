using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D body;
    private Vector3 lastVelocity;

    [SerializeField] private float testx;
    [SerializeField] private float testy;
    [SerializeField] private float lifespan;



    // Start is called before the first frame update
    void Start()
    {
        body.AddForce(new Vector2(testx, testy));
        StartCoroutine(DeleteThis());
        Physics2D.IgnoreLayerCollision(16, 17, true);

    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = body.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        body.velocity = direction * Mathf.Max(speed, 0f);

    }

    private IEnumerator DeleteThis()
    {
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(16, 17, false);
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);

    }
}
