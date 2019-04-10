using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public interface IPlayerListener {
    void DidPickUp();
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public IPlayerListener listener;

    private Rigidbody2D rb2d;

    void Start() {
    	rb2d = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
    	float moveHorizontal = Input.GetAxis("Horizontal");
    	float moveVertical = Input.GetAxis("Vertical");

    	Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            collision.gameObject.SetActive(false);
            listener.DidPickUp();
        }
    }
}