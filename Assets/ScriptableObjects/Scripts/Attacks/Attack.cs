using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public class Attack : ScriptableObject
{
    [SerializeField] int attackPower = 5;
}