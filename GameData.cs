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
    public List<Syokuzai> SyokuzaiList = new List<Syokuzai>();
    public List<Food> FoodList = new List<Food>();
    public List<Skin> SkinList = new List<Skin>();
    public PlayInformation playInformation;

    public void ResetGameData()
    {
        SyokuzaiList = new List<Syokuzai>()
        {
            new Syokuzai(){id = 0, name="밀가루", cost=100, have=0,description = "밀을 빻은 것. 고운 정도에 따라 용도가 달라진다."},
            new Syokuzai(){id = 1, name="생선", cost=100, have=0,description = "무슨 생선인지는 상상에 맡깁니다."},
            new Syokuzai(){id = 2, name="달걀", cost=100, have=0,description = "완전식품. 삶아도 구워도 맛있다!"},
            new Syokuzai(){id = 3, name="딸기", cost=10, have=0,description="베리베리 스트로베리."},
            new Syokuzai(){id = 4, name="버섯", cost=20, have=0,description="버섯."},
            new Syokuzai(){id = 5, name="고추", cost=30, have=0,description="고추. 아키나가 아니다."},
            new Syokuzai(){id = 6, name="당근", cost=30, have=0,description="당근을 흔들어주세요."},
            new Syokuzai(){id = 7, name="우유", cost=10, have=0,description="포유류의 젖에서 짜낸 액체."},
            new Syokuzai(){id = 8, name="치즈", cost=50, have=0,description="우유를 발효시킨 식품."},
            new Syokuzai(){id = 9, name="고기", cost=100, have=0,description="무슨 고기인지는 상상에 맡깁니다."},
            new Syokuzai(){id = 10, name="밥", cost=40, have=0,description="밥. 밥집의 밥."},
            new Syokuzai(){id = 11, name="두부", cost=30, have=0,description="콩을 갈아 굳힌 것. 중요한 단백질 보충원."},
            new Syokuzai(){id = 12, name="햄", cost=70, have=0,description="햄!"},
            new Syokuzai(){id = 13, name="토마토", cost=30, have=0,description="토마토마토마토마토마토마토. 멋쟁이."}
        };
        FoodList = new List<Food>()
        {
            new Food(){id=0,name="두부튀김",cost=0,have=0,available=false,recipe = new int[]{11}},
            new Food(){id=1,name="주먹밥",cost=0,have=0,available=false,recipe=new int[]{10}},
            new Food(){id=2,name="계란후라이",cost=0,have=0,available=false,recipe=new int[]{2}},
            new Food(){id=3,name="햄버그",cost=0,have=0,available=false,recipe=new int[]{9}},
            new Food(){id=4,name="생선구이",cost=0,have=0,available=false,recipe=new int[]{1}},
            new Food(){id=5,name="우동",cost=0,have=0,available=false,recipe=new int[]{0,11}},
            new Food(){id=6,name="샐러드",cost=0,have=0,available=false,recipe=new int[]{6,13}},
            new Food(){id=7,name="규동",cost=0,have=0,available=false,recipe=new int[]{9,10}},
            new Food(){id=8,name="TKG",cost=0,have=0,available=false,recipe=new int[]{2,10}},
            new Food(){id=9,name="스튜",cost=0,have=0,available=false,recipe=new int[]{4,6,7}},
            new Food(){id=10,name="햄버거",cost=0,have=0,available=false,recipe=new int[]{0,9}},
            new Food(){id=11,name="오므라이스",cost=0,have=0,available=false,recipe=new int[]{2,10,13}},
            new Food(){id=12,name="돈가쓰",cost=0,have=0,available=false,recipe=new int[]{0,9}},
            new Food(){id=13,name="피자",cost=0,have=0,available=false,recipe=new int[]{0,8,9,13}},
            new Food(){id=14,name="크레이프",cost=0,have=0,available=false,recipe=new int[]{0,3}},
            new Food(){id=15,name="샌드위치",cost=0,have=0,available=false,recipe=new int[]{0,2,8,12,13}},
            new Food(){id=17,name="볶음밥",cost=0,have=0,available=false,recipe=new int[]{2,10,12}},
        };
        SkinList = new List<Skin>()
        {
            new Skin(){id=0,name="스킨0",available=false,description="스킨0의 설명"},
            new Skin(){id=1,name="스킨1",available=false,description="스킨1의 설명"},
            new Skin(){id=2,name="스킨2",available=false,description="스킨2의 설명"},
            new Skin(){id=3,name="스킨3",available=false,description="스킨3의 설명"},
            new Skin(){id=4,name="스킨4",available=false,description="스킨4의 설명"},
            new Skin(){id=5,name="스킨5",available=false,description="스킨5의 설명"},
            new Skin(){id=6,name="스킨6",available=false,description="스킨6의 설명"},
            new Skin(){id=7,name="스킨7",available=false,description="스킨7의 설명"},
            new Skin(){id=8,name="스킨8",available=false,description="스킨8의 설명"},
            new Skin(){id=9,name="스킨9",available=false,description="스킨9의 설명"},
            new Skin(){id=10,name="스킨10",available=false,description="스킨10의 설명"},
        };
        playInformation = new PlayInformation(){Day=0,IsEnded=false,Money=0};
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
    
    public void AddSyokuzai(int id, int count)
    {
        SyokuzaiList[id].have += count;
    }
}