using UnityEngine;

public class Level1GameController : GameController {

    protected override void Start() {
        base.Start();

        SetupSound();
    }

    // MARK: - Setup

    private void SetupSound() {
        AudioClip clip = Resources.Load("Sounds/freelance/restoration completed") as AudioClip;

        SoundManager.instance.PlaySingle(clip);
    }
}
