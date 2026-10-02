using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody RB;
    public float speed = 5f;
    public bool isRagdolled = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRagdolled)
            return;
        
        Vector3 vel = new Vector3(0, RB.linearVelocity.y, 0);
        if (Keyboard.current.wKey.isPressed)
        {
            vel += transform.forward * speed;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            vel += transform.forward * -speed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel += transform.right * -speed;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            vel += transform.right * speed;
        }
        RB.linearVelocity = vel;
    }


}
