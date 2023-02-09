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

    public Inventory PlayerInventory;
    public PlayInformation playInformation;

    public void ResetGameData()
    {
        IngredientsList = new List<Item>()
        {
            new Item(){id = 0, kname="밀가루",jname="小麦粉", cost=100, have=0,kdescription = "밀을 빻은 것. 고운 정도에 따라 용도가 달라진다.",jdescription=""},
            new Item(){id = 1, kname="생선",jname="魚", cost=100, have=0,kdescription = "무슨 생선인지는 상상에 맡깁니다.",jdescription=""},
            new Item(){id = 2, kname="달걀",jname="卵", cost=100, have=0,kdescription = "완전식품. 삶아도 구워도 맛있다!",jdescription=""},
            new Item(){id = 3, kname="딸기",jname="イチゴ", cost=10, have=0,kdescription="베리베리 스트로베리.",jdescription=""},
            new Item(){id = 4, kname="버섯",jname="きのこ", cost=20, have=0,kdescription="버섯.",jdescription=""},
            new Item(){id = 5, kname="고추",jname="唐辛子", cost=30, have=0,kdescription="고추. 아키나가 아니다.",jdescription=""},
            new Item(){id = 6, kname="당근",jname="にんじん", cost=30, have=0,kdescription="당근을 흔들어주세요.",jdescription=""},
            new Item(){id = 7, kname="우유",jname="牛乳", cost=10, have=0,kdescription="포유류의 젖에서 짜낸 액체.",jdescription=""},
            new Item(){id = 8, kname="치즈",jname="チーズ", cost=50, have=0,kdescription="우유를 발효시킨 식품.",jdescription=""},
            new Item(){id = 9, kname="고기",jname="肉", cost=100, have=0,kdescription="무슨 고기인지는 상상에 맡깁니다.",jdescription=""},
            new Item(){id = 10, kname="밥", jname="ご飯",cost=40, have=0,kdescription="밥. 밥집의 밥.",jdescription=""},
            new Item(){id = 11, kname="두부",jname="豆腐", cost=30, have=0,kdescription="콩을 갈아 굳힌 것. 중요한 단백질 보충원.",jdescription=""},
            new Item(){id = 12, kname="햄",jname="ハム", cost=70, have=0,kdescription="햄!",jdescription=""},
            new Item(){id = 13, kname="토마토",jname="トマト", cost=30, have=0,kdescription="토마토마토마토마토마토마토. 멋쟁이.",jdescription=""}
        };   
        FoodList = new List<Item>()
        {
            new Item(){id=0,kname="두부튀김",jname="揚げ豆腐",cost=0,have=0,available=false,recipe = new int[]{11}},
            new Item(){id=1,kname="주먹밥",jname="おにぎり",cost=0,have=0,available=false,recipe=new int[]{10}},
            new Item(){id=2,kname="계란후라이",jname="目玉焼き",cost=0,have=0,available=false,recipe=new int[]{2}},
            new Item(){id=3,kname="햄버그",jname="ハンバーグ",cost=0,have=0,available=false,recipe=new int[]{9}},
            new Item(){id=4,kname="생선구이",jname="焼き魚",cost=0,have=0,available=false,recipe=new int[]{1}},
            new Item(){id=5,kname="우동",jname="うどん",cost=0,have=0,available=false,recipe=new int[]{0,11}},
            new Item(){id=6,kname="샐러드",jname="サラダ",cost=0,have=0,available=false,recipe=new int[]{6,13}},
            new Item(){id=7,kname="규동",jname="牛丼",cost=0,have=0,available=false,recipe=new int[]{9,10}},
            new Item(){id=8,kname="간계밥",jname="TKG",cost=0,have=0,available=false,recipe=new int[]{2,10}},
            new Item(){id=9,kname="스튜",jname="シチュー",cost=0,have=0,available=false,recipe=new int[]{4,6,7}},
            new Item(){id=10,kname="햄버거",jname="ハンバーガー",cost=0,have=0,available=false,recipe=new int[]{0,9}},
            new Item(){id=11,kname="오므라이스",jname="オムライス",cost=0,have=0,available=false,recipe=new int[]{2,10,13}},
            new Item(){id=12,kname="돈가쓰",jname="トンカツ",cost=0,have=0,available=false,recipe=new int[]{0,9}},
            new Item(){id=13,kname="피자",jname="ピザ",cost=0,have=0,available=false,recipe=new int[]{0,8,9,13}},
            new Item(){id=14,kname="크레이프",jname="クレープ",cost=0,have=0,available=false,recipe=new int[]{0,3}},
            new Item(){id=15,kname="샌드위치",jname="サンドイッチ",cost=0,have=0,available=false,recipe=new int[]{0,2,8,12,13}},
            new Item(){id=17,kname="볶음밥",jname="チャーハン",cost=0,have=0,available=false,recipe=new int[]{2,10,12}},
            new Item(){id=17,kname="초밥",jname="寿司",cost=0,have=0,available=false,recipe=new int[]{1,10}},
        };
        SkinList = new List<Item>()
        {
            new Item(){id=0,name="스킨0",available=false,description="스킨0의 설명"},
            new Item(){id=1,name="스킨1",available=false,description="스킨1의 설명"},
            new Item(){id=2,name="스킨2",available=false,description="스킨2의 설명"},
            new Item(){id=3,name="스킨3",available=false,description="스킨3의 설명"},
            new Item(){id=4,name="스킨4",available=false,description="스킨4의 설명"},
            new Item(){id=5,name="스킨5",available=false,description="스킨5의 설명"},
            new Item(){id=6,name="스킨6",available=false,description="스킨6의 설명"},
            new Item(){id=7,name="스킨7",available=false,description="스킨7의 설명"},
            new Item(){id=8,name="스킨8",available=false,description="스킨8의 설명"},
            new Item(){id=9,name="스킨9",available=false,description="스킨9의 설명"},
            new Item(){id=10,name="스킨10",available=false,description="스킨10의 설명"},
        };
        FunitureList = new List<Item>(){
            new Item(){id=0}
        };
        for(int i =0 ; i<IngredientsSpriteList.Count;i++){
            IngredientsList[i].image = IngredientsSpriteList[i];
        }
        for(int i = 0;i<FoodSpriteList.Count;i++){
            FoodList[i].image = FoodSpriteList[i];
        }
        for(int i = 0;i<SkinSpriteList.Count;i++){
            SkinList[i].image = SkinSpriteList[i];
        }
        for(int i = 0;i<FunitureSpriteList.Count;i++){
            FunitureList[i].image = FunitureSpriteList[i];
        }

        PlayerInventory = new Inventory();
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
    
    public void AddIngredients(int id, int count)
    {
        IngredientsList[id].have += count;
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

    void InsertSpriteToList(List<Sprite> SpriteList){

    }
}