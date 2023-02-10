using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float InputX;
    float InputY;
    RaycastHit2D CurrentRayHit;
    List<Vector3> DirectionVectorList;
    int Direction;
    // Start is called before the first frame update
    void Awake()
    {
        Direction = 0;
        DirectionVectorList = new List<Vector3>(){Vector3.right,Vector3.left,Vector3.up,Vector3.down};
        rigidbody2d = GetComponent<Rigidbody2D>();
        CurrentRayHit= Physics2D.Raycast(rigidbody2d.position,Vector3.right,1,LayerMask.GetMask("ItemLayer"));;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            TryToGetSomething();
        }
    }
    void FixedUpdate()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        if(Mathf.Abs(InputX)>0.1 || Mathf.Abs(InputY)>0.1){
            Move(InputX,InputY,10f*Time.deltaTime);
        }
        Debug.DrawRay(rigidbody2d.position,Vector3.down,new Color(0,1,0));
    }

    public void Move(float X, float Y,float speed){
        Vector2 position = rigidbody2d.position;
        if(Mathf.Abs(X)>Mathf.Abs(Y)){
            if(X>0){
                position.x = position.x + speed;
                Direction = 0;
            }else{
                position.x = position.x - speed;
                Direction = 1;
            }
        }else{
            if(Y>0){
                position.y = position.y + speed;
                Direction = 2;

            }else{
                position.y = position.y - speed;
                Direction = 3;

            }
        }
        CurrentRayHit = Physics2D.Raycast(rigidbody2d.position,DirectionVectorList[Direction],1,LayerMask.GetMask("ItemLayer"));
        rigidbody2d.MovePosition(position);
    
    }

    public void TryToGetSomething(){
        if(CurrentRayHit.collider!=null){
            Debug.Log(CurrentRayHit.collider.name);
            CurrentRayHit.collider.gameObject.SetActive(false);
        }
    }
}

