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
    private List<AiComponent> componentsList;
     public Collider node;
     public AiComponentManager(Collider node) {
         componentsList = new List<AiComponent>();
         this.node = node;
     }
     public void registerComponent(AiComponent component){
         
         this.componentsList.Add(component);
     }
     public void unregisterComponent(AiComponent component){
        
                if(this.componentsList.Contains(component))
                    this.componentsList.Remove(component);
                
     }
     public void notifyOnMove(Vector3 position){
         
     }  
 
   
  


    }    
}