using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该状态是追击player的状态
/// </summary>
public class PlayerAttackState : StateBase
{
    public PlayerController controller;
    public override void Init(Enum stateType, FSMController controller1)
    {
        this.stateType = stateType;
        controller = controller1 as PlayerController;
        controller.animator.SetBool("run", true);
    }

    public override void OnEnter()
    {
        controller.animator.SetBool("run", true);
    }
    //这个状态改变后，调用一下这个转态
    public override void OnExit()
    {
      
    }

    public override void OnUpdate()
    {
        if (Vector3.Distance(controller.transform.position,controller.enemy.position)<=2f)
        {
            //改变人物的状态
            controller.ChangeState(PlayerStateType.PlayerIdleState);
        }
        else if(Vector3.Distance(controller.transform.position, controller.enemy.position) <= 15f)
        {
            //追击目标人物
            controller.gameObject.transform.LookAt(controller.enemy.position);
            controller.transform.Translate(Vector3.forward*Time.deltaTime*controller.PlayerSpeed);

        }
        else
        {
            //大于10的距离范围，敌人继续巡逻
            controller.ChangeState(PlayerStateType.PlayerRunState);
        }
    }
}
