using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;

    GameManager gm;

    private void Start() {
        gm = GameManager.instance;
    }

    public void PlayButtonHandler () {
        gm.StartGame();

        if (!startMenuUI)
            Debug.Log("No Start Menu Assigned.");

        startMenuUI.SetActive(false);
    }

    private void OnGUI() {
        scoreUI.text = gm.PrettyScore();
    }
}
