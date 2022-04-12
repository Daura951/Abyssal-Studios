using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class title : MonoBehaviour
{
    public string[] fragmentSaveNames = { "Frag0", "Frag1", "Frag2", "Frag3", "Frag4", "Frag5", "Frag6", "Frag7", "Frag8", "Frag9", "Frag10", "Frag11" };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGame()
    {
        SceneManager.LoadScene(7);
    }

    public void newGame()
    {
        for(int i = 0; i < 12; i++)
        {
            PlayerPrefs.SetInt(fragmentSaveNames[i], 0);
            SceneManager.LoadScene(7);
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
