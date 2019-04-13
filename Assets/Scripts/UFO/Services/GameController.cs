using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : PlayerObserver {

    public GameObject[] pickUps;
    public PlayerController player;

    public Text goalText;
    public Text resultText;

    protected virtual void Start() {
        player.AddObserver(this);
        UpdateGoalText();
        resultText.text = "";
    }
    
    void Update() {
        
    }

    // MARK: - UI

    protected virtual void UpdateGoalText() {
        GameObject[] remainings = pickUps.Where(item => item.activeSelf).ToArray();
        goalText.text = "Remaining: " + remainings.Count().ToString();

        if (!remainings.Any()) {
            resultText.text = "You Won!";
        }
    }

    // MARK: - Player observable

    public override void OnNotify() {
        UpdateGoalText();
    }
}
