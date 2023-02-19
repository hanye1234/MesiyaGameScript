using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBubbleController : MonoBehaviour
{
    GameObject spriteObject;
    SpriteRenderer FoodSprite;
    void Awake()
    {
        spriteObject = transform.GetChild(0).gameObject;
        FoodSprite = spriteObject.GetComponent<SpriteRenderer>();
    }
    public void ShowBubble(Item OrderedFood){
        FoodSprite.sprite = OrderedFood.image;
    }

}
