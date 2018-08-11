using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] float timeBetweenSpawns = 5;
    [SerializeField] float spawningOrbitRadius = 15;
    float timeCounter;

	// Use this for initialization
	void Start () {
        timeCounter = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        if(timeBetweenSpawns <= timeCounter)
        {
            timeCounter = 0f;

            float circleParameter = Random.Range(0f, 2 * Mathf.PI);
            float xCircleComponent = spawningOrbitRadius * Mathf.Cos(circleParameter);
            float yCircleComponent = spawningOrbitRadius * Mathf.Sin(circleParameter);
            Vector3 orbitPosition = new Vector3(xCircleComponent, yCircleComponent, 0f);

            Instantiate(enemyPrefab, orbitPosition, Quaternion.identity, gameObject.transform);
        }
	}
}
