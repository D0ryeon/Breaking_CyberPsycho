using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{

    
    enum Buttons
    {
        Start,
        Score,
        Option
    }

    enum Texts
    {

    }

    enum GameObjects
    {

    }

    enum Images
    {

    }

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.Score).gameObject.AddUIEvent(OnButtonClicked);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        // ToDo 팝업 창 종료 이벤트 로직 추가 필요
    }
}
