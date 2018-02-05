using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusBase {

    protected GameMainManager m_manager = null;

    public StatusBase(GameMainManager input)
    {
        m_manager = input;
    }

    public abstract void StateInitialize();
    public abstract void StateUpdate();
    public abstract void StateRelease();
    public abstract void StateUpdate(int deltaTime);
}
