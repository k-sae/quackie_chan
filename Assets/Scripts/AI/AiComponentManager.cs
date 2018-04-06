using System;
namespace AiManager
{
    [Flags]
    public static readonly enum AgentType
    {
        Cat = 0 ,
        Dog = 1 ,
        Car = 2
    }
    public class AiComponentManager : AiComponentTracker{
     private static AiComponentManager instance = new AiComponentManager();
     private List<AiComponent> componentsList;
     private AiComponentManager() {
        componentsList = new List<AiComponent>();
     }
     public static AiComponentManager Instance{get{return instance;}}
     public void registerComponent(AiComponent component){this.componentsList.Add(component);}
     public void unregisterComponent(AiComponent component){this.componentsList.Remove(component);}
     public void notifyOnMove(AiComponent component){
         
     }    
    
    }    
}