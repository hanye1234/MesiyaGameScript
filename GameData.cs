using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

    public Dictionary<int, string> RyouriDict = new Dictionary<int, string>()
    {
        {0,"두부 튀김"},
        {1,"주먹밥"},
        {2,"계란 후라이"},
        {3,"햄버그"},
        {4,"생선구이"},
        {5,"우동"},
        {6,"샐러드"},
        {7,"규동"},
        {8,"TKG"},
        {9,"스튜"},
        {10,"햄버거"},
        {11,"오므라이스"},
        {12,"돈가쓰"},
        {13,"피자"},
        {14,"크레이프"},
        {15,"샌드위치"},
        {16,"볶음밥"},
    };
    public Dictionary<int, string> ZairyoDict = new Dictionary<int, string>()
    {
        {0,"밀가루"},
        {1,"생선"},
        {2,"달걀"},
        {3,"딸기"},
        {4,"버섯"},
        {5,"고추"},
        {6,"당근"},
        {7,"우유"},
        {8,"치즈"},
        {9,"고기"},
        {10,"밥"},
        {11,"두부"},
        {12,"햄"},
        {13,"토마토"}
    };
    public List<Item> IngredientsList = new List<Item>();
    public List<Item> FoodList = new List<Item>();
    public List<Item> SkinList = new List<Item>();
    public List<Item> FunitureList = new List<Item>();
    public List<Sprite> FoodSpriteList;
    public List<Sprite> IngredientsSpriteList;
    public List<Sprite> SkinSpriteList;
    public List<Sprite> FunitureSpriteList;

    public Inventory PlayerInventory= new Inventory(){
        Ingredients = new List<InventoryItem>(),
        Foods = new List<InventoryItem>(),
        Funitures = new List<InventoryItem>(),
        Skins = new List<InventoryItem>()
    };
    public PlayInformation playInformation;
    public GameObject AlertWindow;
    void Awake()
    {

    }
    void Start() {
        AlertWindow = GameObject.Find("AlertUI").gameObject.transform.GetChild(0).gameObject;
        AlertWindow.SetActive(false);
    }
    public void ResetGameData()
    {
        IngredientsList = new List<Item>()
        {
            new Item(){id = 0, kname="밀가루",jname="小麦粉", cost=100, have=0,kdescription = "밀을 빻은 것. 고운 정도에 따라 용도가 달라진다.",jdescription="",property="Ingredients"},
            new Item(){id = 1, kname="생선",jname="魚", cost=100, have=0,kdescription = "무슨 생선인지는 상상에 맡깁니다.",jdescription="",property="Ingredients"},
            new Item(){id = 2, kname="달걀",jname="卵", cost=100, have=0,kdescription = "완전식품. 삶아도 구워도 맛있다!",jdescription="",property="Ingredients"},
            new Item(){id = 3, kname="딸기",jname="イチゴ", cost=10, have=0,kdescription="베리베리 스트로베리.",jdescription="",property="Ingredients"},
            new Item(){id = 4, kname="버섯",jname="きのこ", cost=20, have=0,kdescription="버섯.",jdescription="",property="Ingredients"},
            new Item(){id = 5, kname="고추",jname="唐辛子", cost=30, have=0,kdescription="고추. 아키나가 아니다.",jdescription="",property="Ingredients"},
            new Item(){id = 6, kname="당근",jname="にんじん", cost=30, have=0,kdescription="당근을 흔들어주세요.",jdescription="",property="Ingredients"},
            new Item(){id = 7, kname="우유",jname="牛乳", cost=10, have=0,kdescription="포유류의 젖에서 짜낸 액체.",jdescription="",property="Ingredients"},
            new Item(){id = 8, kname="치즈",jname="チーズ", cost=50, have=0,kdescription="우유를 발효시킨 식품.",jdescription="",property="Ingredients"},
            new Item(){id = 9, kname="고기",jname="肉", cost=100, have=0,kdescription="무슨 고기인지는 상상에 맡깁니다.",jdescription="",property="Ingredients"},
            new Item(){id = 10, kname="밥", jname="ご飯",cost=40, have=0,kdescription="밥. 밥집의 밥.",jdescription="",property="Ingredients"},
            new Item(){id = 11, kname="두부",jname="豆腐", cost=30, have=0,kdescription="콩을 갈아 굳힌 것. 중요한 단백질 보충원.",jdescription="",property="Ingredients"},
            new Item(){id = 12, kname="햄",jname="ハム", cost=70, have=0,kdescription="햄!",jdescription="",property="Ingredients"},
            new Item(){id = 13, kname="토마토",jname="トマト", cost=30, have=0,kdescription="토마토마토마토마토마토마토. 멋쟁이.",jdescription="",property="Ingredients"}
        };   
        FoodList = new List<Item>()
        {
            new Item(){id=0,kname="두부튀김",jname="揚げ豆腐",cost=0,have=0,available=false,recipe = new int[]{11},property="Foods"},
            new Item(){id=1,kname="주먹밥",jname="おにぎり",cost=0,have=0,available=false,recipe=new int[]{10},property="Foods"},
            new Item(){id=2,kname="계란후라이",jname="目玉焼き",cost=0,have=0,available=false,recipe=new int[]{2},property="Foods"},
            new Item(){id=3,kname="햄버그",jname="ハンバーグ",cost=0,have=0,available=false,recipe=new int[]{9},property="Foods"},
            new Item(){id=4,kname="생선구이",jname="焼き魚",cost=0,have=0,available=false,recipe=new int[]{1},property="Foods"},
            new Item(){id=5,kname="우동",jname="うどん",cost=0,have=0,available=false,recipe=new int[]{0,11},property="Foods"},
            new Item(){id=6,kname="샐러드",jname="サラダ",cost=0,have=0,available=false,recipe=new int[]{6,13},property="Foods"},
            new Item(){id=7,kname="규동",jname="牛丼",cost=0,have=0,available=false,recipe=new int[]{9,10},property="Foods"},
            new Item(){id=8,kname="간계밥",jname="TKG",cost=0,have=0,available=false,recipe=new int[]{2,10},property="Foods"},
            new Item(){id=9,kname="스튜",jname="シチュー",cost=0,have=0,available=false,recipe=new int[]{4,6,7},property="Foods"},
            new Item(){id=10,kname="햄버거",jname="ハンバーガー",cost=0,have=0,available=false,recipe=new int[]{0,9},property="Foods"},
            new Item(){id=11,kname="오므라이스",jname="オムライス",cost=0,have=0,available=false,recipe=new int[]{2,10,13},property="Foods"},
            new Item(){id=12,kname="돈가쓰",jname="トンカツ",cost=0,have=0,available=false,recipe=new int[]{0,9},property="Foods"},
            new Item(){id=13,kname="피자",jname="ピザ",cost=0,have=0,available=false,recipe=new int[]{0,8,9,13},property="Foods"},
            new Item(){id=14,kname="크레이프",jname="クレープ",cost=0,have=0,available=false,recipe=new int[]{0,3},property="Foods"},
            new Item(){id=15,kname="샌드위치",jname="サンドイッチ",cost=0,have=0,available=false,recipe=new int[]{0,2,8,12,13},property="Foods"},
            new Item(){id=17,kname="볶음밥",jname="チャーハン",cost=0,have=0,available=false,recipe=new int[]{2,10,12},property="Foods"},
            new Item(){id=17,kname="초밥",jname="寿司",cost=0,have=0,available=false,recipe=new int[]{1,10},property="Foods"},
        };
        SkinList = new List<Item>()
        {
            new Item(){id=0,name="스킨0",available=false,description="스킨0의 설명",property="Skins"},
            new Item(){id=1,name="스킨1",available=false,description="스킨1의 설명",property="Skins"},
            new Item(){id=2,name="스킨2",available=false,description="스킨2의 설명",property="Skins"},
            new Item(){id=3,name="스킨3",available=false,description="스킨3의 설명",property="Skins"},
            new Item(){id=4,name="스킨4",available=false,description="스킨4의 설명",property="Skins"},
            new Item(){id=5,name="스킨5",available=false,description="스킨5의 설명",property="Skins"},
            new Item(){id=6,name="스킨6",available=false,description="스킨6의 설명",property="Skins"},
            new Item(){id=7,name="스킨7",available=false,description="스킨7의 설명",property="Skins"},
            new Item(){id=8,name="스킨8",available=false,description="스킨8의 설명",property="Skins"},
            new Item(){id=9,name="스킨9",available=false,description="스킨9의 설명",property="Skins"},
            new Item(){id=10,name="스킨10",available=false,description="스킨10의 설명",property="Skins"},
        };
        FunitureList = new List<Item>(){
            new Item(){id=0,name="가구1",available=false,cost=100,description="가구1의 설명",property="Funiture0"},
            new Item(){id=1,name="가구2",available=false,cost=200,description="가구2의 설명",property="Funiture1"},
            new Item(){id=2,name="가구3",available=false,cost=300,description="가구3의 설명",property="Funiture1"},
            new Item(){id=3,name="가구4",available=false,cost=500,description="가구4의 설명",property="Funiture2"},
        
        };
        for(int i =0 ; i<Mathf.Min(IngredientsSpriteList.Count,IngredientsList.Count);i++){
            IngredientsList[i].image = IngredientsSpriteList[i];
        }
        for(int i = 0;i<Mathf.Min(FoodSpriteList.Count,FoodList.Count);i++){
            FoodList[i].image = FoodSpriteList[i];
        }
        for(int i = 0;i<Mathf.Min(SkinSpriteList.Count,SkinList.Count);i++){
            SkinList[i].image = SkinSpriteList[i];
        }
        for(int i = 0;i<Mathf.Min(FunitureSpriteList.Count,FunitureList.Count);i++){
            FunitureList[i].image = FunitureSpriteList[i];
        }

        PlayerInventory= new Inventory(){
        Ingredients = new List<InventoryItem>(),
        Foods = new List<InventoryItem>(),
        Funitures = new List<InventoryItem>(),
        Skins = new List<InventoryItem>()
    };
        for(int i=0;i<IngredientsList.Count;i++){
            PlayerInventory.Ingredients.Add(new InventoryItem(){id=i,have=0});
        }
        for(int i=0;i<FoodList.Count;i++){
            PlayerInventory.Foods.Add(new InventoryItem(){id=i,have=0});
        }
        for(int i=0;i<FunitureList.Count;i++){
            PlayerInventory.Funitures.Add(new InventoryItem(){id=i,equipped=false,available=false});
        }
        for(int i=0;i<SkinList.Count;i++){
            PlayerInventory.Skins.Add(new InventoryItem(){id=i,equipped=false,available=false});
        }
        
        playInformation = new PlayInformation(){Day=0,IsEnded=false,Money=0,Language=0};
        ChangeGameDataLanguage(playInformation.Language);
    }

    public void AddMoney(int M)
    {
        playInformation.Money = playInformation.Money + M;
        if(playInformation.Money>99999){
            playInformation.Money = 99999;
        }
        else if(playInformation.Money<0){
            playInformation.Money = 0;
        }
    }
    
    public bool CanIBuyIt(int M){
        if(playInformation.Money<M){
            return false;
        }
        return true;
    }

    public bool CanIBuyItWithAlertWindow(int M){
        if(playInformation.Money<M){
            AlertWindow.SetActive(true);
            return false;
        }
        return true;
    }

    public void AddIngredients(int id, int count)
    {
        PlayerInventory.Ingredients[id].have += count;
    }

    public void AddItem(Item item){
        if(item.property.Contains("Ingredient")){
            PlayerInventory.Ingredients[item.id].have += 1;
        }else if(item.property.Contains("Skin")){
            PlayerInventory.Skins[item.id].available = true;
        }else if(item.property.Contains("Funiture")){
            PlayerInventory.Funitures[item.id].available = true;
        }else if(item.property.Contains("Food")){
            PlayerInventory.Foods[item.id].available = true;
        }else{
            Debug.Log("AddItem실행불가");
        }
    }
    public void ChangeGameDataLanguage(int LanguageId){
        foreach(Item item in IngredientsList){
            if(LanguageId==0){
                item.name = item.kname;
                item.description = item.kdescription;
            }else if(LanguageId==1){
                item.name = item.jname;
                item.description = item.jdescription;
            }
        }
    }

    public int ItemPropertyStringToInt(string propertyString){
        if(propertyString.Contains("0")){
            return 0;
        }else if(propertyString.Contains("1")){
            return 1;
        }else if(propertyString.Contains("2")){
            return 2;
        }else if(propertyString.Contains("3")){
            return 3;
        }
        return -1;
    }

}