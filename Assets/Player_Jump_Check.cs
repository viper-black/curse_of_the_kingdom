using UnityEngine;

public class Player_Jump_Check : MonoBehaviour
{
    public bool ableToJump;
    private void OnTriggerEnter(Collider other)
    {
        ableToJump = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ableToJump = false;
    }
}
