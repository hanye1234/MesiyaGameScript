
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

    // 스테이터스 999 초기치 0 이동 중 1 이동 완료
    public int status = 999;
    NavMeshAgent2D agent;
    public Transform target;
    //초기 위치
    public Transform OrdinaryPosition;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent2D>();
    }

    void Update()
    {
        if(status == 0){
            MoveTo();
        }
        if(status != 999 && Vector2.Distance(gameObject.transform.position,target.position)<=0.5f){
            status = 1;
        }

    }

    public void SetTarget(GameObject obj){
        target = obj.transform;
        status = 0;
    }

    public void Back(){
        target = OrdinaryPosition;
        status = 0;
    }

    public void MoveTo(){
        agent.destination = target.position;
    }

    public void Stop(){
        status = 999;
    }
}
