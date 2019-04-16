using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;
    private int direction = 5;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(direction, 1);
        rb2d.AddForce(movement * speed);
    }
}
