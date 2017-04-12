using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public GameObject pickupParticleSystem;
    public AudioSource pickupAudio;

    public void Pickup()
    {
        Instantiate(pickupParticleSystem, this.transform.position, this.transform.rotation).SetActive(true);
        pickupAudio.Play();
        Destroy(gameObject);
    }
}
