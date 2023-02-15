using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTableController : MonoBehaviour
{
    bool CookingIsDone = false;
    bool IsCooking = false;
    public GameObject CookingWindow;
    public CookingBubbleController bubbleController;
    public PlayerController playerController;
    Item TakenFood;


    public void TryAction(){
        if(CookingIsDone){
            TakenFood = bubbleController.ReturnCurrentFood();
            bool IsHolded = playerController.HoldItem(TakenFood);
            if(IsHolded){
                bubbleController.gameObject.SetActive(false);
                CookingIsDone = false;
            }
        }else if(CookingWindow.activeInHierarchy == false && IsCooking == false){
            CookingWindow.transform.parent.gameObject.SetActive(true);
            CookingWindow.GetComponent<CookingWindowController>().ActivateTableController = GetComponent<CookingTableController>();
        }

    }

    public void CookingStart(){
        StartCoroutine("Cooking");
    }

    IEnumerator Cooking(){
        IsCooking = true;
        yield return new WaitForSeconds(bubbleController.CookingTime);
        CookingIsDone = true;
        IsCooking = false;
    }

}
