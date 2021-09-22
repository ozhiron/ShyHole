using UnityEngine;

public class MovingController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private float moveHorizontal, moveVertical;
    
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = speed;
        }

        rb.velocity = new Vector2(moveHorizontal, moveVertical);
    }    
}
