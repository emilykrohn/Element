using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    public PlayerControls playerControls;
    private float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private Rigidbody2D rb;
    private string previousDirection = "Down";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (moveDirection.x > 0)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("IdleUp", false);
            previousDirection = "Right";
        }
        else if (moveDirection.x < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("IdleUp", false);
            previousDirection = "Left";
        }
        else if (moveDirection.y > 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("IdleUp", false);
            previousDirection = "Up";
        }
        else if (moveDirection.y < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Idle", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("IdleUp", false);
            previousDirection = "Down";
        }
        else if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);

            animator.SetBool("Idle", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("IdleUp", false);
            if (previousDirection == "Down")
            {
                animator.SetBool("Idle", true);
            }
            else if (previousDirection == "Up")
            {
                animator.SetBool("IdleUp", true);
            }
            else if (previousDirection == "Left")
            {
                animator.SetBool("IdleLeft", true);
            }
            else if (previousDirection == "Right")
            {
                animator.SetBool("IdleRight", true);
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
