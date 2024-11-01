using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 4; //Put here the number of pickups you have.
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    void Start()
    {
        // Initialize the count variable to 0
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString(); 
        if (count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}