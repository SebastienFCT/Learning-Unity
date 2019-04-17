using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;
    private int direction = 1;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb2d.position += Vector2.right * (Time.deltaTime * speed);
    }
}
