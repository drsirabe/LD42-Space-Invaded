using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] Text timeRemainingText;
    [SerializeField] float levelTime;
    float timeRemaining;

    private void Start()
    {
        timeRemaining = levelTime;
        timeRemainingText.text = "Time until escape: " + Mathf.RoundToInt(timeRemaining).ToString();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        timeRemainingText.text = "Time until escape: " + Mathf.RoundToInt(timeRemaining).ToString();

        if(timeRemaining <= 0f)
        {
            //complete level
        }
    }


}
