using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] float maxTimeBetweenSpawns = 5;
    [SerializeField] float minTimeBetweenSpawns = 2;
    [SerializeField] float timeBetweenSpawnsDecrement = 0.2f;
    [SerializeField] float spawningOrbitRadius = 15;
    float timeCounter;
    float currentTimeBetweenSpawns;

	// Use this for initialization
	void Start () {
        timeCounter = 0f;
        currentTimeBetweenSpawns = maxTimeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        if(currentTimeBetweenSpawns <= timeCounter)
        {
            timeCounter = 0f;
            if (currentTimeBetweenSpawns > minTimeBetweenSpawns) {
                currentTimeBetweenSpawns -= timeBetweenSpawnsDecrement;
            }

            float circleParameter = Random.Range(0f, 2 * Mathf.PI);
            float xCircleComponent = spawningOrbitRadius * Mathf.Cos(circleParameter);
            float yCircleComponent = spawningOrbitRadius * Mathf.Sin(circleParameter);
            Vector3 orbitPosition = new Vector3(xCircleComponent, yCircleComponent, 0f);

            Instantiate(enemyPrefab, orbitPosition, Quaternion.identity, gameObject.transform);

        }
	}
}
