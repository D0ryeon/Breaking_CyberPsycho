
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
}
