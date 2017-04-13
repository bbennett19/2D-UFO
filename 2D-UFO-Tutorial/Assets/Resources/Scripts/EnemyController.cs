using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy controller. The enemy follows the player, trying to run into the player
public class EnemyController : MonoBehaviour
{
    public float speed;
    public float speedLimit;
    public GameObject player;

    private Rigidbody2D rigidBdy;

	// Use this for initialization
	void Start ()
    {
        rigidBdy = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.activeSelf)
        {
            // Get the vector from the player to this object
            Vector3 dir = transform.position - player.transform.position;
            // Set the rotation to look at the player
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90.0f, Vector3.forward);
            // Add force in the direction this object is facing
            rigidBdy.AddForce(this.transform.up * speed);
            rigidBdy.velocity = Vector2.ClampMagnitude(rigidBdy.velocity, speedLimit);
        }
    }

    // Collision handler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the player if there has been a collision with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SendMessage("DestroyPlayer");
        }
    }
}
