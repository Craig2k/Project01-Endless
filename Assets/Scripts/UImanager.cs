using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreUI;

    GameManager gm;

    private void Start() {
        gm = GameManager.instance;
    }

    private void OnGUI() {
        scoreUI.text = gm.PrettyScore();
    }
}
