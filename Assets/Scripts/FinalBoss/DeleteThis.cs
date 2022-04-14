using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteThis : MonoBehaviour
{
    [SerializeField] private float lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        StartCoroutine(Delete());
    }

    private IEnumerator Delete()
    {

        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);

    }
}
