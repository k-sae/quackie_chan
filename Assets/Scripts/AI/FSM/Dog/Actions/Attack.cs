using AiManager;
using UnityEngine;

namespace AI.FSM
{
    public class Attack : Action
    {
        public override void Act(AiComponentController controller)
        {
            if(checkAttackDistance( controller.chasing, controller.chaser)){
                //TODO: start attack animation 
                //TODO: call the damage script onthe target 
            }           
        }

        private bool checkAttackDistance(Transform target ,  Transform component){
            float dist = Vector3.Distance(target.position,component.position);
            if(dist<=5)
            return true;
            return false;
        }
    }
}