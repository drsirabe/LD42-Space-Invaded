using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] float orbitalSpeed = 50f;
    [SerializeField] float planetMaxHealth = 1000f;
    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float projectileFireRate = 1f;
    [SerializeField] GameObject orbiter1 = null;
    [SerializeField] GameObject orbiter2 = null;
    [SerializeField] GameObject projectile = null;
    [SerializeField] Text planetHealthText = null;
    GameObject projectilesParent = null;
    float planetCurrentHealth;

    // Use this for initialization
    void Start () {
        projectilesParent = new GameObject("Projectiles");
        planetCurrentHealth = planetMaxHealth;
        planetHealthText.text = "Planet Health: " + planetCurrentHealth.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if      (Input.GetKey(KeyCode.A))             { orbiter1.transform.RotateAround(transform.position, Vector3.forward, orbitalSpeed * Time.deltaTime); }
        else if (Input.GetKey(KeyCode.D))             { orbiter1.transform.RotateAround(transform.position, Vector3.forward, -orbitalSpeed * Time.deltaTime); }
        if      (Input.GetKey(KeyCode.LeftArrow))     { orbiter2.transform.RotateAround(transform.position, Vector3.forward, orbitalSpeed * Time.deltaTime); }
        else if (Input.GetKey(KeyCode.RightArrow))    { orbiter2.transform.RotateAround(transform.position, Vector3.forward, -orbitalSpeed * Time.deltaTime); }
        if      (Input.GetKeyDown(KeyCode.W))         { InvokeRepeating("FireOrbiter1", 0f, projectileFireRate); }
        if      (Input.GetKeyDown(KeyCode.UpArrow))   { InvokeRepeating("FireOrbiter2", 0f, projectileFireRate); }
        if      (Input.GetKeyUp(KeyCode.W))           { CancelInvoke("FireOrbiter1"); }
        if      (Input.GetKeyUp(KeyCode.UpArrow))     { CancelInvoke("FireOrbiter2"); }
    }

    private void FireOrbiter2()
    {
        Fire(orbiter2);
    }

    private void FireOrbiter1()
    {
        Fire(orbiter1);
    }

    private void Fire(GameObject orbiter)
    {
        GameObject beam = Instantiate(projectile, orbiter.transform.position, orbiter.transform.rotation, projectilesParent.transform); 
        Rigidbody beamBody = beam.GetComponent<Rigidbody>();                                        
        beamBody.velocity = orbiter.transform.localPosition * projectileSpeed;
    }

    void TakeDamage(float damage)
    {
        planetCurrentHealth = Mathf.Clamp(planetCurrentHealth - damage, 0f, planetMaxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectile>())
        {
            var damageToTake = other.GetComponent<Projectile>().GetDamage();
            TakeDamage(damageToTake);
            Destroy(other.gameObject);

            planetHealthText.text = "Planet Health: " + planetCurrentHealth.ToString();

            if (planetCurrentHealth == 0f)
            {
                Destroy(gameObject);
            }
        }
    }


}
