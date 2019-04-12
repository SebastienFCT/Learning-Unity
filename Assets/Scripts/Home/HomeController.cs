using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour {

    protected void Start() {
        SetupSound();
    }

    // MARK: - Setup

    private void SetupSound() {
        AudioClip clip = Resources.Load("Sounds/freelance/restoration completed") as AudioClip;

        SoundManager.instance.PlaySingle(clip);
    }
}
