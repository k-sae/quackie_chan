using System.Collections;
using System.Collections.Generic;
using AiManager;
using UnityEngine;
namespace AI.FSM
{

public abstract class Action : ScriptableObject 
{
    public abstract void Act (AiComponentController controller);
}
}