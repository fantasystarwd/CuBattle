using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO : MonoBehaviour
{
    /// <summary>
    /// IO參考signal and slot
    /// </summary>

    public static bool TRIGGER = false;//是否觸發按鍵//改成列表///多按鍵觸發
    public string tempName;
    //public inputStatus status = inputStatus.TRIGGER;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (TRIGGER/*TRIGGER被觸發的話，doSomething*/)
        {
            //do something
            Get_Player(tempName);
        }
    }
    /// </summary>
    /// 哪位玩家觸發IO事件，去跟gameManager要
    /// </summary>
    public string Get_Player(string name)
    {
        return name;
    }
    /// <summary>
    /// 滑鼠現在的座標
    /// </summary>
    public void Get_Mouse_Position()
    {

    }
    /// <summary>
    /// 計算滑鼠位移
    /// </summary>
    private void Displacement()
    {

    }
    public void Get_Displacement()
    {

    }
    /// <summary>
    /// 按鍵之間的延遲時間
    /// </summary>
    public void Delay_Time()
    {

    }
    /// <summary>
    /// 按鍵動態設置
    /// </summary>
    public void Set_Key_Control()
    {

    }
}
