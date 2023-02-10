using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chang_controller : MonoBehaviour
{
    public GameObject MaeChang;
    public List<GameObject> UsiroChangs;
    // Start is called before the first frame update
    bool IsOpened;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            IsOpened = false;
            foreach(GameObject temp in UsiroChangs){
                if(temp.activeInHierarchy){
                    IsOpened = true;
                    break;
                }
            }
            if(IsOpened == false){
                MaeChang.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }
    }
}
