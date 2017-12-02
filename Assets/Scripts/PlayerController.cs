using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    public Boundary boundary;
    public float tilt;
    public float speed;

    public GameObject shot;
    public Transform shotSpawn;

    private float nextFire;
    public float firstRate;

    private AudioSource audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Instantiates a new shot
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + firstRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }
    private void FixedUpdate()
    {
        // Get current values for Horizontal and Vertical Axis
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Next position based on the user movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Give some speed so the effect is more visible
        rb.velocity = movement * speed;

        // Restrict the movement area using the Clamp function
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, 0.0f, 0.0f),
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        // Controls the rotation of the Spaceship
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
