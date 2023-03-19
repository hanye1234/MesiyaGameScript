using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTableController : MonoBehaviour
{
    // 손님이 주문한 것
    public int order;
    // 테이블의 상태를 나타내는 수치. 0은 비어있음. 1은 손님이 앉음. 2는 주문한 음식이 오길 대기 중. 3은 식사 중. 4는 접시만 남음.
    public int progress;
    SpriteRenderer FoodSprite;
    public Sprite plate;
    OrderBubbleController bubble;
    void Awake()
    {
        order = 999;
        progress = 0;
        FoodSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        transform.GetChild(0).gameObject.SetActive(false);
        bubble = transform.GetChild(1).gameObject.GetComponent<OrderBubbleController>();
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public bool TryAction(Item HoldedItem){
        if(progress==2){
            if(order == HoldedItem.id){
                Served(HoldedItem);
                return true;
            }
        }else if(progress==4){
            progress = 0;
            transform.GetChild(0).gameObject.SetActive(false);
        }
        return false;
    }

    public void Eated(){
        progress = 4;
        FoodSprite.sprite = plate;
    }

    public void OrderFood(Item food){
        progress = 2;
        order = food.id;
        transform.GetChild(1).gameObject.SetActive(true);
        bubble.ShowBubble(food);
    }

    public void Served(Item food){
        progress = 3;
        transform.GetChild(0).gameObject.SetActive(true);
        FoodSprite.sprite = food.image;
        transform.GetChild(1).gameObject.SetActive(false);
        order = 999;
    }
}
