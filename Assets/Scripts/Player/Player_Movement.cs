using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody RB;
    float horizontalMovement;

    [SerializeField] float horizontalSpeed = 5f;
    [SerializeField] float jumpPower = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        RB.linearVelocity = new Vector3(horizontalMovement * horizontalSpeed, RB.linearVelocity.y, 0);   
    }

    void Jump()
    {
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.down, 0.51f))
        {
            RB.linearVelocity = new Vector3(RB.linearVelocity.x, jumpPower, 0);
        }
    }
}
