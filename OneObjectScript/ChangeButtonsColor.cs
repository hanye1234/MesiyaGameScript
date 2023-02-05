using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonsColor : MonoBehaviour
{
    public List<Button> Buttons;
    public void ChangeButtonColor(int SelectedButton){
        ColorBlock colorBlock;
        for(int i=0;i<Buttons.Count;i++)
        {
            if(i==SelectedButton){
                colorBlock =  Buttons[i].colors;
                colorBlock.normalColor = new Color(0f,1f,1f,1f);
                Buttons[i].colors = colorBlock;
            }else{
                colorBlock =  Buttons[i].colors;
                colorBlock.normalColor = new Color(1f,1f,1f,1f);
                Buttons[i].colors = colorBlock;
            }
            
        }

    }
}
