using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 10;
    [SerializeField] int scorePerHit = 5;

    ScoreBoard scoreBoard;
    Boolean isDead = false;

    private void Start(){
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other){
        if (!isDead) {
            ProcessHit();
            if(hits <= 1) {
                KillEnemy();
            }
        }

    }

    private void ProcessHit() {
        hits--;
        scoreBoard.Scorehit(scorePerHit);
        print(hits);
        // todo consider fx for none death hits
    }

    private void KillEnemy() {
        isDead = true;
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
