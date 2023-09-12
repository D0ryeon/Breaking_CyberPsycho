using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Score : UI_Popup
{
    void Start()
    {
        Init();
    }

    enum Buttons
    {
        Exit,
    }

    public override void Init()
    {
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.Exit).gameObject.AddUIEvent(OnExitButtonClicked);
    }

    public void OnExitButtonClicked(PointerEventData data)
    {
        ClosePopupUI();
    }
}
