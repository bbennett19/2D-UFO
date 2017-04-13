using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows the object this is attached to to explode
public class Explode : MonoBehaviour
{
    public GameObject explosionFireParticleSystem;
    public GameObject explosionFlashParticleSystem;
    public AudioSource explosionSound;

    /// <summary>
    /// Explode the object
    /// </summary>
    /// <param name="destroy">Flag to destroy or disable, true = destroy</param>
    public void ExplodeThisObject(bool destroy)
    {
        explosionSound.Play();
        GameObject clone = Instantiate(explosionFireParticleSystem, this.transform.position, this.transform.rotation);
        GameObject clone1 = Instantiate(explosionFlashParticleSystem, this.transform.position, this.transform.rotation);
        clone.SetActive(true);
        clone1.SetActive(true);
        Destroy(clone, clone.GetComponent<ParticleSystem>().main.duration);
        Destroy(clone1, clone1.GetComponent<ParticleSystem>().main.duration);

        if (destroy)
            Destroy(this.gameObject);
        else
            this.gameObject.SetActive(false);
    }
}
