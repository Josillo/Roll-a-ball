// using System;
using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float movementJump;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Player controller started");
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        UnityEngine.Debug.Log("Current X and Y : " + movementX + " " + movementY);
    }

    void OnJump() {
        movementJump = 20f;
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 9) {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate() {

        Vector3 movement = new Vector3(movementX, movementJump, movementY);
        rb.AddForce(movement * speed);
        movementJump = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
