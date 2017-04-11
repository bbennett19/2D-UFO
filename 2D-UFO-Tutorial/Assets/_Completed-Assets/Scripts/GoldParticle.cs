﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldParticle : MonoBehaviour {

    public Transform magnitizeLocation;
    private ParticleSystem _system;
    private ParticleSystem.Particle[] _particles;
    private float _velocity = -4.0f;
    private float _flyingAwayAcceleration = -5.0f;
    private float _flyingAwayTime = 0.5f;
    private float _flyingToAcceleration = 20.0f;
    //private float _acceleration = 3.0f;
    //private float _speed = 8.0f;
    //private float _initialSpeed = 12.0f;
    private float _startTime = 0.0f;

	// Use this for initialization
	void Start ()
    {
        _system = GetComponent<ParticleSystem>();
        _particles = new ParticleSystem.Particle[_system.main.maxParticles];
	}
	
	// Update is called once per frame
	void Update ()
    {
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
