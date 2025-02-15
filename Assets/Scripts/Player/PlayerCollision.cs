using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Encounter"))
        {
            Debug.Log("Encounter");
        }
    }
}
