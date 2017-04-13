using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for the "moon cheese" pickups
public class PickupController : MonoBehaviour
{
    public GameObject pickupParticleSystem;
    public AudioSource pickupAudio;

    // Create a particle effect, play the pickup sound, and destroy this object
    public void Pickup()
    {
        Instantiate(pickupParticleSystem, this.transform.position, this.transform.rotation).SetActive(true);
        pickupAudio.Play();
        Destroy(gameObject);
    }
}
