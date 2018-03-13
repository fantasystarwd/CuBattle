using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : BaseMonobehaviour {
    public static Cube m_Instance = null;
    /// <summary>
    /// 記錄所有方塊會使用到的動作
    /// </summary>
    public enum CubeAction {
        NONE = 0,//無動作
        UPMOVE,//方塊向上移動
        DOWNMOVE,//方塊向下移動
        LEFTMOVE,//方塊向左移動
        RIGHTMOVE,//方塊向又移動
        LEFTROTATE,//方塊向左旋轉
        RIGHTROTATE,//方塊向右旋轉
        CHANGECUBE,//交換現行使用方塊
        PUTACUBE//放置現行使用方塊
    };

    /// <summary>
    /// 用來儲存所有方塊種類的陣列
    /// </summary>
    private GameObject[] cubeBase = new GameObject[11];

    /// <summary>
    /// 用來儲存當前玩家可使用的方塊的陣列
    /// </summary>
    private int[] canUseCube = null;
    /// <summary>
    /// 用來儲存當前玩家正在使用的方塊
    /// </summary>
    private GameObject activeCube;

    /// <summary>
    /// 初始化11種cube形狀的物件
    /// </summary>
    public Cube() {
        m_Instance = this;

        //初始化cubeBase
    }

    /// <summary>
    /// 用來釋放目前玩家所使用的方塊
    /// </summary>
    public void Release_Now_Cube()
    {
        canUseCube = null;
        GameObject.Destroy(activeCube);
    }

    /// <summary>
    /// 回傳當前玩家在使用的方塊物件
    /// </summary>
    /// <returns></returns>
    public GameObject Get_NowUseCube()
    {
        return activeCube;
    }

    /// <summary>
    /// 當玩家要開始擺放方塊前須先進行初始化
    /// </summary>
    public void Init_PlayerCube()
    {
        if(canUseCube != null)
        {
            canUseCube = null;
        }
        canUseCube = new int[3];

        for (int i = 0; i < 3; i++)
        {
            canUseCube[i] = Random.Range(0, 11);
        }

        activeCube = GameObject.Instantiate(cubeBase[canUseCube[0]]);
    }

    /// <summary>
    /// 用來處理當偵測到玩家有進行按鍵輸入時，方塊須執行的動作
    /// </summary>
    /// <param name="inputAction">當前玩家輸入的動作</param>
    public void Cube_ActionDo(CubeAction inputAction)
    {
        switch (inputAction)
        {
            case CubeAction.UPMOVE:
                break;
            case CubeAction.DOWNMOVE:
                break;
            case CubeAction.LEFTMOVE:
                break;
            case CubeAction.RIGHTMOVE:
                break;
            case CubeAction.LEFTROTATE:
                break;
            case CubeAction.RIGHTROTATE:
                break;
            case CubeAction.CHANGECUBE:
                break;
            case CubeAction.PUTACUBE:
                break;
            default:
                break;
        }
    }

}
