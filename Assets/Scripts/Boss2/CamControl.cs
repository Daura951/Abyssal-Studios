using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;
    [SerializeField] private float range;
    [SerializeField] private float vert;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private int holdup = 1;

    // Start is called before the first frame update
    void Start()
    {
        holdup = 1;
        player.SetActive(false);
        boss.SetActive(true);
        StartCoroutine(ShowOff());
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInSight())
        {
            player.SetActive(false);
            boss.SetActive(true);
        }
        else if (holdup != 1)
        {
            player.SetActive(true);
            boss.SetActive(false);
        }

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
              Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
              new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z),
              0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.green;
       Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z));
    }

    private IEnumerator ShowOff()
    {

        yield return new WaitForSeconds(5);
        player.SetActive(true);
        boss.SetActive(false);
        holdup = 0;

    }
}
