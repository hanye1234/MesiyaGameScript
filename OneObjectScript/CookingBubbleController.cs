using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingBubbleController : MonoBehaviour
{
    Item CurrentFood = new Item();
    public float CookingTime;
    SpriteRenderer Black;
    Color c = new Color();

    Dictionary<int,float> dictCookingTime = new Dictionary<int, float>()
    {
        {0,1},
        {1,2},
        {2,3},
        {3,4},
        {4,5},
        {5,6},
        {7,8},
        {8,9},
        {9,10},
        {10,11},
        {11,12},
        {12,13},
        {13,14},
        {14,15},
        {15,16},
        {16,17},
        {17,18},
        {18,19}
    };

    public void ShowBubble(Item Food){
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Food.image;
        CurrentFood = Food;
        CookingTime = dictCookingTime[CurrentFood.id];
    }

    void OnEnable()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        Black = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Black.color = new Color(1,1,1,1);
    }

    void Update()
    {
        if(transform.GetChild(1).gameObject.activeInHierarchy){
            c = Black.color;
            c.a = c.a - Time.deltaTime / dictCookingTime[CurrentFood.id];
            if(c.a<=0){
                c.a = 0;
                transform.GetChild(1).gameObject.SetActive(false);
            }
            Black.color = c;
        }
        
    }

    public Item ReturnCurrentFood(){
        return CurrentFood;
    }

}
