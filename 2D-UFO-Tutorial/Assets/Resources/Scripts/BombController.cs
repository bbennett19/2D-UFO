using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public void Spawn(Vector2 playerPosition, Vector2 playerDirection)
    {
        this.transform.position = playerPosition - playerDirection;
    }

    public void Detonate()
    {
        GetComponent<Explode>().ExplodeThisObject(true);
    }
}
