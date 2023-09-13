using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum BrickType { Normal, Red, Blue, Boss }

public class StageManager :MonoBehaviour
{
    static public int score = 0;
    static public int BrickCount = 0;
    public GameObject Life;
    public GameObject startGame;
    [SerializeField]
    private GameObject Ball;

    [SerializeField]
    private List<BrickData> brickDatas;
    [SerializeField]
    private GameObject brickPrefab;
    public float xOffset = 2f;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI CurrentScore;
    [SerializeField]
    private TextMeshProUGUI YourScore;
    [SerializeField]
    private TextMeshProUGUI CurrentHightScore;
    [Header("GameOverPopUpUI")]
    [SerializeField]
    private GameObject GameOverPopup;
    [SerializeField]
    private TMP_InputField userName;
    [SerializeField]
    private Button BtnEnter;
    [SerializeField]
    private TextMeshProUGUI HightScore;
    [Header("GameNextStageUI")]
    [SerializeField]
    private Button BtnNextStage;
    [SerializeField]

    private GameObject NextStagePopup;
    public int Next = 0;
    int GameoverCount = 1;


    [Header("Stage1")]
    [SerializeField]
    private GameObject Stag1Brick;

  




    void Start()
    {
        init();
        Stage1(Next);
        SaveScore();
      
        BtnNextStage.onClick.AddListener(() =>
        {
            NextStageSet();
        });
    }
    void Update()
    {
        CurrentScore.text = score.ToString();
      
        GameEnd();
        if (BrickCount == 0 && NextStagePopup.activeSelf == false)
        {
            StagePopup();
        }
        
    }
    public void NextStageSet()
    {
        Time.timeScale = 0;
        startGame.SetActive(true);
        Ball.transform.localPosition = new Vector3(0f, 0f, 0f);
        if(Next< brickDatas.Count+1)
        {
            Next++;
        }
    
        Stage1(Next);
        NextStagePopup.SetActive(false);
    }

    public void init()
    {
        Next = 0;
        BrickCount = 0;
        GameoverCount = 1;
        Score Currentscore = GameManager.Score.GetHighScore();
        CurrentHightScore.text = Currentscore.score.ToString();
        NextStagePopup.SetActive(false);
        GameOverPopup.SetActive(false);
        score = 0;


    }



    public BrickController SpawnBrick(BrickType type)
    {

        var newBrick = Instantiate(brickPrefab).GetComponent<BrickController>();
        newBrick.transform.SetParent(Stag1Brick.transform);
        newBrick.brickData = brickDatas[(int)type];
        newBrick.name = newBrick.brickData.BrickName;
        return newBrick;
    }

    public void GameEnd()
    {
        if ( Life.GetComponent<PaddleController>().life <= 0 || Next ==4 || GameoverCount >brickDatas.Count)
        {
            
            Time.timeScale = 0f; // stage1 end
            Score Hscore = GameManager.Score.GetHighScore();
            if (score >= Hscore.score)
            {
                YourScore.text = score.ToString();
                HightScore.text = YourScore.text;
            }
            else 
            {
                YourScore.text = score.ToString();
                HightScore.text = Hscore.score.ToString();
            }
           
            GameOverPopup.SetActive(true);
        }
        else if(NextStagePopup.activeSelf == false)
        {
            Time.timeScale = 1f;          
        }

    }

    public void SaveScore()
    {

        
        BtnEnter.onClick.AddListener(() =>
        {   if(userName.text!=null)
            {
                  Score newscore = new Score(score, userName.text);
                  GameManager.Score.SaveScore(newscore);
                  SceneManager.LoadScene("StartScene");

            }
             else 
            {
                
               
                Score newscore = new Score(score,"Guest");
                GameManager.Score.SaveScore(newscore);
                SceneManager.LoadScene("StartScene");
               
                // 
            }
        }); 
    }

    public void Stage1(int Level)
    {

        int brickCount = brickDatas.Count;
        float currentX = -10f;
        float currentY = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {

                currentX += xOffset;
                brickPrefab.GetComponent<SpriteRenderer>().color = brickDatas[Level].Color;
                brickPrefab.GetComponent<SpriteRenderer>().sprite = brickDatas[Level].sprite;
                Vector3 newPosition = new Vector3(currentX, currentY,this.transform.position.z);
                brickPrefab.transform.position = newPosition;
                BrickCount++;
                var brick = SpawnBrick((BrickType)Level);

                brick.PrintBrick();

            }

            currentY++;
            currentX = -10f;
        }
       

    }

    public void StagePopup()
    {
       
            Time.timeScale = 0f;
            NextStagePopup.SetActive(true);
        }
      
        
    }
    

