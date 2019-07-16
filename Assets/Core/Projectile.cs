using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float Damage;

	public float GetDamage() {
        return Damage;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
