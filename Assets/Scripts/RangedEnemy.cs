using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject shot;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;

    private Patrols enemyPatrol;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInChildren<Patrols>();
    }

    private void Update()
    {

        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }

        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        if (this.transform.position.x < shotPoint.position.x)
        {
            Instantiate(shot, shotPoint.position, Quaternion.Euler(0f, 0f, 0f));

        }
        else
        {
            Instantiate(shot, shotPoint.position, Quaternion.Euler(0f, 0f, 180f));
        }
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
              Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
              new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
              0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void EndAttack()
    {
        anim.ResetTrigger("Attack");
    }
}
