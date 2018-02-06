using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusBase {

    protected GameMainManager m_manager = null;

    public StatusBase(GameMainManager input)
    {
        m_manager = input;
    }
    /// <summary>
    /// 狀態機進入前初始化用
    /// </summary>
    public abstract void StateInitialize();
    /// <summary>
    /// 狀態機釋放資源
    /// </summary>
    public abstract void StateRelease();
    /// <summary>
    /// 狀態機依照每Frame更新資訊
    /// </summary>
    public abstract void StateUpdate(float deltaTime);
}
