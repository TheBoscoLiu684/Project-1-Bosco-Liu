using System.Threading.Tasks;
using UnityEngine;

public class HazardsScript : MonoBehaviour
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
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(rb.linearVelocity.normalized * knockback, ForceMode.Impulse);
            Debug.Log("boom");
            Destroy(gameObject, 0.1f);
        }
        
    }
}
