using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private bool faceRight = true;
    public Animator ani;
    public float Speed = 3f, maxSpeed = 10f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Handle_movement();
    }
    
    void Handle_movement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * Speed * move);
        // gioi han toc di chuyen
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        // Ma sat gia tao
        rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        // Quay mat ve phia di chuyen
        if (!faceRight && move > 0)
            flipFace();
        if (faceRight && move < 0)
            flipFace();
        ani.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    void flipFace()
    {
        faceRight = !faceRight;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x = Scale.x * -1;
        transform.localScale = Scale;
    }
}
