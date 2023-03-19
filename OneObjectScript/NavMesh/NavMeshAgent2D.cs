using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent2D : MonoBehaviour
{
    [Header("Steering")]
    public float speed = 1.0f;
    public float stoppingDistance = 0;
    Vector2 temp;
    int direction = 0;
    bool directionChangeAvailable=true;

    [HideInInspector]//常にUnityエディタから非表示
    private Vector2 trace_area=Vector2.zero;
    public Vector2 destination
    {
        get { return trace_area; }
        set
        {
            trace_area = value;
            Trace(transform.position, value);
        }
    }
    public bool SetDestination(Vector2 target)
    {
        destination = target;
        return true;
    }

    private void Trace(Vector2 current,Vector2 target)
    {
        if (Vector2.Distance(current,target) <= stoppingDistance)
        {
            return;
        }

        // NavMesh に応じて経路を求める
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(current, target, NavMesh.AllAreas, path);

        if(path.corners.Length<2){
            return;
        }
        Vector2 corner = path.corners[0];
        

        if (Vector2.Distance(current, corner) <= 0.05f)
        {
            corner = path.corners[1];
        }
        if(directionChangeAvailable){
            if(Math.Abs(corner.x-current.x)>Math.Abs(corner.y-current.y)){
                direction = 0;
            }else{
                direction = 1;
            }
            StartCoroutine("DirectionChange");
        }
        
        if(direction == 0){
            temp = new Vector2(corner.x,current.y);
        }else{
            temp = new Vector2(current.x,corner.y);
        }
        transform.position = Vector2.MoveTowards(current, temp, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(current, corner, speed * Time.deltaTime);
    }

    IEnumerator DirectionChange(){
        directionChangeAvailable = false;
        yield return new WaitForSeconds(0.5f);
        directionChangeAvailable = true;
    }
}
