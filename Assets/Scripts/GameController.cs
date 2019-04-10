using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour, IPlayerListener {

    public GameObject[] pickUps;
    public PlayerController player;

    public Text goalText;
    public Text resultText;

    protected virtual void Start() {
        player.listener = this; // Interface isn't the best solution here as other component might be interested in the player activity as well. To study.
        UpdateGoalText();
    }
    
    void Update() {
        
    }

    // MARK: - UI

    protected virtual void UpdateGoalText() {
        GameObject[] remainings = pickUps.Where(item => item.activeSelf).ToArray();
        goalText.text = "Remaining: " + remainings.Count().ToString();

        // Good study point: should you set the empty value in `Start` and only update when the user wins/looses
        // Or is it ok performance wise to update on every frame? My guess goes for the first solution...
        if (remainings.Any()) {
            resultText.text = "";
        } else {
            resultText.text = "You Won!";
        }
    }

    // MARK: - Interfaces

    public void DidPickUp() {
        UpdateGoalText();
    }
}
