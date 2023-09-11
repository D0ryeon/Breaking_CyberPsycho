using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    static GameManager Instance { get { Init(); return s_instance; } }

    #region Managers
    DataManager _data = new DataManager();
    ItemManager _item = new ItemManager();
    ResourceManager _resource = new ResourceManager();
    ScenesManager _scene = new ScenesManager();
    ScoreManager _score = new ScoreManager();
    SettingManager _setting = new SettingManager();
    SoundManager _sound = new SoundManager();
    StageManager _stage = new StageManager();

    public static DataManager Data { get { return Instance._data; } }
    public static ItemManager Item { get { return Instance._item; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static ScenesManager Scene { get {  return Instance._scene; } }
    public static ScoreManager Score { get {  return Instance._score; } }
    public static SettingManager Setting { get {  return Instance._setting; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static StageManager Stage { get {  return Instance._stage; } }
    #endregion



    void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject gameObject = GameObject.Find("@GameManager");
            if (gameObject == null)
            {
                gameObject = new GameObject { name = "@GameManager" };
                gameObject.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(gameObject);
            s_instance = gameObject.GetComponent<GameManager>();

            s_instance._data.Init();
        }
    }

    public static void Clear()
    {

    }
}
