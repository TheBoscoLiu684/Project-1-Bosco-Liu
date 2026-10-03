using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class RagdollTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] ragdollParts;
    public Animator anim;
    public PlayerScript movement;
    public Rigidbody movementRB;
    public Collider movementCollider;
    void Start()
    {
        anim.enabled = true;
        foreach (GameObject ragdoll in ragdollParts)
        {
            ragdoll.GetComponent<Rigidbody>().isKinematic = true;
            ragdoll.GetComponent<Collider>().enabled = false;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RagDollTrigger();

        }
    }

    void RagDollTrigger()
    {
        movement.isRagdolled = true;
        anim.enabled = false;
        movementRB.isKinematic = true;
        movementCollider.enabled = false;
        foreach (GameObject ragdoll in ragdollParts)
        {
            ragdoll.GetComponent<Rigidbody>().isKinematic = false;
            ragdoll.GetComponent<Collider>().enabled = true;
        }
    }



}
