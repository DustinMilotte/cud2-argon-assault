using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds.")][SerializeField]
    float levelLoadDelay = 3;
    [Tooltip("ParticleFX to blow up on player.")][SerializeField]
    GameObject DeathFX;

    private void OnTriggerEnter(Collider other){
        DeathFX.SetActive(true);
        StartDeathSequence();
        Invoke("ReloadFirstScene", levelLoadDelay);
    }

    private void StartDeathSequence(){
        print("player dying");
        SendMessage("OnPlayerDeath");
    }

    private void ReloadFirstScene(){    // referenced as String
        SceneManager.LoadScene(1);
    }
}
