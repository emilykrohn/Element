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
        if (enemyMonster.health <= 0)
        {
            return false;
        }
        return true;
    }
}
