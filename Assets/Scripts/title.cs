using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class title : MonoBehaviour
{
    public string[] fragmentSaveNames = { "Frag0", "Frag1", "Frag2", "Frag3", "Frag4", "Frag5", "Frag6", "Frag7", "Frag8", "Frag9", "Frag10", "Frag11" };

    public int openingScene = 2;

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
        SceneManager.LoadScene(openingScene);
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("Boss1", 0);
        PlayerPrefs.SetInt("Boss2", 0);
        PlayerPrefs.SetInt("Boss3", 0);
        for(int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetInt(fragmentSaveNames[i], 0);
        }
        SceneManager.LoadScene(openingScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void HTP()
    {
        SceneManager.LoadScene(13);
    }

}
