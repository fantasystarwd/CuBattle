using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 遊戲中設置方塊階段
/// </summary>
public class SetCubeStatus : StatusBase {

    public SetCubeStatus(GameMainManager input) : base(input) { }

    public override void StateInitialize()
    {
        Cube.m_Instance.InitPlayerCube();
    }

    public override void StateRelease()
    {
        Cube.m_Instance.ReleaseNowCube();
    }
    public override void StateUpdate(float deltaTime)
    {
        //若玩家有進行按鍵輸入，則在此將輸入直傳進Cube進行動作
    }
}
