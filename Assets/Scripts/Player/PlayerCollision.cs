using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    float timer = 0f;
    public float cooldownEncounter = 3f;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Encounter"))
        {
            timer += Time.deltaTime;
            if (timer > cooldownEncounter)
            {
                Debug.Log("Encounter");
                timer = 0f;
            }
        }
    }
}
