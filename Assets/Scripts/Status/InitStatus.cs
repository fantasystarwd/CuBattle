using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 遊戲開始前初始畫遊戲設定狀態
/// </summary>
public class InitStatus : StatusBase {

    public InitStatus(GameMainManager input) : base(input) {}

    public override void StateInitialize() {


        GameMainManager.m_Instance.SetStatus(GameMainManager.GameStatus.STARTING);
    }

    public override void StateRelease()
    {

    }
    public override void StateUpdate(float deltaTime)
    {

    }
}
