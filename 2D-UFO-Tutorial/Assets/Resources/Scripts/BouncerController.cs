using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for the boucer enemy
public class BouncerController : MonoBehaviour
{
    public AudioSource enemyCollisionSoundEffect;

    private float _speed = 5.0f;
    private float _acceleration = 0.3f;
    private float _maxSpeed = 100.0f;
    private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // Assign a random starting direction
        _rigidbody.velocity = new Vector2(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f).normalized;
    }

    // Update is called once per frame
    void Update ()
    {
        _speed += _acceleration * Time.deltaTime;

        // Not likely that the speed will every reach this point while playing
        // Capping it to be safe
        if (_speed > _maxSpeed)
            _speed = _maxSpeed;

        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If it collides with the player kill the player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("DestroyPlayer");
        }
        // If it collides with an enemy play the collision sound effect
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollisionSoundEffect.Play();
        }
    }
}
