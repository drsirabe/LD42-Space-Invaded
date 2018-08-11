using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float orbitalSpeed = 50f;
    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float projectileFireRate = 1f;
    [SerializeField] GameObject orbiter1 = null;
    [SerializeField] GameObject orbiter2 = null;
    [SerializeField] GameObject projectile = null;
    GameObject projectilesParent = null;

    // Use this for initialization
    void Start () {
        projectilesParent = new GameObject("Projectiles");
	}
	
	// Update is called once per frame
	void Update () {
        if      (Input.GetKey("a"))     { orbiter1.transform.RotateAround(transform.position, Vector3.forward, orbitalSpeed * Time.deltaTime); }
        else if (Input.GetKey("d"))     { orbiter1.transform.RotateAround(transform.position, Vector3.forward, -orbitalSpeed * Time.deltaTime); }
        if      (Input.GetKey("j"))     { orbiter2.transform.RotateAround(transform.position, Vector3.forward, orbitalSpeed * Time.deltaTime); }
        else if (Input.GetKey("l"))     { orbiter2.transform.RotateAround(transform.position, Vector3.forward, -orbitalSpeed * Time.deltaTime); }
        if      (Input.GetKeyDown("w"))     { InvokeRepeating("FireOrbiter1", 0f, projectileFireRate); }
        if      (Input.GetKeyDown("i"))     { InvokeRepeating("FireOrbiter2", 0f, projectileFireRate); }
        if      (Input.GetKeyUp("w"))       { CancelInvoke("FireOrbiter1"); }
        if      (Input.GetKeyUp("i"))       { CancelInvoke("FireOrbiter2"); }
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
}
