namespace AiManager
{
    public interface AiComponentTracker
    {
    public void registerComponent(AiComponent component);
    public void unregisterComponent(AiComponent component);
    /// <summary>
    /// Call during Component movement
    /// </summary>
    public void notifyOnMove(AiComponent component);    
    }
}