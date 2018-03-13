using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家的基本單位，紀錄單位玩家的種種數值
/// </summary>
public class Player {
    /// <summary>
    /// 玩家的名稱
    /// </summary>
    private string mName;

    /// <summary>
    /// 玩家的遊戲編號
    /// </summary>
    private int mPlayerID;

    /// <summary>
    /// 玩家的現有分數
    /// </summary>
    public int mPoint;

    /// <summary>
    /// 建立玩家的Constructor
    /// </summary>
    /// <param name="name">玩家的名稱</param>
    /// <param name="id">玩家的遊戲內id(默認為0)</param>
    public Player(string name,int id = 0)
    {
        mName = name;
        mPlayerID = id;
        mPoint = 0;
    }

    /// <summary>
    /// 取得此位玩家的名稱
    /// </summary>
    /// <returns></returns>
    public string Get_Name()
    {
        return mName;
    }

    public int Get_Id()
    {
        return mPlayerID;
    }
}
