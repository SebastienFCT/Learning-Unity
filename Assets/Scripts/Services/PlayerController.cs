using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public abstract class PlayerObserver: MonoBehaviour {
    public abstract void OnNotify();
}

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;
    private readonly List<PlayerObserver> observers = new List<PlayerObserver>();

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
            Notify();
        }
    }

    // MARK: - Observer management

    public void Notify() {
        for (int i = 0; i < observers.Count; i++) {
            observers[i].OnNotify();
        }
    }

    public void AddObserver(PlayerObserver observer) {
        observers.Add(observer);
    }

    public void RemoveObserver(PlayerObserver observer) {
        observers.Remove(observer);
    }
}