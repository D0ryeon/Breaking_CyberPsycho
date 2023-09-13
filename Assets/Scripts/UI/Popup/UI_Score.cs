using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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

    enum Texts
    {
        Rank,
        Name,
        Score
    }

    enum GameObjects
    {
        PlayerScore1,
        PlayerScore2,
        PlayerScore3,
        PlayerScore4,
    }

    public override void Init()
    {
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        SetPlayerScore();

        GetButton((int)Buttons.Exit).gameObject.AddUIEvent(OnExitButtonClicked);
    }

    private void SetPlayerScore()
    {
        List<Score>scoreList = GameManager.Score.GetTopFiveScore();

        if (scoreList == null || scoreList.Count == 0)
            return;

        string[] names = Enum.GetNames(typeof(GameObjects));

        for (int i = 0; i < scoreList.Count; i++)
        {
            if (i == 5)
                continue;

            GameObject playerScore = GetGameObject(i) ;
            TMP_Text name = Util.FindChild<TMP_Text>(playerScore, Texts.Name.ToString());
            TMP_Text score = Util.FindChild<TMP_Text>(playerScore, Texts.Score.ToString());

            name.text = scoreList[i].name;
            score.text = scoreList[i].score.ToString();
        }
    }

    public void OnExitButtonClicked(PointerEventData data)
    {
        ClosePopupUI();
    }
}
