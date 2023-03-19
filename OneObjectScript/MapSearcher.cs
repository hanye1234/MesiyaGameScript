using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSearcher : MonoBehaviour
{

    public List<GameObject> CustomerTables;
    public List<GameObject> CustomerSeats;
    public List<GameObject> DiningTables;
    public List<GameObject> CookingTables;

    public int FindCustomerTable(){
        for(int i=0;i<CustomerTables.Count;i++){
            if(CustomerTables[i].GetComponent<OrderTableController>().progress == 0){
                return i;
            }
        }
        return -1;
    }

    public int FindUnservedCustomerTable(){
        for(int i=0;i<CustomerTables.Count;i++){
            if(CustomerTables[i].GetComponent<OrderTableController>().progress ==2){
                return i;
            }
        }
        return -1;
    }

    public List<int> FindUnservedCustomerTableList(){
        List<int> templist = new List<int>();
        for(int i=0;i<CustomerTables.Count;i++){
            if(CustomerTables[i].GetComponent<OrderTableController>().progress ==2){
                templist.Add(i);
            }
        }
        return templist;
    }

    public int FindAvailableCookingTable(){
        for(int i=0;i<CookingTables.Count;i++){
            if(CookingTables[i].GetComponent<CookingTableController>().IsAvailable()){
                return i;
            }
        }
        return -1;
    }

    public int FindAvailableDiningTable(){
        for(int i=0;i<DiningTables.Count;i++){
            if(DiningTables[i].GetComponent<DiningTableController>().IsAvailable()){
                return i;
            }
        }
        return -1;
    }

    public List<int> FindFoodListOnDiningTable(){
        List<int> templist = new List<int>();
        int id;
        for(int i=0;i<DiningTables.Count;i++){
            id = DiningTables[i].GetComponent<DiningTableController>().GetCurrentItemId();
            templist.Add(id);
        }
        return templist;
    }

    public int GetOrderIdByTableIndex(int index){
        return CustomerTables[index].GetComponent<OrderTableController>().order;
    }
    public int GetFoodIdByDiningTableIndex(int index){
        return DiningTables[index].GetComponent<DiningTableController>().GetCurrentItemId();
    }
    public GameObject GetTableObjectByIndex(int index){
        return CustomerTables[index];
    }
    public GameObject GetSeatObjectByIndex(int index){
        return CustomerSeats[index];
    }
    public GameObject GetCookingTableObjectByIndex(int index){
        return CookingTables[index];
    }

    public GameObject GetDiningTableObjectByIndex(int index){
        return DiningTables[index];
    }

    public GameObject GetMapObjectByIndex(int index,string name){
        if(name.Contains("Table")){
            return GetTableObjectByIndex(index);
        }else if(name.Contains("Seat")){
            return GetSeatObjectByIndex(index);
        }else if(name.Contains("Cooking")){
            return GetCookingTableObjectByIndex(index);
        }else if(name.Contains("Dining")){
            return GetDiningTableObjectByIndex(index);
        }
        return gameObject;
    }
}
