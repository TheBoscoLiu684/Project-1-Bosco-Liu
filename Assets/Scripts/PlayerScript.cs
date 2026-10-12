using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody RB;
    public float speed = 5f;
    public bool isRagdolled = false;
    public Animator anim;
    public float rotationSpeed;
    public bool isGettingUp = false;
    public Transform checkPoint;
    public RagdollTrigger ragdoll;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetToCheckPoint();
            Debug.Log("Reset");
        }

        if (isRagdolled || isGettingUp)
            return;
        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            move += Vector3.forward;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            move += Vector3.back;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            move += Vector3.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            move += Vector3.right;
        }

        if(move != Vector3.zero)
        {
            move = move.normalized;
            RB.linearVelocity = new Vector3(move.x * speed, RB.linearVelocity.y, move.z * speed);
            Quaternion location = Quaternion.LookRotation(move);
            Quaternion rotateTowards = Quaternion.RotateTowards(RB.rotation, location, rotationSpeed * Time.fixedDeltaTime);
            RB.MoveRotation(rotateTowards);
        }
        else
        {
            RB.linearVelocity = new Vector3(0, RB.linearVelocity.y, 0);
        }

        anim.SetFloat("Speed", RB.linearVelocity.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if(collidedObject.CompareTag("Finish"))
        {
            GameManager.instance.win = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("WIN");
            
        }
    }

    public void ResetToCheckPoint()
    {
        if (checkPoint == null)
            return;

        ragdoll.RagdollReset();
        RB.linearVelocity = Vector3.zero;
        RB.angularVelocity = Vector3.zero;
        transform.position = checkPoint.position;
        transform.rotation = checkPoint.rotation;
        
    }
}
