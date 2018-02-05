using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    private string m_Name;
    private int m_Point;


    public Player(string name)
    {
        m_Name = name;
        m_Point = 0;
    }

    public string GetName()
    {
        return m_Name;
    }
}
