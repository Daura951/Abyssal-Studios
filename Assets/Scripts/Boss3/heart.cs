using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DeleteThis()
    {

        yield return new WaitForSecondsRealtime(5);
        Destroy(this.gameObject);

    }
}
