using AiManager;
using UnityEngine;

namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/Dog/Action/AttackPlayer")]
    public class Attack : Action
    {
        public override void Act(AiComponentController controller)
        {
           // if(checkAttackDistance( controller.chasing, controller.chaser)){
                //TODO: start attack animation 
                //TODO: call the damage script onthe target 
            //}      
            Debug.Log("وحياه امك تعمل اتاك");
           if(controller.chasing!=null)
            controller.navMeshAgent.SetDestination(controller.chasing.position);     
        }

        private bool checkAttackDistance(Transform target ,  Transform component){
            if(target==null || component==null)
            return false;
            float dist = Vector3.Distance(target.position,component.position);
            if(dist<=5)
            return true;
            return false;
        }
    }
}