using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Scriptable Objects/Monster")]
public class Monster : ScriptableObject
{
    [SerializeField] int health = 10;
    [SerializeField] Attack firstAttack;
    [SerializeField] Attack secondAttack;
    [SerializeField] Attack thirdAttack;
    [SerializeField] Attack fourthAttack;
}
