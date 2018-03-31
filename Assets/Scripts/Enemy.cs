using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    private void Start(){
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other){
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        print(other);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
