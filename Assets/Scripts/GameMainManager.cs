using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    public static GameMainManager m_Instance = null;
    /// <summary>
    /// 紀錄狀態機中所有狀態的名稱
    /// </summary>
    public enum GameStatus {
        NONE = 0,//無狀態，通常為遊戲啟動時的初始設置
        INIT = 1,//遊戲開始前初始畫遊戲設定狀態
        STARTING,//遊戲開始當下狀態
        CHOOSEPROP,//遊戲中的選擇道具階段
        SETPROP,//遊戲中放置道具階段
        AWARD,//遊戲中遇到觸發道具階段
        SETCUBE,//遊戲中設置方塊階段
        ENDGAME//遊戲結束時狀態
    };

    /// <summary>
    /// 用於紀錄線下遊戲的狀態為何?
    /// </summary>
    private GameStatus m_CurrentStatus = GameStatus.NONE;

    /// <summary>
    /// 用於保存當下正在使用的狀態機
    /// </summary>
    private StatusBase m_ActiveStatus = null;

    /// <summary>
    /// 用於紀錄遊戲中所有用到的狀態
    /// </summary>
    private List<StatusBase> m_StatusList;

    /// <summary>
    /// 用於紀錄目前正在執行動作的玩家，目前正在考慮遇到多人時地處理方式
    /// </summary>
    private Player m_ActivePlayer = null;

    /// <summary>
    /// 用於紀錄所有玩家的資料
    /// </summary>
    private List<Player> m_PlayerList;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //
        m_Instance = this;

        //建立所有狀態機
        m_StatusList = new List<StatusBase>();

        m_StatusList[(int)GameStatus.INIT] = new InitStatus(this);
        m_StatusList[(int)GameStatus.STARTING] = new StartingStatus(this);
        m_StatusList[(int)GameStatus.CHOOSEPROP] = new ChoosePropStatus(this);
        m_StatusList[(int)GameStatus.SETPROP] = new SetPropStatus(this);
        m_StatusList[(int)GameStatus.AWARD] = new AwardStatus(this);
        m_StatusList[(int)GameStatus.SETCUBE] = new SetCubeStatus(this);
        m_StatusList[(int)GameStatus.ENDGAME] = new EndGameStatus(this);

        //建立所有玩家
        m_PlayerList = new List<Player>(PlayerInitSetting.PlayerAmount);

        for (int i = 0; i < PlayerInitSetting.PlayerAmount; i++)
        {
            m_PlayerList[i] = new Player(PlayerInitSetting.PlayerName[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_ActiveStatus.StateUpdate(Time.deltaTime);
    }

    /// <summary>
    /// 用於當前狀態機需要更換狀態的method
    /// </summary>
    /// <param name="state">接下來需要置換的狀態機</param>
    public void SetStatus(GameStatus state)
    {
        if (m_ActiveStatus != null)
        {
            m_ActiveStatus.StateRelease();
            m_ActiveStatus = null;
        }

        if (m_StatusList[(int)state] != null)
        {
            m_ActiveStatus = m_StatusList[(int)state];
            m_ActiveStatus.StateInitialize();
            m_CurrentStatus = state;
        }
    }

    /// <summary>
    /// 用於更改當前正在操作的玩家
    /// </summary>
    /// <param name="name"></param>
    public void SetPlayer(string name)
    {
        for (int i = 0; i < 4; i++)
        {
            if (name == m_PlayerList[i].GetName())
            {
                m_PlayerList[i] = m_ActivePlayer;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if(name == m_PlayerList[i].GetName())
            {
                m_ActivePlayer = m_PlayerList[i];
            }
        }
    }

    /// <summary>
    /// 取得目前正在執行的狀態
    /// </summary>
    /// <returns></returns>
    public GameStatus GetCurrentState()
    {
        return m_CurrentStatus;
    }

    /// <summary>
    /// 取得目前正在執行動作的玩家
    /// </summary>
    /// <returns></returns>
    public Player GetCurrentPlayer()
    {
        return m_ActivePlayer;
    }
}
