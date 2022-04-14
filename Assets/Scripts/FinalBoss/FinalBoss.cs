using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{

    [SerializeField] private Health limit;
    [SerializeField] private Animator anims;
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject final;

    [SerializeField] private GameObject b1;
    [SerializeField] private GameObject b2;
    [SerializeField] private GameObject ceiling;
    [SerializeField] private GameObject b3;





    // Start is called before the first frame update
    void Start()
    {
        ceiling.SetActive(false);
        final.SetActive(false);

       // StartCoroutine(Testing());
    }

    // Update is called once per frame
    void Update()
    {
        /*if(limit.currentHealth == 3)
        {
            //activate final phase
        }*/


    }

    private IEnumerator Testing()
    {

        yield return new WaitForSeconds(3);
        ceiling.SetActive(true);
        Instantiate(b3, spawn.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private void FinalPhase()
    {
        final.SetActive(true);
    }

}
