using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadmanSwitch : MonoBehaviour
{
    [SerializeField] private GameObject whatever;


    // Start is called before the first frame update
    void Start()
    {
        whatever.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        whatever.SetActive(true);
    }
}
