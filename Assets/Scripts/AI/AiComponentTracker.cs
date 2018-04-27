using UnityEngine;

namespace AiManager
{
    public interface AiComponentTracker
    {
     void registerComponent(AiComponentSensor component);
     void unregisterComponent(AiComponentSensor component);
    /// <summary>
    /// Call during Component movement
    /// </summary>
     void notifyOnMove();    
     
    }
}