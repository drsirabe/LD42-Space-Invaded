﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikazi : MonoBehaviour {

    [SerializeField] float speed = 1;
    [SerializeField] float boostedSpeed = 5;
    [SerializeField] float distanceFromEarthCentreBoosts = 0;

    GameObject target;
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform.position);
        Rigidbody kamikaziBody = gameObject.GetComponent<Rigidbody>();
        kamikaziBody.velocity = (target.transform.position - gameObject.transform.position).normalized * speed;
    }

    private void Update()
    {
        if((target.transform.position - gameObject.transform.position).magnitude <= distanceFromEarthCentreBoosts)
        {
            Rigidbody kamikaziBody = gameObject.GetComponent<Rigidbody>();
            kamikaziBody.velocity = (target.transform.position - gameObject.transform.position).normalized * boostedSpeed;
        }
    }

}
