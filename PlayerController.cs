using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float InputX;
    float InputY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizonal");
        InputY = Input.GetAxis("Vectical");
    }
}
