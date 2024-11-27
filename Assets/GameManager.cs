using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region singleton

    public static GameManager instance;

    private void Awake() {
       if (instance == null)  instance = this;
    }

    #endregion 

    public float currentScore = 0f;

    public bool isPlaying = false;

    private void Update() {
        if (isPlaying) {
            currentScore += Time.deltaTime;
        }

        if (Input.GetKeyDown("k")) { 
        isPlaying = true;
        }
    }

    public void GameOver() {
        currentScore = 0;
        isPlaying = false;
    }

    public string PrettyScore () { 
    return Mathf.RoundToInt(currentScore).ToString();
    }
}
