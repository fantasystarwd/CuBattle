using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 遊戲開始前初始化遊戲設定狀態
/// 基本上這狀態只會使用初始化function後便跳入下個狀態
/// </summary>
public class InitStatus : StatusBase {

    public InitStatus(GameMainManager input) : base(input) {}

    public override void StateInitialize() {


        GameMainManager.m_Instance.Set_Status(GameMainManager.GameStatus.STARTING);
    }

    public override void StateRelease()
    {

    }
    public override void StateUpdate(float deltaTime)
    {

    }
}
