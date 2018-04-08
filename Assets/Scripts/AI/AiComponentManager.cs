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
     private Dictionary<Vector3,List<AiComponent>> componentsList;
     private float gridSideLength;
     private readonly int numberOfSquares;
     public Collider node;
     public AiComponentManager(Collider node) {
         this.node = node;
        componentsList = new Dictionary<Vector3,List<AiComponent>>();
        gridSideLength = fitSquareSide(node.bounds.size.x,node.bounds.size.z);
     }
     public void registerComponent(AiComponent component){
         Vector3? key = this.getContainingGridCenter(component);
         if(key.HasValue)
         this.componentsList[key.Value].Add(component);
     }
     public void unregisterComponent(AiComponent component){
          foreach(KeyValuePair<Vector3, List<AiComponent>> entry in this.componentsList)
            {
                if(this.componentsList[entry.Key].Contains(component)){
                    this.componentsList[entry.Key].Remove(component);
                    break;
                }
            }
     }
     public void notifyOnMove(Vector3 position){
         List<AiComponent> agents =this.getAgetsInPlayerRange(position);
         List<AiComponent> temp;
         foreach(AiComponent agent in agents){
             temp = new List<AiComponent>(agents);
             temp.Remove(agent);
             agent.notifyNearbyComponents(temp);
         }
     }  
     float fitSquareSide(double width, double length){
        double sx, sy;
        var px = Math.Ceiling(System.Math.Sqrt(this.numberOfSquares * width / length));
        if (Math.Floor(px * length / width) * px < this.numberOfSquares ) sx = length / Math.Ceiling(px * length / width);
        else sx = width / px;
        var py = Math.Ceiling(System.Math.Sqrt(this.numberOfSquares * length / width));
        if (Math.Floor(py * width / length) * py < this.numberOfSquares) sy = width / Math.Ceiling(width* py / length);
        else sy = length / py;
        return (float)Math.Max(sx, sy);
    }  
    private void generateGrids(){
        Vector3 start = node.transform.position + new Vector3(node.bounds.size.x,0.0f,node.bounds.size.y);
       
        for (int i = 0; i < Math.Sqrt(this.numberOfSquares); i++)
        {
             Vector3 col = start ;
            for (int j =0; j < Math.Sqrt(this.numberOfSquares); j++){
                this.componentsList.Add((col+col-new Vector3(this.gridSideLength,0,-this.gridSideLength))/2, new List<AiComponent>());
                col = col - new Vector3(0.0f,0.0f,this.gridSideLength);
            }
            start = start - new Vector3(this.gridSideLength,0.0f,0.0f);
            
        }
    }
    private Vector3? getContainingGridCenter(AiComponent component){
         Vector2 componentPosition = new Vector2(component.getPosition().x,component.getPosition().z);
         Rect grid = new Rect(0,0,this.gridSideLength,this.gridSideLength);
         foreach(KeyValuePair<Vector3, List<AiComponent>> entry in this.componentsList)
            {
                grid.center = new Vector2(entry.Key.x,entry.Key.z);
                if(grid.Contains(componentPosition)){
                    
                    return entry.Key;
                }
            }
           return null;
    }
    private List<AiComponent> getAgetsInPlayerRange(Vector3 position){
        List<AiComponent> near = new List<AiComponent>();
         foreach(KeyValuePair<Vector3, List<AiComponent>> entry in this.componentsList)
            {
              if(Vector3.Distance(entry.Key,position)<=PlayerTrigger.PLAYER_RANGE)
              near.AddRange(this.componentsList[entry.Key]);
            }
            return near;
    }


    }    
}