using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Scriptable Objects/Monster")]
public class Monster : ScriptableObject
{
    public int health = 10;
    public Attack firstAttack;
    public Attack secondAttack;
    public Attack thirdAttack;
    public Attack fourthAttack;
}
