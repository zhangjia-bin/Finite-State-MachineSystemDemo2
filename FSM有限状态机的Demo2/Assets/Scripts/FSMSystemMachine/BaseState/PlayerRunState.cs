using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 该状态是巡逻状态
/// </summary>
public class PlayerRunState : StateBase
{

    public List<Transform> points = new List<Transform>();
    PlayerController controller;
    public override void Init(Enum stateType, FSMController controller1)
    {
        this.stateType = stateType;
        controller = controller1 as PlayerController;
        controller.animator.SetBool("run", true);
        points = controller.points;
    }

    //进入这个状态机，第二个运行该状态
    public override void OnEnter()
    {
        controller.animator.SetBool("run", true);

    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        //巡逻
        StateRun();
    }
    int index=0;
    public void StateRun()
    {
        if (Vector3.Distance(controller.gameObject.transform.position,controller.enemy.transform.position) <= 10f)
        {
            //改变状态追击敌人
            controller.ChangeState(PlayerStateType.PlayerAttackState);
        }
        else
        {
            if (Vector3.Distance(controller.gameObject.transform.position, points[index].position) <= 0.1f)
            {
                index++;
                index = index % points.Count;
            }
            else
            {
                //看向目标点
                controller.gameObject.transform.LookAt(points[index]);
                //向前移动
                controller.gameObject.transform.Translate(Vector3.forward * Time.deltaTime *controller.PlayerSpeed);
            }

        }

    }


}
