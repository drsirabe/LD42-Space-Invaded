using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour {

    //Attach to image object in cutscene and populate with sprites.

    [SerializeField] Sprite[] Scenes;
    LevelChanger levelChanger= null;
    Image currentImage;

    int currentScene = 0;

	// Use this for initialization
	void Start () {
        levelChanger = FindObjectOfType<LevelChanger>();
        currentScene = 0;
        currentImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))  { currentScene = Mathf.Clamp(currentScene - 1, 0, Scenes.Length-1); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { currentScene = Mathf.Clamp(currentScene + 1, 0, Scenes.Length-1); }
        if (Input.GetKeyDown(KeyCode.Return))     { levelChanger.NextLevel(); }

        currentImage.sprite = Scenes[currentScene];
	}
}
