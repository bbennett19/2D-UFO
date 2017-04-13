using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

// The player controller
public class PlayerController : MonoBehaviour
{
	public float speed;				
    public float speedLimit;
	public Text countText;			
	public Text winText;
    public GameObject restartManager;

	private Rigidbody2D rb2d;		
	private int count;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetCountText();
	}

    // Destroy the player
    public void DestroyPlayer()
    {
        winText.text = "You Lose! Press R to restart";
        restartManager.SetActive(true);
        GetComponent<Explode>().ExplodeThisObject(false);
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, speedLimit);
	}

	// OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) 
		{
            other.gameObject.SendMessage("Pickup");
            count += 5;
			SetCountText();
		}
	}

    // This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    void SetCountText()
	{
		countText.text = "Moon Cheese: " + count.ToString ();
	}
}
