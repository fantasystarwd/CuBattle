using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour {

    public static ScenesManager manager;

    /// <summary>
    /// 在遊戲啟動時先行創立管理場景的SceneManager，並確立整場遊戲只有一個manager
    /// </summary>
    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else if(manager != this)
        {
            Destroy(gameObject);
        }
    }

    public void SceneSwitchs()
    {
        /* EX:
        if (Application.loadedLevelName == "UI")
        {
            Application.LoadLevel("GameScene");
        }
        else if (Application.loadedLevelName == "GameScene")
        {
            Application.LoadLevel("UI");
        }
        */
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
