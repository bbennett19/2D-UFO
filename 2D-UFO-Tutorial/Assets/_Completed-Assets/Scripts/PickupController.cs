using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public GameObject pickupParticleSystem;

    public void Start()
    {

    }

    public void Pickup()
    {
        GameObject clone = Instantiate(pickupParticleSystem, this.transform.position, this.transform.rotation);
        ParticleSystem particleSystem = clone.GetComponent<ParticleSystem>();
        particleSystem.Play();
        gameObject.SetActive(false);
    }
}
