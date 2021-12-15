using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FSMController
{
    public List<Transform> points = new List<Transform>();
    public Transform enemy;
    public Animator animator;
    //人物运动的速度
    [Tooltip("player运动的速度")]
    public float PlayerSpeed=5;
    private void Start()
    {
        animator = GetComponent<Animator>();
        ChangeState(PlayerStateType.PlayerRunState);
      
    }

    int index = 0;
   
    protected override void Update()
    {
        base.Update();
    }
}

public enum PlayerStateType
{
    PlayerIdleState = 0,
    PlayerRunState = 1,
    PlayerAttackState = 2,
}

