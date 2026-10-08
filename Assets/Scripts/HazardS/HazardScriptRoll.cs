using UnityEngine;

public class HazardScriptRoll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    public float knockback;
    void Start()
    {
        Destroy(gameObject, 8);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
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
            Debug.Log("bonk");

        }

    }
}
