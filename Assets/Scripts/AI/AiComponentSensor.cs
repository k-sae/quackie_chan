using System.Collections.Generic;

namespace AiManager
{
    public interface AiComponentSensor
    {
         void notifyEnvironmentChanges(List<AiComponent> agents );    
    }
}