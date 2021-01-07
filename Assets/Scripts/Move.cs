using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move: MonoBehaviour
{
    private int target = 0;
    private int oldTarget = 0;
    private List<Vector3> waypoints = new List<Vector3>();
    private int slide = 0;
    private bool died = false;
     public float speed = 3f;

     void Start(){

     }
     void Update() {
         if(died){
             dieMove();
         }else if(slide == 0){
            normalMove();
         }else{
            slideMove();
         }
     }

     private void normalMove(){
         float move = speed * Time.deltaTime;
         if(Vector3.Distance(transform.position,waypoints[oldTarget])> 0){
            transform.position = Vector3.MoveTowards(transform.position, waypoints[oldTarget], move);
         }else if(target > oldTarget){
             oldTarget++;
         }
     }

     private void slideMove(){
         float move = speed * Time.deltaTime;
         normalMove();
         if(Vector3.Distance(transform.position,waypoints[target]) == 0){
             target = slide;
             oldTarget = target;
             slide = 0;
         }
     }

     private void dieMove(){
         float move = 10f * Time.deltaTime;
         if(Vector3.Distance(transform.position,waypoints[oldTarget])> 0){
            transform.position = Vector3.MoveTowards(transform.position, waypoints[oldTarget], move);
         }else if(target < oldTarget){
             oldTarget--;
         }else if(Vector3.Distance(transform.position,waypoints[target]) == 0){
             died = false;
         }
     }

     public void setTarget(int newTarget){
         target = newTarget;
     }

     public void setSlide(int newTarget, int newSlide){
         slide = newSlide;
         target = newTarget;
     }

     public void setWaypoints(List<Vector3> newWaypoints){
         waypoints = newWaypoints;
     }

     public void goToStart(){
         died = true;
         target = 0;
     }
}
