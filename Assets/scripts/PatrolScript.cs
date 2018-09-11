﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : EnemyStats {
    
    int currentWP;

     void Awake()
    {
    }




    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (EnemyAi.waypoints.Length == 0) return;
        if(Vector3.Distance(EnemyAi.waypoints[currentWP].transform.position,Enemy.transform.position) < accuracy)
        {
            currentWP++;
            if(currentWP >= EnemyAi.waypoints.Length)
            {
                currentWP = 0;
            }
        }

        var direction = EnemyAi.waypoints[currentWP].transform.position - Enemy.transform.position;
        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime);
        Enemy.transform.Translate(0, 0, Time.deltaTime * moveSpeed);

	
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
	
	}

}
