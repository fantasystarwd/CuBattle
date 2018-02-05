using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    public static GameMainManager m_Instance = null;
    /// <summary>
    /// 紀錄狀態機中所有狀態的名稱
    /// </summary>
    public enum GameStatus { NONE = 0, INIT = 1, STARTING, CHOOSEPROP, SETPROP, AWARD, SETCUBE, ENDGAME };

    private GameStatus m_CurrentStatus = GameStatus.NONE;

    private StatusBase m_ActiveStatus = null;

    private List<StatusBase> m_StatusList;

    private Player m_ActivePlayer = null;

    private List<Player> m_PlayerList;

    // Use this for initialization
    void Start()
    {
        m_Instance = this;

        m_StatusList = new List<StatusBase>();

        m_StatusList[(int)GameStatus.INIT] = new InitStatus(this);

        m_PlayerList = new List<Player>(4);

        for (int i = 0; i < 4; i++)
        {
            m_PlayerList[i] = new Player("Ican");
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_ActiveStatus.StateUpdate();
    }

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

    public GameStatus GetCurrentState()
    {
        return m_CurrentStatus;
    }
}
