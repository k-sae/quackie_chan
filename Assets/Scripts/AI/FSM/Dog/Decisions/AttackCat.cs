using System.Collections.Generic;
using AiManager;
using UnityEngine;

namespace AI.FSM
{
    [CreateAssetMenu (menuName = "FSM/Dog/Decision/AttackCat")]
    public class AttackCat : Decision
    {
        public override bool Decide(AiComponentController controller)
        {
          
            List<AiComponent> agents = controller.getAgentsInRange(controller.brain.getSensorRange());
            if(agents.Count>1)
            foreach(AiComponent agent in agents){
               
                if(controller.tag=="DOG"&& agent.getController().tag == "CAT"){
                   
                    //TODO: find cat in range
                
                controller.chasing =  getNearest( controller , agents ).getController().transform;
                agent.getController().chaser = controller.transform;
                return true;}
                }
            return false;
        }
        private AiComponent getNearest(AiComponentController controller , List<AiComponent> agents ){
            AiComponent near = null;
             foreach(AiComponent agent in agents){
                if( agent.getController().tag == "CAT"){
                    if (near == null)
                    near=agent;
                    else{
                        if(Vector3.Distance(controller.transform.position,agent.getController().transform.position)
                        <=Vector3.Distance(controller.transform.position,near.getController().transform.position))
                        near = agent;
                    }
                }
             }
             return near;
        }
    }
}