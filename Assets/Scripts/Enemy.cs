using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    Boolean isDead = false;

    [SerializeField] int scorePerHit = 10;

    ScoreBoard scoreBoard;

    private void Start(){
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other){
        if (!isDead){
            isDead = true;
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            scoreBoard.Scorehit(scorePerHit);
            Destroy(gameObject);
        }
       
    }
}
