using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldedFood : MonoBehaviour
{
    public PlayerController playerController;
    int CurrentShowFood = 999;
    Image TargetObjectImage;
    // Update is called once per frame
    void Awake()
    {
        TargetObjectImage = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }
    void Update()
    {
        Item temp = playerController.GetHoldedItem();
        if(temp.id != 999){
            if(CurrentShowFood != temp.id){
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                TargetObjectImage.sprite = temp.image;
                CurrentShowFood = playerController.GetHoldedItem().id;
            }
        }else{
            transform.GetChild(0).gameObject.SetActive(false);
            CurrentShowFood = 999;
        }
    }
}
