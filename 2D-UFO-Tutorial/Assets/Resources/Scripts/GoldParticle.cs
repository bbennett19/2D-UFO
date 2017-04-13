using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles updating each particle so it magnetizes to the player
public class GoldParticle : MonoBehaviour
{
    public Transform magnitizeLocation;
    private ParticleSystem _system;
    private ParticleSystem.Particle[] _particles;
    private float _velocity = -4.0f;
    private float _flyingAwayTime = 0.25f;
    private float _flyingToAcceleration = 25.0f;
    private float _startTime = 0.0f;

	// Use this for initialization
	void Start ()
    {
        _system = GetComponent<ParticleSystem>();
        _particles = new ParticleSystem.Particle[_system.main.maxParticles];
        Destroy(this.gameObject, _system.main.duration);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Start the particles flying away from the player so they don't get sucked up right away
        // After that fly to the player ship with acceleration
		if(_system != null)
        {
            _startTime += Time.deltaTime;
            int count = _system.GetParticles(_particles);

            if (_startTime > _flyingAwayTime)
                _velocity += (_flyingToAcceleration * Time.deltaTime);

            for (int i = 0; i < count; i++)
            {
                Vector3 heading = magnitizeLocation.position - _particles[i].position;
                float distance = heading.magnitude;
                Vector3 direction = heading / distance;
                _particles[i].velocity = _velocity * direction;
            }
            
            _system.SetParticles(_particles, count);
        }
	}
}
