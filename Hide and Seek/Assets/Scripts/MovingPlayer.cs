//Borrowed from Dr. Goadrich's code for "Townies"
using UnityEngine;

public class MovingPlayer: MonoBehaviour
{

    private Rigidbody2D RB2D;
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    public float runSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        GameManager.Instance.playerFacing = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if(Mathf.Abs(vertical) > 0.15f || Mathf.Abs(horizontal) > 0.15f) {
            GameManager.Instance.playerFacing = new Vector2(vertical, horizontal);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        RB2D.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

}