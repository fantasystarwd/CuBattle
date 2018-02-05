using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneName : ScriptableObject{

    public string initScene;
    public SceneNameHolder[] scenes;
}

[System.Serializable]
public class SceneNameHolder
{
    public string own;
    public string loading;
    public bool isAdditiveLoading;
}
