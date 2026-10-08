using UnityEngine;

public class HazardScriptSpinner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    public float knockback;
    public Vector3 spinSpeed = new Vector3(0f, 3f, 0f);
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinSpeed);
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
            Debug.Log("whack");
            
        }

    }
}
