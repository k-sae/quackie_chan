using UnityEngine;
using System.Collections.Generic;
namespace AiManager
{
    public class AiComponent:AiComponentSensor
    {
     private Vector3 position;
     private AiComponentManager aiComponentManager;

     public readonly float MAX_SENSOR_RANGE = 100;
     public float sensorRange{
         get{
             if(sensorRange>=MAX_SENSOR_RANGE) return MAX_SENSOR_RANGE ;else return sensorRange;
             }
      }
          public AiComponent(AiComponentManager aiComponentManager){
         this.aiComponentManager = aiComponentManager;
         this.aiComponentManager.registerComponent(this);
     }
     public void notifyNearbyComponents(List<AiComponent> nearbyComponents){} 
     public  Vector3 getPosition(){return this.position;}
     public float getSensorRange(){return this.sensorRange;}
    }
}