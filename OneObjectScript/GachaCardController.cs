using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaCardController : MonoBehaviour
{
    public Item ResultItem;
    GameObject FrontImageObject;
    GameObject BackImageObject;
    public GachaController gachaController;
    public float y;
    public int timer;
    bool IsFlipped = false;

    void OnEnable()
    {
        FrontImageObject = gameObject.transform.GetChild(0).gameObject;
        BackImageObject = gameObject.transform.GetChild(1).gameObject;
        IsFlipped = false;
        ChangeImage();
        y=1;
    }

    public void Flip(){
        if(IsFlipped==false){
            StartCoroutine("CalculateFilp");
        }
    }

    void ChangeImage(){
        if(IsFlipped){
            FrontImageObject.SetActive(true);
            FrontImageObject.GetComponent<Image>().sprite = ResultItem.image;
            BackImageObject.SetActive(false);
        }else{
            FrontImageObject.SetActive(false);
            BackImageObject.SetActive(true);
        }
    }

    IEnumerator CalculateFilp(){
        IsFlipped = true;
        gachaController.FlippedCardCount ++;
        for(int i =0;i<180;i++){
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(0,y,0));
            timer ++;
            if(timer ==90){
                ChangeImage();
            }
        }
        timer = 0;
    }
}
