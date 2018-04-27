using System.Collections.Generic;
using AiManager;
using UnityEngine;

namespace AI.FSM
{
    public class AttackPlayer : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
            List<AiComponent> agents = controller.getAgentsInRange(controller.brain.getSensorRange());
            if(agents.Count>1)
            foreach(AiComponent agent in agents)
                if(agent.getController().tag == "CAT")
                return false;
            
            if(Vector3.Distance(controller.transform.position,PlayerController.playerTransform.position)<=controller.brain.getSensorRange())
            return true;
            return false;
        }
    }
}