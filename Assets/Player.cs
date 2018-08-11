using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float orbitalSpeed = 50f;
    [SerializeField] float projectileSpeed = 50f;
    public GameObject orbiter1;
    public GameObject orbiter2;
    //public GameObject laser;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if      (Input.GetKey("a"))     {orbiter1.transform.RotateAround(transform.position, Vector3.back, orbitalSpeed * Time.deltaTime);}
        else if (Input.GetKey("d"))     {orbiter1.transform.RotateAround(transform.position, Vector3.back, -orbitalSpeed * Time.deltaTime);}
        if      (Input.GetKey("j"))     {orbiter2.transform.RotateAround(transform.position, Vector3.back, orbitalSpeed * Time.deltaTime);}
        else if (Input.GetKey("l"))     {orbiter2.transform.RotateAround(transform.position, Vector3.back, -orbitalSpeed * Time.deltaTime);}
        // orbiter2.transform.RotateAround(transform.position, Vector3.back, orbitalSpeed * CrossPlatformInputManager.GetAxis("Horizontal2") * Time.deltaTime);
    }
}
