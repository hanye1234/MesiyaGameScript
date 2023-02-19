using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessSceneController : MonoBehaviour
{
    bool CustomerGenerated = false;
    public List<GameObject> CustomerObjects;
    public List<OrderTableController> tableContollers;
    List<Customer> CurrentCustomers = new List<Customer>();
    int GeneratedCustomerCount = 0;
    List<Item> CurrentMenus;
    List<int> CurrentAvailableCustomerIndexList=new List<int>();
    GameData gameData;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        CurrentCustomers = new List<Customer>();
        for(int i=0;i<CustomerObjects.Count;i++){
            CurrentCustomers.Add(new Customer(){id=i,order=new Item(){id=999},tableIndex=999,progress=999});
            CurrentAvailableCustomerIndexList.Add(i);
        }
        CurrentMenus = gameData.MakeCurrentAvailableItemList("Food","equip");
        GeneratedCustomerCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(GeneratedCustomerCount<CustomerObjects.Count && CustomerGenerated == false){
            StartCoroutine("GenerateCustomer");
        }
    }

    IEnumerator GenerateCustomer(){
        CustomerGenerated = true;
        Debug.Log("손님을 생성합니다");
        GenerateRandomCustomer();
        yield return new WaitForSeconds(0.5f);
        GeneratedCustomerCount ++;
        CustomerGenerated = false;
    }

    public void GenerateRandomCustomer(){
        int Index = Random.Range(0,CurrentAvailableCustomerIndexList.Count);
        int Randomindex = CurrentAvailableCustomerIndexList[Index];
        int RandomFoodIndex = Random.Range(0,CurrentMenus.Count);
        CustomerObjects[Randomindex].SetActive(true);
        CurrentCustomers[Randomindex] = new Customer(){id=Randomindex,order=CurrentMenus[RandomFoodIndex],tableIndex=0,progress=0};
        CustomerObjects[Randomindex].GetComponent<CustomerController>().ChangeStatus(CurrentCustomers[Randomindex]);
        CurrentAvailableCustomerIndexList.RemoveAt(Index);
    }
}
