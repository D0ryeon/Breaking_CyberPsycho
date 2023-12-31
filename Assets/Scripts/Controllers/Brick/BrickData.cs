
using UnityEngine;

[CreateAssetMenu(fileName = "BrickData", menuName = "Scriptable Object/BrickData", order = int.MaxValue)]
public class BrickData : ScriptableObject
{
    [SerializeField]
    private string brickName;
    public string BrickName { get { return brickName; } }
    [SerializeField]
    private int hp;
    public  int Hp { get { return hp; } }

    [SerializeField]
    private int score;
    public int Score { get { return score; } }

    [SerializeField]
    private Color color;
    public Color Color { get { return color; } }

    public Sprite sprite;


}
