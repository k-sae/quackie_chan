using System;
using System.Collections.Generic;
using UnityEngine;
namespace AiManager
{
    public interface AiComponentSensor
    {
      void notifyNearbyComponents(List<AiComponent> nearbyComponents);   
      Vector3 getPosition();
      float getSensorRange();
    }
}