using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    private GameMaster gm;

    private void Awake() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gm.isPaused = true;
    }

    public void PlayGame() {
        gm.isPaused = false;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PauseGame() {
        gm.isPaused = true;
    }
}
