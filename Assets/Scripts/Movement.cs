using UnityEngine;

public class Movement : MonoBehaviour
{

    CharacterController cc;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight =  1.5f;
    Vector3 velocity;

    bool groundedPlayer;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        groundedPlayer = cc.isGrounded;

        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
