using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed = 100.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        //if(other)
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null) { health.OnDamage(20); }

        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
