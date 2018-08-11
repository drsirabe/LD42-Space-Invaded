using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float maxHealth = 100f;
    float currentHealth;

    void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectile>())
        {
            var damageToTake = other.GetComponent<Projectile>().GetDamage();
            TakeDamage(damageToTake);
            Destroy(other.gameObject);


            if (currentHealth == 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
