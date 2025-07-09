using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float activationDistance = 3f;
    [SerializeField] float attackRange = 0.1f;
    [SerializeField] GameObject body;
    [SerializeField] float speed;
    Rigidbody RB;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - body.transform.position;
        if (Physics.Raycast(body.transform.position,direction,out hit,activationDistance))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("activated");
                if(Vector3.Distance(body.transform.position, player.transform.position) <= attackRange)
                {
                    Attack();
                }
                else
                {
                    Move(direction);
                }
            }
        }
    }
    void Move(Vector3 direction)
    {
        Debug.Log("Moving" + direction);
        if(direction.x<0)
        {
            RB.linearVelocity = new Vector3(-speed,0,0);
        }
        if (direction.x > 0)
        {
            RB.linearVelocity = new Vector3(speed, 0, 0);
        }
    }
    void Attack()
    {
        Debug.Log("Attacking");
    }
}
