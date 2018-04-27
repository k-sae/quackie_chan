using AiManager;
using UnityEngine;

namespace AI.FSM
{
    public class AttackCat : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
            if (controller.isChaseing){
                Transform target = controller.chasing;
            }
            return false;
        }
    }
}