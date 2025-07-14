using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float activationDistance = 3f;
    [SerializeField] float attackRange = 0.1f;
    [SerializeField] GameObject body;
    [SerializeField] float speed;
    [SerializeField] float looseInterestDistance = 15f;
    GameObject player;

    bool activated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - body.transform.position;
        if(!activated)
        {
            if (Physics.Raycast(body.transform.position, direction, out hit, activationDistance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    activated = true;
                }
            }
        }
        if(activated)
        {
            if(Vector3.Distance(player.transform.position, transform.position) < looseInterestDistance)
            {
                if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
                {
                    Attack();
                }
                else
                {
                    Move(direction);
                }
            }
            else
            {
                activated = false;
            }
        }
    }
    void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void Attack()
    {
        Debug.Log("Attacking");
    }
}
