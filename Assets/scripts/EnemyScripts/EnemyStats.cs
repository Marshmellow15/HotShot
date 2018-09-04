using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStats : StateMachineBehaviour 
    {
        public GameObject Enemy;
        public GameObject Player;
        public float moveSpeed = 7;
        public float lookRange = 40f;
        public float lookRadius = 1f;
        public float accuracy = 3.0f;
        public float attackRange = 1f;
        public float attackRate = 1f;
        public float attackForce = 15f;
        public int   attackDamage = 50;

        public float searchDuration = 4f;
        public float TurnSpeed = 6f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy = animator.gameObject;
        Player = Enemy.GetComponent<EnemyAi>().GetPlayer();
    }


}