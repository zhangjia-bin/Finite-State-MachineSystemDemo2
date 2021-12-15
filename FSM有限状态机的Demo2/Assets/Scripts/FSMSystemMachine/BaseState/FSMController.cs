using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class FSMController : MonoBehaviour
{
    //当前角色状态
    protected StateBase state;
    //所有的角色状态
    protected Dictionary<string, StateBase> states = new Dictionary<string, StateBase>();

    //改变当前角色的状态
    public void ChangeState(Enum stateType, bool cover = false)
    {
        if (state != null && state.stateType.Equals(stateType) && !cover) return;
        if (state != null) { state.OnExit(); }
        state = GetState(stateType);
        state.OnEnter();
    }
    //得到角色状态如果不存在就映射一个新的状态
    private StateBase GetState(Enum stateType)
    {
        var stateKey = stateType.ToString();
        //C#映射出我们需要的类型
        if (states.ContainsKey(stateKey)) return states[stateKey];
        var newState = Activator.CreateInstance(Type.GetType(stateKey)) as StateBase;
        newState.Init(stateType, this);
        states.Add(stateKey, newState);
        return newState;
    }
    //不断更新角色状态
    protected virtual void Update()
    {
        if (state != null)
        {
            state.OnUpdate();
        }
    }
}




