using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : BaseMonobehaviour
{
    public static GameMainManager m_Instance = null;

    public static GameMainManager GetInstance()
    {
        if(m_Instance == null)
        {
            m_Instance = new GameMainManager();
        }

        return m_Instance;
    }
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
    private GameStatus mCurrentStatus = GameStatus.NONE;

    /// <summary>
    /// 用於保存當下正在使用的狀態機
    /// </summary>
    private StatusBase mActiveStatus = null;

    /// <summary>
    /// 用於紀錄遊戲中所有用到的狀態
    /// </summary>
    private List<StatusBase> mStatusList;

    /// <summary>
    /// 用於紀錄目前正在執行動作的玩家，目前正在考慮遇到多人時地處理方式
    /// </summary>
    private Player mActivePlayer = null;

    /// <summary>
    /// 用於紀錄所有玩家的資料
    /// </summary>
    private List<Player> mPlayerList;

    public override void AwakeMe()
    {
        Debug.Log("Awake!");
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public override void StartMe()
    {

        //建立所有狀態機
        mStatusList = new List<StatusBase>();

        mStatusList[(int)GameStatus.INIT] = new InitStatus(this);
        mStatusList[(int)GameStatus.STARTING] = new StartingStatus(this);
        mStatusList[(int)GameStatus.CHOOSEPROP] = new ChoosePropStatus(this);
        mStatusList[(int)GameStatus.SETPROP] = new SetPropStatus(this);
        mStatusList[(int)GameStatus.AWARD] = new AwardStatus(this);
        mStatusList[(int)GameStatus.SETCUBE] = new SetCubeStatus(this);
        mStatusList[(int)GameStatus.ENDGAME] = new EndGameStatus(this);

        //建立所有玩家
        mPlayerList = new List<Player>(PlayerInitSetting.PlayerAmount);

        for (int i = 0; i < PlayerInitSetting.PlayerAmount; i++)
        {
            mPlayerList[i] = new Player(PlayerInitSetting.PlayerName[i]);
        }
    }

    // Update is called once per frame
    public override void UpdateMe()
    {
        mActiveStatus.StateUpdate(Time.deltaTime);
    }

    /// <summary>
    /// 用於當前狀態機需要更換狀態的method
    /// </summary>
    /// <param name="state">接下來需要置換的狀態機</param>
    public void Set_Status(GameStatus state)
    {
        if (mActiveStatus != null)
        {
            mActiveStatus.StateRelease();
            mActiveStatus = null;
        }

        if (mStatusList[(int)state] != null)
        {
            mActiveStatus = mStatusList[(int)state];
            mActiveStatus.StateInitialize();
            mCurrentStatus = state;
        }
    }

    /// <summary>
    /// 用於更改當前正在操作的玩家
    /// </summary>
    /// <param name="name"></param>
    public void Set_Player(string name)
    {
        for (int i = 0; i < 4; i++)
        {
            if (name == mPlayerList[i].Get_Name())
            {
                mPlayerList[i] = mActivePlayer;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if(name == mPlayerList[i].Get_Name())
            {
                mActivePlayer = mPlayerList[i];
            }
        }
    }

    /// <summary>
    /// 取得目前正在執行的狀態
    /// </summary>
    /// <returns></returns>
    public GameStatus Get_CurrentState()
    {
        return mCurrentStatus;
    }

    /// <summary>
    /// 取得目前正在執行動作的玩家
    /// </summary>
    /// <returns></returns>
    public Player Get_CurrentPlayer()
    {
        return mActivePlayer;
    }

    public Player Get_PlayerById(int playerId)
    {
        for (int i = 0; i < 4 && mPlayerList[i].Get_Id() == playerId; i++)
        {
            return mPlayerList[i];
        }
        return null;
    }
}
