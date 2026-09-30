using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class RagdollTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] ragdoll;
    public Animator anim;
    void Awake()
    {
        anim.enabled = true;
        foreach (GameObject ragdoll in ragdoll)
        {
            ragdoll.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            RagDollTrigger();

        }
    }

    void RagDollTrigger()
    {
        anim.enabled = false;
        foreach (GameObject ragdoll in ragdoll)
        {
            ragdoll.GetComponent<Rigidbody>().isKinematic = false;
        }
    }



}
