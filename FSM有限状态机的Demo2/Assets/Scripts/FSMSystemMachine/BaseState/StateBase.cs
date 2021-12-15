using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class StateBase 
{
    public Enum stateType;

    public abstract void Init(Enum stateType, FSMController controller);

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
}

