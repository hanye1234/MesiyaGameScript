using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float InputX;
    float InputY;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        Move(InputX,InputY,0.1f);
    }

    public void Move(float X, float Y,float speed){
        if(Mathf.Abs(X)>0.1 || Mathf.Abs(Y)>0.1)
        {
            Vector2 position = rigidbody2d.position;
            if(Mathf.Abs(X)>Mathf.Abs(Y)){
                if(X>0){
                    position.x = position.x + speed;
                }else{
                    position.x = position.x - speed;
                }
            }else{
                if(Y>0){
                    position.y = position.y + speed;
                }else{
                    position.y = position.y - speed;
                }
            }
            rigidbody2d.MovePosition(position);
        }
    }

    public void TryToGetSomething(){
        
    }
}

