using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    public Vector2 lastCheckPointPos;
    public int activeCheckPointId;

    public bool DubbleJumpUnlocked = false;

    public bool isPaused = false;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }


}
