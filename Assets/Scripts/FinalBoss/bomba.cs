using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    [SerializeField] private GameObject adios;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Perish());
    }

    private IEnumerator Perish()
    {

        yield return new WaitForSecondsRealtime(5);
        adios.SetActive(false);
        Destroy(this.gameObject);

    }
}
