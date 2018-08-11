using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikazi : MonoBehaviour {

    [SerializeField] float speed = 1;

    GameObject target;
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform.position);
        Rigidbody kamikaziBody = gameObject.GetComponent<Rigidbody>();
        kamikaziBody.velocity = (target.transform.position - gameObject.transform.position).normalized * speed;
    }
}
