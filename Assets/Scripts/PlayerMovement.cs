using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private SpriteRenderer wormSprite;
    [SerializeField]private bool useArrows;
    [SerializeField]private float jumpHeight;
    [SerializeField]private float moveSpeed;
    [SerializeField]private bool isGrounded;
    private Rigidbody2D rb2d;

    void Start () {
        wormSprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if(useArrows == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        wormSprite.flipX = false;
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        wormSprite.flipX = true;
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpHeight);
            isGrounded = false;
        }
    }
}
