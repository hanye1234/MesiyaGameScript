using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{

    // 손님의 상태를 나타내는 수치. 0은 대기 중. 1은 이동 중. 2는 테이블에 앉음. 3은 주문한 음식이 오길 대기 중. 4은 식사 중. 5는 퇴실. 999는 초기치.
    public int progress = 999;
    int speed = 1;
    bool able = true;
    float Xposition;
    float Yposition;
    float TargetX;
    float TargetY;
    public int Xdirection = 0;
    public int Ydirection = 0;
    bool ismoving=false;
    public GameObject table;
    public GameObject seat;
    OrderTableController orderTableController;
    public Customer customerStatus;
    public MapSearcher mapSearcher;
    void OnEnable()
    {
        StartCoroutine("Enter");
    }

    // Update is called once per frame
    void Update()
    {
        if(able){
            if(progress==0){
                StartCoroutine("SearchTable");
            }else if(progress==1){
                SetMoveTo(TargetX,TargetY,5.0f*Time.deltaTime);
                if(Xdirection == 0 && Ydirection == 0){
                    progress = 2;
                }
            }else if(progress == 2){
                StartCoroutine("SelectOrder");
            }else if(progress == 3){
                if(orderTableController.progress==3){
                    progress=4;
                }
            }else if(progress == 4){
                StartCoroutine("Eating");
            }else if(progress == 5){
                
                SetMoveTo(8,-3,5.0f*Time.deltaTime);
                if(Xdirection == 0 && Ydirection ==0){
                    progress = 999;
                }
            }
        }
        
    }

    public void ChangeStatus(Customer status){
        customerStatus = status;
        progress = 0;
    }

    void SetMoveTo(float X,float Y,float speed){
        if(ismoving){
            if(Math.Abs(Xdirection)>Math.Abs(Ydirection)){
                MoveX(X,Xdirection,speed);
            }else{
                MoveY(Y,Ydirection,speed);
            }
        }else{
            Xposition = transform.position.x;
            Yposition = transform.position.y;
            if(Math.Abs(Xposition-X)>Math.Abs(Yposition-Y)){
                Xdirection = 2;
                Ydirection = 1;
            }else{
                Ydirection = 2;
                Xdirection = 1;
            }
            if(Xposition-X>0){
                Xdirection = -Xdirection;
            }
            if(Yposition-Y>0){
                Ydirection = -Ydirection;
            }
            ismoving = true;
        }
        if(Xdirection==0&&Ydirection==0){
            ismoving = false;
        }
    }


    void MoveX(float X,int direction,float speed){
        if(direction>0){
            if(X-transform.position.x>0){
                transform.position = new Vector3(transform.position.x+speed,transform.position.y,transform.position.z);
            }
            else{
                Xdirection = 0;
            }
        }else{
            if(X-transform.position.x<0){
                transform.position = new Vector3(transform.position.x-speed,transform.position.y,transform.position.z);
            }
            else{
                Xdirection = 0;
            }
        }
        
    }
    void MoveY(float Y,int direction,float speed){
        if(direction>0){
            if(Y-transform.position.y>0){
                transform.position = new Vector3(transform.position.x,transform.position.y+speed,transform.position.z);
            }
            else{
                Ydirection = 0;
            }
        }else{
            if(Y-transform.position.y<0){
                transform.position = new Vector3(transform.position.x,transform.position.y-speed,transform.position.z);
            }
            else{
                Ydirection = 0;
            }
        }
        
    }


    IEnumerator Enter(){
        able = false;
        yield return new WaitForSeconds(5.0f);
        able = true;
    }

    IEnumerator SearchTable(){
        able = false;
        int index = mapSearcher.FindCustomerTable();
        if(index>-1){
            table = mapSearcher.GetTableObjectByIndex(index);
            orderTableController = table.GetComponent<OrderTableController>();
            seat = mapSearcher.GetSeatObjectByIndex(index);
            TargetX = seat.transform.position.x;
            TargetY = seat.transform.position.y;
            orderTableController.progress = 1;
            progress = 1;
        }        
        yield return new WaitForSeconds(1.0f);
        
        able = true;
    }

    IEnumerator SelectOrder(){
        able = false;
        yield return new WaitForSeconds(5.0f*speed);
        progress = 3;
        Debug.Log(customerStatus.order.id);
        orderTableController.OrderFood(customerStatus.order);
        able = true;
    }

    IEnumerator Eating(){
        able = false;
        yield return new WaitForSeconds(5.0f*speed);
        progress = 5;
        orderTableController.Eated();
        able = true;
        ismoving = true;
        Xdirection = 1;
        Ydirection = -2;
    }

}
