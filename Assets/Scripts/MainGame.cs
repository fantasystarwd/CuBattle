using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

    public BaseMonobehaviour[] mainSystemObject = new BaseMonobehaviour[1];

    void Awake(){
        mainSystemObject[0] = GameMainManager.GetInstance();

        for(int i = 0; i < mainSystemObject.Length; i++)
        {
            mainSystemObject[i].AwakeMe();
        }
    }

	// Use this for initialization
	/*void Start () {
        for (int i = 0; i < mainSystemObject.Length; i++)
        {
            mainSystemObject[i].StartMe();
        }
    }

    void FixUpdate()
    {
        for (int i = 0; i < mainSystemObject.Length; i++)
        {
            mainSystemObject[i].FixedUpdateMe();
        }
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < mainSystemObject.Length; i++)
        {
            mainSystemObject[i].UpdateMe();
        }
    }*/
}
