using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePewPew : MonoBehaviour
{

    [SerializeField] GameObject projectile = null;
    [SerializeField] float projectileSpeed = 500f;
    [SerializeField] float projectileFireRampUp = 5f;
    [SerializeField] float projectileFireCooldown = 2f;
    [SerializeField] float speed = 1f;
    [SerializeField] float orbitalSpeed = 45f;
    [SerializeField] float orbitDistanceFromEarthCentre = 4f;

    bool orbiting;
    bool firing;
    GameObject target;
    float timeCounter;


    private void Start()
    {
        timeCounter = 0f;
        orbiting = false;
        firing = false;
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform.position);
        Rigidbody orbiterBody = gameObject.GetComponent<Rigidbody>();
        orbiterBody.velocity = (target.transform.position - gameObject.transform.position).normalized * speed;
    }

    private void Update()
    {
        if ((target.transform.position - gameObject.transform.position).magnitude <= orbitDistanceFromEarthCentre && !orbiting && !firing)
        {
            Rigidbody orbiterBody = gameObject.GetComponent<Rigidbody>();
            orbiterBody.velocity = Vector3.zero;
            orbiting = true;
        }

        if (orbiting && !firing)
        {
            gameObject.transform.RotateAround(target.transform.position, Vector3.forward, -orbitalSpeed * Time.deltaTime);
            timeCounter += Time.deltaTime;
            if( timeCounter >= projectileFireRampUp)
            {
                firing = true;
                orbiting = false;
                timeCounter = 0f;
            }
        }

        if (firing && !orbiting)
        {
            if(timeCounter == 0f)
            {
                Fire();
            }

            timeCounter += Time.deltaTime;


            if (timeCounter >= projectileFireCooldown)
            {
                
                orbiting = true;
                firing = false;
                timeCounter = 0f;
            }
        }
    }

    private void Fire()
    {
        GameObject beam = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody beamBody = beam.GetComponent<Rigidbody>();
        beamBody.velocity = (target.transform.position - gameObject.transform.position).normalized * projectileSpeed;
    }

}
