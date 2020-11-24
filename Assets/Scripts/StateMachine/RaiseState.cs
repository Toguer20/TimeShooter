using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseState : StateMachineBehaviour
{
    private StackManager sm;
    private float cooldown;
    private float nextAction = 0;
    private int counter = 0;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cooldown = GameManager.gm.raiseStateCooldown;
        if (sm == null)
            sm = animator.GetComponent<StackManager>();
        nextAction = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextAction)
        {
            sm.NumberOfObjects = sm.NumberOfObjects + sm.IncrementNumObjects;
            nextAction = Time.time + cooldown;
            counter++;
        }
        if (counter == 5)
            animator.SetTrigger("stopRaiseDif");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
