using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCell {
    public enum MapCellStatus {
        /// <summary>
         /// 一般土地
         /// </summary>
        NORMAL = 0,
        OBSTACLE,
        SPECIAL,
        CANSURRENDED,
        NONE
    };

    private int ownerId;
    private MapCellStatus CellStatus = MapCellStatus.NONE;
    private int occupyPoint;
    private int coordinateX;
    private int coordinateY;

    public MapCell()
    {

    }

    public int GetCoordinateX()
    {
        return coordinateX;
    }

    public int GetCoordinateY()
    {
        return coordinateY;
    }
}


