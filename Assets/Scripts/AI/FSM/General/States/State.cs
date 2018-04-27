using System.Collections;
using System.Collections.Generic;
using AiManager;
using UnityEngine;
namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/State")]
    public class State: ScriptableObject 
    {
    public Action[] actions;
    public Transition[] transitions;

     public void UpdateState(AiComponentController controller)
    {
        DoActions (controller);
        CheckTransitions (controller);
    }

    private void DoActions(AiComponentController controller)
    {
        for (int i = 0; i < actions.Length; i++) {
            actions [i].Act (controller);
        }
    }
     private void CheckTransitions(AiComponentController controller)
    {
        for (int i = 0; i < transitions.Length; i++) 
        {
            bool decisionSucceeded = transitions[i].decision.Decide (controller);

            if (decisionSucceeded) {
                controller.TransitionToState (transitions[i].trueState);
            } else 
            {
                controller.TransitionToState (transitions[i].falseState);
            }
        }
    }
    }
}