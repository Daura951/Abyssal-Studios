using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefs.GetInt("Boss1") + " " + PlayerPrefs.GetInt("Boss2") + " " + PlayerPrefs.GetInt("Boss3"));
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Boss1") == 1 && PlayerPrefs.GetInt("Boss2") == 1 && PlayerPrefs.GetInt("Boss3") == 1)
        {
            SceneManager.LoadScene(14);
        }
    }
}
