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
     public AiComponentManager() {
        componentsList = new Dictionary<Vector3,List<AiComponent>>();
        gridSideLength = fitSquareSide(node.bounds.size.x,node.bounds.size.z);

     }
     public void registerComponent(AiComponent component){}
     public void unregisterComponent(AiComponent component){}
     public void notifyOnMove(AiComponent component){
         
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
                this.componentsList.Add((col+col-new Vector3(this.gridSideLength,0,this.gridSideLength))/2, new List<AiComponent>());
                col = col - new Vector3(0.0f,0.0f,this.gridSideLength);
            }
            start = start - new Vector3(this.gridSideLength,0.0f,0.0f);
            
        }
    }
    }    
}