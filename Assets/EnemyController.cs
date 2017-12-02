using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    Rigidbody rb;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    private float nextFire;
    public float firstRate;

    private AudioSource audio;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Instantiates a new shot
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firstRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }
}
