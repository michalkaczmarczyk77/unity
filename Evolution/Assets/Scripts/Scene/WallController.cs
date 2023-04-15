using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class WallController : MonoBehaviour
{
    //TODO: Przeanalizowac ktory sposob na particle jest lepszy: Subobjecty czy zmienne publiczne i "includowanie" z prefabow
    private ParticleSystem effectCollision;
    private ParticleSystem effectExplosion;
    private int timeToExplode;
    private float timeCounter = 0f;


    void Start()
    {
        setTimeToExplode();
        // Deprecated: Szukanie obiektow podrzednych
        // New: podpinanie ParticleSystem w UI
        effectCollision = transform.Find("WallCollidePS").GetComponent<ParticleSystem>();
        effectExplosion = transform.Find("WallExplosionPS").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= timeToExplode)
        {
            effectExplosion.Emit(100);
            setTimeToExplode();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        effectCollision.transform.position = collision.transform.position;
        effectCollision.Emit(10);
    }

    private void setTimeToExplode()
    {
        timeCounter = 0f;
        timeToExplode = (int)Mathf.Round(Random.Range(5, 10));
    }

}
