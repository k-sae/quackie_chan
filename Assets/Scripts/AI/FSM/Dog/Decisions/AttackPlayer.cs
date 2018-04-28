using System.Collections.Generic;
using AiManager;
using UnityEngine;

namespace AI.FSM
{
     [CreateAssetMenu (menuName = "FSM/Dog/Decision/AttackPlayer")]
    public class AttackPlayer : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
           if(PlayerController.playerTransform!=null&&controller.brain!=null&&controller.chaser==null){
            List<AiComponent> agents = controller.getAgentsInRange(controller.brain.getSensorRange());
            if(agents.Count>1)
            foreach(AiComponent agent in agents)
                if(controller.tag=="DOG"&&agent.getController().tag == "CAT")
                if(Vector3.Distance(controller.transform.position,agent.getController().transform.position)<=controller.brain.getSensorRange())
                return false;
            
            if(Vector3.Distance(controller.transform.position,PlayerController.playerTransform.position)<=controller.brain.getSensorRange()){
            controller.chasing = PlayerController.playerTransform;
            return true;
            }
            return false;
           }
           return false;
        }
    }
}