using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class ballController : MonoBehaviour
{
  public TextMeshProUGUI countText;
  public GameObject winTextObject;

  public GameObject finishTextObject;
  private Rigidbody rigidbody;
  private Vector3 startPoint;
  private float movementX;
  private float movementY;
  public float speed;
  private int count;
  private int activeScene;
  private bool success;
  // Start is called before the first frame update
  void Start()
  {
    activeScene = SceneManager.GetActiveScene().buildIndex;
    startPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    rigidbody = GetComponent<Rigidbody>();
    count = 0;
    success = false;

    SetCountText();

    // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
    winTextObject.SetActive(false);
    finishTextObject.SetActive(false);
  }
  void SetCountText()
  {
    countText.text = "Count: " + count.ToString();

    if (count >= 5)
    {
      // Set the text value of your 'winText'
      if (activeScene == 4)
      {
        finishTextObject.SetActive(true);
      }
      else
      {
        winTextObject.SetActive(true);
        success = true;
      }

    }
  }
  private void OnMove(InputValue inputValue)
  {
    Vector2 movementVector = inputValue.Get<Vector2>();
    movementX = movementVector.x;
    movementY = movementVector.y;

  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("pickup"))
    {
      other.gameObject.SetActive(false);
      // Add one to the score variable 'count'
      count = count + 1;
      speed += 0.5f;

      // Run the 'SetCountText()' function (see below)
      SetCountText();
    }
    if (other.gameObject.CompareTag("door") && success)
    {

      SceneManager.LoadScene(activeScene + 1);
    }
  }
  // Update is called once per frame
  void Update()
  {
    Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    rigidbody.AddForce(movement * speed);
    if (transform.position.y <= -10)
    {
      rigidbody.velocity = new Vector3(0, 0, 0);
      transform.position = startPoint;
    }
    if (Input.GetKeyDown("space") && transform.position.y <= 1)
    {
      rigidbody.AddForce(new Vector3(movementX, 250.0f, movementY));
    }
  }
}
