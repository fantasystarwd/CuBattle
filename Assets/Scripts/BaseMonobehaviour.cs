using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonobehaviour : MonoBehaviour
{
    public virtual void AwakeMe() { }
    public virtual void StartMe() { }
    protected virtual void OnEnableMe() { }
    protected virtual void OnDisableMe() { }
    public virtual void UpdateMe() { }
    public virtual void LateUpdateMe() { }
    public virtual void FixedUpdateMe() { }
}
