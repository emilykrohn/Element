using UnityEngine;

public class Encounter : MonoBehaviour
{
    Rigidbody2D rb;
    float timer = 0f;
    float cooldown = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        timer += Time.deltaTime;
        if (other.CompareTag("Grass") && rb.linearVelocity != Vector2.zero && timer > cooldown)
        {
            Debug.Log("Encounter");
            timer = 0f;
        }
    }
}
