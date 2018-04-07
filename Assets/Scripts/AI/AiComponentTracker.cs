using UnityEngine;

namespace AiManager
{
    public interface AiComponentTracker
    {
     void registerComponent(AiComponent component);
     void unregisterComponent(AiComponent component);
    /// <summary>
    /// Call during Component movement
    /// </summary>
     void notifyOnMove(Vector3 position);    
     
    }
}