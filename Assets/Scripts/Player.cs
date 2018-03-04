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
    private string m_Name;

    /// <summary>
    /// 玩家的遊戲編號
    /// </summary>
    private int m_PlayerID;

    /// <summary>
    /// 玩家的現有分數
    /// </summary>
    public int m_Point;

    /// <summary>
    /// 建立玩家的Constructor
    /// </summary>
    /// <param name="name">玩家的名稱</param>
    /// <param name="id">玩家的遊戲內id(默認為0)</param>
    public Player(string name,int id = 0)
    {
        m_Name = name;
        m_PlayerID = id;
        m_Point = 0;
    }

    /// <summary>
    /// 取得此位玩家的名稱
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return m_Name;
    }

    public int GetId()
    {
        return m_PlayerID;
    }
}
