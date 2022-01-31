using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    public float blastDelay = 3f;
    public float blastRadius = 5f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded;

    // Start is called before the first frame update
    void Start()
    {
        hasExploded = false;
        countdown = blastDelay;

    }

    // Countdown and Explosion Check
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

    }
    void Explode()
    { //Particle Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[]Physics.OverlapSphere(transform.position, blastRadius)

        //Removing Explosive After Explosion
        Destroy(gameObject);
    }
}
   





