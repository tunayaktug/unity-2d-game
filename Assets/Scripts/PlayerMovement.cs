using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    float speedAmount = 10f;
    float jumpAmount = 5f;
    public Animator animator;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.linearVelocity.y, 0f))
        {
            rgb.AddForce(Vector3.up * jumpAmount , ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

        if (animator.GetBool("isJumping") && Mathf.Approximately(rgb.linearVelocity.y, 0f))
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f,-180f,0f); 
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
