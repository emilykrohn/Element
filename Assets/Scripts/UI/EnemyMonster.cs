using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    [SerializeField] Monster enemyMonster;
    public int health = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = enemyMonster.health;
    }

}
