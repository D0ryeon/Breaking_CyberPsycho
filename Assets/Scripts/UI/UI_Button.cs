using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Button : UI_Base
{

    
    enum Buttons
    {
        Start,
        Score,
        Option,
        Exit,
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
        Init();
    }

    public override void Init()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.Start).gameObject.AddUIEvent(OnStartButtonClicked);
        GetButton((int)Buttons.Score).gameObject.AddUIEvent(OnScoreButtonClicked);
        GetButton((int)Buttons.Option).gameObject.AddUIEvent(OnOptionButtonClicked);
        GetButton((int)Buttons.Exit).gameObject.AddUIEvent(OnExitButtonClicked);
    }


    public void OnStartButtonClicked(PointerEventData data)
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnScoreButtonClicked(PointerEventData data)
    {
        GameManager.UI.ShowPopupUI<UI_Popup>(Buttons.Score.ToString());
    }

    public void OnOptionButtonClicked(PointerEventData data)
    {
        GameManager.UI.ShowPopupUI<UI_Popup>(Buttons.Option.ToString());
    }

    public void OnExitButtonClicked(PointerEventData data)
    {
        Application.Quit();
    }
}
