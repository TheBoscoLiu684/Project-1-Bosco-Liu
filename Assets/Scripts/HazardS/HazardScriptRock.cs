using UnityEngine;

public class HazardScriptRock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    public float knockback;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("MINE HIT: " + other.gameObject.name);
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(direction * knockback, ForceMode.Impulse);
            RagdollTrigger ragdoll = other.gameObject.GetComponentInChildren<RagdollTrigger>();
            if (ragdoll != null)
            {
                ragdoll.RagDollTrigger();
                ragdoll.Knockback(direction, knockback);
            }
            //Debug.Log("slip");
            
        }

    }
}
