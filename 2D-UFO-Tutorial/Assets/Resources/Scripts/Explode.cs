using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosionFireParticleSystem;
    public GameObject explosionFlashParticleSystem;

    public void ExplodeThisObject(bool destroy)
    {
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
