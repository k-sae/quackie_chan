using UnityEngine;
using System.Collections.Generic;
namespace AiManager
{
    public class AiComponent : AiComponentSensor
    {
     private Vector3 position;
     private AiComponentTracker aiComponentManager;
     private AiComponentController controller;
     private List<AiComponent> agents;

     public readonly float MAX_SENSOR_RANGE = 20;
     public float sensorRange{
         get{
             if(sensorRange>=MAX_SENSOR_RANGE) return MAX_SENSOR_RANGE ;else return sensorRange;
             }
      }
          public AiComponent(AiComponentTracker aiComponentManager , AiComponentController controller){
         this.aiComponentManager = aiComponentManager;
         this.aiComponentManager.registerComponent(this);
         this.controller =controller;
     }
     public  Vector3 getPosition(){return this.position;}
     public float getSensorRange(){return this.MAX_SENSOR_RANGE;}

        public void notifyEnvironmentChanges(List<AiComponent> agents)
        {
            this.agents = agents;
            if(controller!=null)
            this.controller.updateState();
        }
        public List<AiComponent> getAgents(){
            return this.agents;
        }
        public AiComponentController getController(){
            return this.controller;
        }
    }
}