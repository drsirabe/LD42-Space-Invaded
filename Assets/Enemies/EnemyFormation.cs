using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

    [SerializeField] GameObject[] enemyPrefab = null;
    [SerializeField] float[] maxTimeBetweenSpawns;
    [SerializeField] float[] minTimeBetweenSpawns;
    [SerializeField] float[] timeBetweenSpawnsDecrement;
    [SerializeField] float spawningOrbitRadius;
    float[] timeCounter;
    float[] currentTimeBetweenSpawns;

	// Use this for initialization
	void Start () {

        timeCounter = new float[maxTimeBetweenSpawns.Length];

        currentTimeBetweenSpawns = maxTimeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
        

        for (int i = 0; i < maxTimeBetweenSpawns.Length; i++)
        {
            timeCounter[i] += Time.deltaTime;
            if (currentTimeBetweenSpawns[i] <= timeCounter[i])
            {
                timeCounter[i] = 0f;
                if (currentTimeBetweenSpawns[i] > minTimeBetweenSpawns[i])
                {
                    currentTimeBetweenSpawns[i] -= timeBetweenSpawnsDecrement[i];
                }

                float circleParameter = Random.Range(0f, 2 * Mathf.PI);
                float xCircleComponent = spawningOrbitRadius * Mathf.Cos(circleParameter);
                float yCircleComponent = spawningOrbitRadius * Mathf.Sin(circleParameter);
                Vector3 orbitPosition = new Vector3(xCircleComponent, yCircleComponent, 0f);

                Instantiate(enemyPrefab[i], orbitPosition, Quaternion.identity, gameObject.transform);

            }

        }
        
    }
}
