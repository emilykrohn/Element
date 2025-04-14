using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public InputSystem_Actions playerControls;
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    GridLayout gridLayout;
    float timer = 0;
    float cooldown = 0.2f;
    bool canMove = true;
    float cellSize;

    private void Awake()
    {
        playerControls = new InputSystem_Actions();
    }

    void Start()
    {
        gridLayout = transform.parent.GetComponent<GridLayout>();
        cellSize = gridLayout.cellSize.x;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            canMove = true;
        }
        moveDirection = move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 playerPosition = new Vector2(transform.position.x + moveDirection.x + (cellSize / 2), transform.position.y + moveDirection.y + (cellSize / 2));
            Vector3Int cellPosition = gridLayout.WorldToCell(playerPosition);
            transform.position = gridLayout.CellToWorld(cellPosition);
            canMove = false;
            timer = 0;
        }
    }
}
