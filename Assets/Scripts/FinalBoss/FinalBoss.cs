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





    // Start is called before the first frame update
    void Start()
    {
        final.SetActive(false);
        //StartCoroutine(Testing());
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
        Instantiate(b1, spawn.position, Quaternion.Euler(0f, 0f, 0f));
    }

    private void FinalPhase()
    {
        final.SetActive(true);
    }

}
