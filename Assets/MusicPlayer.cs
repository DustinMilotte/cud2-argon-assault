using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    public AudioSource audioSource;
    public static MusicPlayer instance;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
        Invoke("LoadFirstLevel", 3f);
	}

    void LoadFirstLevel() { 
        SceneManager.LoadScene(1);
    }
}
