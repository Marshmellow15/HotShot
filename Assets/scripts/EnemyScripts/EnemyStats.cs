﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStats : StateMachineBehaviour 
    {
        public GameObject Enemy;
        public GameObject Player;
        public EnemyAi EnemyAi;
        public float moveSpeed = 7;
        public float lookRange = 40f;
        public float lookRadius = 1f;
        public float accuracy = 3.0f;
        public float attackRange = 1f;
        public int   attackDamage = 50;

        public float searchDuration = 4f;
        public float TurnSpeed = 6f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy = animator.gameObject;
        EnemyAi = Enemy.GetComponent<EnemyAi>();
        Player = EnemyAi.GetPlayer();
    }


}