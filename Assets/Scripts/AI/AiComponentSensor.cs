namespace AiManager
{
    public interface AiComponentSensor
    {
     public void notifyNearbyComponents(List<AiComponent> nearbyComponents);   
     public  Vector3 getPosition();
     public float getSensorRange();
    }
}