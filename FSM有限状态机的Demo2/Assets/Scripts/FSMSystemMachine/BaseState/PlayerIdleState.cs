using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : StateBase
{
    PlayerController controller;

    AnimatorTransitionInfo animatorInfo;
    public override void Init(Enum stateType, FSMController controller1)
    {
        
        this.stateType = stateType;
        controller = controller1 as PlayerController;
        animatorInfo = controller.animator.GetAnimatorTransitionInfo(0);
        controller.animator.SetBool("run", false);
    }

    public override void OnEnter()
    {
        controller.animator.SetBool("run", false);
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (Vector3.Distance(controller.transform.position,controller.enemy.position)>2f)
        {
            //改变状态不攻击敌人，改为追击敌人
            controller.ChangeState(PlayerStateType.PlayerAttackState);
        }
        else
        {
            //看向主角，播放攻击动画
            controller.transform.LookAt(controller.enemy.transform);
            if (!animatorInfo.IsName("attack"))
            {
                controller.animator.SetTrigger("attack");
            }
            //if (animatorInfo.normalizedTime>=1.0f)
            //{
            //    controller.animator.SetTrigger("attack");
            //}

        }
    }
}
