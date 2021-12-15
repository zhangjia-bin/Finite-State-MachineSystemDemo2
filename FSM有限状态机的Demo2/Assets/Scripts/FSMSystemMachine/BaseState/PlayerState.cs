using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : StateBase
{
    PlayerController controller;
    public override void Init(Enum stateType, FSMController controller1)
    {
        this.stateType = stateType;
        controller = controller1 as PlayerController;
    }

    public override void OnEnter()
    {
     
    }

    public override void OnExit()
    {
       
    }

    public override void OnUpdate()
    {
      
    }
}
