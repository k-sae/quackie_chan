using System;
using System.Collections.Generic;
using UnityEngine;
namespace AiManager
{
    [Flags]
    public enum AgentType
    {
        Cat = 0 ,
        Dog = 1 ,
        Car = 2
    }
    public class AiComponentManager : AiComponentTracker{
    private List<AiComponentSensor> componentsList;
     public Collider node;
     public AiComponentManager(Collider node) {
         componentsList = new List<AiComponentSensor>();
         this.node = node;
     }
     public void registerComponent(AiComponentSensor component){
         
         this.componentsList.Add(component);
     }
     public void unregisterComponent(AiComponentSensor component){
        
                if(this.componentsList.Contains(component))
                    this.componentsList.Remove(component);
                
     }
     public void notifyOnMove(){
         foreach (AiComponentSensor agent in componentsList){
             
         }
     }  
 
   
  


    }    
}