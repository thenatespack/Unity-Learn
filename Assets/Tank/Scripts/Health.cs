using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float maxHelath = 100;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    private bool destroyed;

    float currentHealth { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHelath;
    }

    public void OnDamage(float damage)
    {
        if (destroyed) return;

        currentHealth -= damage;
        if (currentHealth <= 0) destroyed = true;

        if (!destroyed && hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            return;
        }

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
