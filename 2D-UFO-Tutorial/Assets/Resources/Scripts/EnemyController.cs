using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

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
            Vector3 dir = transform.position - player.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90.0f, Vector3.forward);
            rigidBdy.AddForce(this.transform.up * speed);
            rigidBdy.velocity = Vector2.ClampMagnitude(rigidBdy.velocity, speedLimit);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SendMessage("DestroyPlayer");
        }
    }
}
