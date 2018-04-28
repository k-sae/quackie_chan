using AiManager;
using UnityEngine;

namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/Dog/Action/Walk")]
    public class Walk : Action
    {
        private Vector3 temp ;
        private  Vector3 point;
        public override void Act(AiComponentController controller)
        {
            if(temp ==null)
            temp = new Vector3();
            if(temp==point)
             point = controller.getRandomMovementPoint();
            
            controller.navMeshAgent.SetDestination(point);
            temp=point;
        }
    }
}