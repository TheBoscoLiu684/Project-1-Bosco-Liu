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
    public float wakeupTime = 3f;
    public Transform hipBone;
    void Start()
    {
        hipBone = anim.GetBoneTransform(HumanBodyBones.Hips);
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
        if (movement.isRagdolled)
        {
            
            Debug.Log("player ragdolled");
            RagdollUp();
        }
    }

    public void RagDollTrigger()
    {
        if (movement.isRagdolled)
            return;
        Debug.Log("hit");
        movement.isRagdolled = true;
        anim.enabled = false;
        movementRB.isKinematic = true;
        movementCollider.enabled = false;
        wakeupTime = 3f;
        foreach (GameObject ragdoll in ragdollParts)
        {
            ragdoll.GetComponent<Rigidbody>().isKinematic = false;
            ragdoll.GetComponent<Collider>().enabled = true;
        }
    }

    public void RagdollDisable()
    {
        Debug.Log("Not Ragdolled");
        AlignHips();
        foreach (GameObject ragdoll in ragdollParts)
        {
            ragdoll.GetComponent<Rigidbody>().isKinematic = true;
            ragdoll.GetComponent<Collider>().enabled = false;
        }
        movement.isRagdolled = false;
        anim.enabled = true;
        movementRB.isKinematic = false;
        movementCollider.enabled = true;
    }

    public void Knockback(Vector3 direction, float force)
    {
        foreach (GameObject ragdoll in ragdollParts)
        {
            Rigidbody rb = ragdoll.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }

    public void RagdollUp()
    {
        Debug.Log("RagdollUp is running");
        wakeupTime -= Time.deltaTime;
        Debug.Log("Timer: " + wakeupTime);
        if (wakeupTime <= 0)
        {
            RagdollDisable();
            
        }
    }

    public void AlignHips()
    {
        Vector3 hipPosition = hipBone.position;

        movement.transform.position = new Vector3(hipPosition.x, movement.transform.position.y, hipPosition.z);
    }
}
