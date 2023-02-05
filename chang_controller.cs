using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chang_controller : MonoBehaviour
{
    public GameObject MaeChang;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            MaeChang.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
