using UnityEngine;
using System;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioSource musicSource;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // MARK: - Methods

    public void PlaySingle(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

}
