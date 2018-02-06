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
    /// 玩家的現有分數
    /// </summary>
    public int m_Point;

    /// <summary>
    /// 建立玩家的Constructor
    /// </summary>
    /// <param name="name">玩家的名稱</param>
    public Player(string name)
    {
        m_Name = name;
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
}
