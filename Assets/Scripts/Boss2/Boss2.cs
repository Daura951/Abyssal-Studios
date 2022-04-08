using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    // Movement -V
    //[SerializeField] private Transform leftBound;
    //[SerializeField] private Transform rightBound;
    //[SerializeField] private Transform upperBound;
    //[SerializeField] private Transform lowerBound;

    //[SerializeField] private Transform enemyleft;
    //[SerializeField] private Transform enemyright;

    //Pushback -V
    [SerializeField] private GameObject blasts;
    [SerializeField] private Transform center;

    //Downward attacks -V
    [SerializeField] private GameObject ouch;

    //Gizmos stuff - V
    [SerializeField] private float range;
    [SerializeField] private float vert;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    //Forward Shot -V
    [SerializeField] private Transform front;
    [SerializeField] private Transform player;

    //Scene Change -V
    [SerializeField] private GameObject mainPlatform;
    [SerializeField] private GameObject section1;
    [SerializeField] private GameObject section2;
    [SerializeField] private GameObject section3;
    private int scene;




    void Start()
    {
        SceneChange();
    }
    // Update is called once per frame
    void Update()
    {

        
        /* if (PlayerInSight())
        {
            anim.SetTrigger("sight");
        }

        else
        {
            anim.ResetTrigger("sight");
        }*/
    }

    //After enough damage knocks player away
    private void PushBack()
    {
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, 85f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, -85f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, 45f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, -45f), this.transform);
        Instantiate(blasts, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);

        //Ending anim trigger here -V
    }


    
    //attacks player while climbing up
    private void DownwardShot()
    {
        StartCoroutine(Shooting());
    }

    //Attacks player on main platform
    private void SwoopingAttack()
    {

    }

    //another main platform attack with more vertical less pararabole
    private void WavySwoop()
    {

    }

    private void ForwardShot()
    {
        //have enemy look toward player and fire straight at them
    }

    private void SceneChange()
    {
        StartCoroutine(Leave());
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * vert, boxCollider.bounds.size.z));
    }

    private IEnumerator Shooting()
    {
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2); 
        Instantiate(ouch, center.position, Quaternion.Euler(0f, 0f, 0f), this.transform);
        yield return new WaitForSeconds(2);

        //add anim end trigger - V
    }

    private IEnumerator Leave()
    {
        PushBack();
        yield return new WaitForSeconds(1);
        mainPlatform.SetActive(false);
        //edit to put things back
       
    }

}
