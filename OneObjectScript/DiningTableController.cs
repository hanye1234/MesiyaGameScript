using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningTableController : MonoBehaviour
{
    Item CurrentOnItem = new Item(){id=999};
    SpriteRenderer sprite;
    public PlayerController playerController;

    void Awake()
    {
        sprite = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        CurrentOnItem = new Item(){id=999};
    }
    public void TryAction(){
        Debug.Log("TryAction");
        if(IsAvailable())
        {
            PutOnItem(playerController.ReleaseItem());

        }else{
            bool IsHolded =  playerController.HoldItem(CurrentOnItem);
            if(IsHolded){
                CurrentOnItem = new Item(){id=999};
                ResetSprite();
            }
        }
        
    }

    void ChangeSprite(){
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        sprite.sprite = CurrentOnItem.image;
    }

    void ResetSprite()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void PutOnItem(Item item){
        CurrentOnItem = item;
        if(IsAvailable()){
            ResetSprite();
        }else{
            ChangeSprite();
        }
    }

    public bool IsAvailable(){
        if(CurrentOnItem.id==999){
            return true;
        }
        return false;
    }
    public Item GetCurrentItem(){
        return CurrentOnItem;
    }
    public int GetCurrentItemId(){
        return CurrentOnItem.id;
    }
}
