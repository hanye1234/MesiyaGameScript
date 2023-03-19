using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    // 서버의 상태. 999는 초기. 0은 음식을 가지러 감. 1은 음식을 손님에게 배달 중. 2는 취소되어 놓을 테이블을 찾는 중. 3은 테이블로 이동 중.
    int status = 999;
    // 코루틴용.
    bool Available = true;
    // 행동을 캔슬하는 중인지
    bool cancel = false;
    public MapSearcher mapSearcher;
    int TargetDiningTableIndex;
    int TargetCustomerTableIndex;
    int TargetFoodIndex;
    Item HoldedItem = new Item(){id=999};
    MoveToTarget moveToTarget;
    
    void Awake()
    {
        moveToTarget = gameObject.GetComponent<MoveToTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Available){
            if(status == 999){
                StartCoroutine("SearchNextBehavior");
                SearchNextServeTable();
            }   
        }

        if(status == 0){
            if(moveToTarget.status == 1){
                TakeFood();
            }else if(mapSearcher.GetFoodIdByDiningTableIndex(TargetDiningTableIndex)!=TargetFoodIndex){
                CancelBehavior();
            }
        }else if(status == 1){
            if(moveToTarget.status == 1){
                ServeFood();
            }else if(mapSearcher.GetOrderIdByTableIndex(TargetCustomerTableIndex)!=TargetFoodIndex || mapSearcher.GetTableObjectByIndex(TargetCustomerTableIndex).GetComponent<OrderTableController>().progress != 2){
                CancelBehavior();
            }
        }else if(Available && status == 2){
            TargetDiningTableIndex = mapSearcher.FindAvailableDiningTable();
            if(TargetDiningTableIndex<0){
                StartCoroutine("SearchNextBehavior");
                SearchNextServeTable();
            }else{
                moveToTarget.SetTarget(mapSearcher.GetDiningTableObjectByIndex(TargetDiningTableIndex));
                status = 3;
            }
            
        }else if(status == 3){
            if(moveToTarget.status == 1){
                PutFood();
            }
        }
        
    }

    IEnumerator SearchNextBehavior(){
        Available = false;
        yield return new WaitForSeconds(0.5f);
        Available = true;
    }

    void SearchNextServeTable(){
        List<int> TableIndexList;
        List<int> FoodIdList;
        int orderId;
        if(HoldedItem.id == 999){
            
            TableIndexList = mapSearcher.FindUnservedCustomerTableList();
            FoodIdList = mapSearcher.FindFoodListOnDiningTable();
            for(int i=0;i<TableIndexList.Count;i++){
                orderId = mapSearcher.GetOrderIdByTableIndex(TableIndexList[i]);
                if(orderId != 999){
                    if(FoodIdList.Contains(orderId)){
                        status = 0;
                        TargetDiningTableIndex = FoodIdList.IndexOf(orderId);
                        TargetCustomerTableIndex = TableIndexList[i];
                        TargetFoodIndex = orderId;
                        moveToTarget.SetTarget(mapSearcher.GetDiningTableObjectByIndex(TargetDiningTableIndex));
                    }
                }
            }
        }else{
            TableIndexList = mapSearcher.FindUnservedCustomerTableList();
            for(int i=0;i<TableIndexList.Count;i++){
                orderId = mapSearcher.GetOrderIdByTableIndex(TableIndexList[i]);
                if(orderId == HoldedItem.id){
                    status = 1;
                    TargetCustomerTableIndex = TableIndexList[i];
                    TargetFoodIndex = orderId;
                    moveToTarget.SetTarget(mapSearcher.GetSeatObjectByIndex(TargetCustomerTableIndex));
                }
            }
        }
        
    }

    void TakeFood(){
        UnityEngine.Debug.Log("음식을 서버가 테이크");
        
        DiningTableController dining = mapSearcher.GetDiningTableObjectByIndex(TargetDiningTableIndex).GetComponent<DiningTableController>();
        HoldedItem = dining.GetCurrentItem();
        dining.PutOnItem(new Item(){id=999});
        status = 1;

        moveToTarget.SetTarget(mapSearcher.GetSeatObjectByIndex(TargetCustomerTableIndex));
    }

    void ServeFood(){
        UnityEngine.Debug.Log("음식을 서빙");
        // 테이블에 음식을 두어야 함
        OrderTableController table = mapSearcher.GetTableObjectByIndex(TargetCustomerTableIndex).GetComponent<OrderTableController>();

        table.Served(HoldedItem);
        ResetTarget();
        HoldedItem = new Item(){id=999};
        moveToTarget.Back();
        status = 999;
    }

    void PutFood(){
        DiningTableController dining = mapSearcher.GetDiningTableObjectByIndex(TargetDiningTableIndex).GetComponent<DiningTableController>();
        if(dining.IsAvailable()){
            dining.PutOnItem(HoldedItem);
            HoldedItem = new Item(){id=999};
            ResetTarget();
            moveToTarget.Back();
            status = 999;
        }else{
            status = 2;
        }
        
    }

    void CancelBehavior(){
        cancel = true;
        if(status == 0){
            ResetTarget();
            moveToTarget.Back();
            status = 999;
        }else if(status ==1){
            status = 2;
        }
    }

    void ResetTarget(){
        TargetDiningTableIndex = -1;
        TargetCustomerTableIndex = -1;
        TargetFoodIndex = -1;
    }
}
