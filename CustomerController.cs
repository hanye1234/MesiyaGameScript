using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{

    // 손님의 상태를 나타내는 수치. 0은 대기 중. 1은 테이블에 앉음. 2는 주문한 음식이 오길 대기 중. 3은 식사 중. 4는 퇴실. 999는 초기치.
    int progress = 999;
    public Customer customerStatus;
    void OnEnable()
    {
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStatus(Customer status){
        customerStatus = status;
    }


}
