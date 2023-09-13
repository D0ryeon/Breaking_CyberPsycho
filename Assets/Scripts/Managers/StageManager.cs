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




    [Header("Stage1")]
    [SerializeField]
    private GameObject Stag1Brick;

    public int Stage1BrickCount;



    private void Awake()
    {
        init();

    }
    void Start()
    {
       
        Stage1();
        SaveScore();
    }
    void Update()
    {
        CurrentScore.text = score.ToString();
      
        GameEnd();
    }

    public void init()
    {
        Score Currentscore = GameManager.Score.GetHighScore();

        CurrentHightScore.text = Currentscore.score.ToString();

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
        if (BrickCount == 0 || Life.GetComponent<PaddleController>().life <= 0)
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
        else
        {
            Time.timeScale = 1f;
            GameOverPopup.SetActive(false);
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

    public void Stage1()
    {

        int brickCount = brickDatas.Count;
        float currentX = -10f;
        float currentY = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {

                currentX += xOffset;
                brickPrefab.GetComponent<SpriteRenderer>().color = brickDatas[0].Color;
                brickPrefab.GetComponent<SpriteRenderer>().sprite = brickDatas[0].sprite;
                Vector3 newPosition = new Vector3(currentX, currentY,this.transform.position.z);
                brickPrefab.transform.position = newPosition;
                BrickCount++;
                var brick = SpawnBrick((BrickType)0);

                brick.PrintBrick();

            }

            currentY++;
            currentX = -10f;
        }

    }


}
