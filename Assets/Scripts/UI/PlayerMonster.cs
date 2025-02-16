using UnityEngine;

public class PlayerMonster : MonoBehaviour
{
    [SerializeField] Monster playerMonster;
    EnemyMonster enemyMonster;

    void Start()
    {
        enemyMonster = GetComponent<EnemyMonster>();
    }

    public bool FirstAttack()
    {
        enemyMonster.health -= playerMonster.firstAttack.attackPower;
        Debug.Log(enemyMonster.health);
        if (enemyMonster.health <= 0)
        {
            Debug.Log("Enemy Defeated");
            return false;
        }
        return true;
    }
}
