using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutSceneTrans : MonoBehaviour
{
    public VideoPlayer player;
    public int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        player.loopPointReached += loadScene;
    }

    void loadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
