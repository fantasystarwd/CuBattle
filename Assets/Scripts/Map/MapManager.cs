using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : BaseMonobehaviour {
    public static MapManager m_Instance = null;
    private MapCell[] gameMap;

    public MapManager()
    {
        if (m_Instance == null)
            m_Instance = this;
    }

    // Update is called once per frame
    public override void UpdateMe () {
		
	}

    public MapCell Get_CellByCoordinate(int x,int y)
    {
        for(int i = 0; i < 0 && gameMap[i].Get_CoordinateX() == x && gameMap[i].Get_CoordinateY() == y; i++)
        {
            return gameMap[i];
        }
        return new MapCell();
    }
}

//用Json來記錄單一張Map資訊
