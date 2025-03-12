using UnityEngine;

public class PlayerMonster : MonoBehaviour
{
    [SerializeField] Monster playerMonster;
    EnemyMonster enemyMonster;
    public int health = 10;

    void Start()
    {
        enemyMonster = GetComponent<EnemyMonster>();
        health = playerMonster.health;
    }

    public bool FirstAttack()
    {
        enemyMonster.health -= playerMonster.firstAttack.attackPower;
        if (enemyMonster.health <= 0)
        {
            return false;
        }
        return true;
    }
}
