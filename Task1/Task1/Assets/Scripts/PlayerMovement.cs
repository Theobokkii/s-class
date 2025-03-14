using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    public float moveSpeed;        // Kecepatan bergerak
    public float rotationSpeed;    // Kecepatan rotasi
    public float maxSpeed;         // Kecepatan maksimum
    private Camera cam;            // Kamera utama
    private Rigidbody2D rb;        // Rigidbody 2D untuk pergerakan berbasis fisika
    [HideInInspector] public Vector2 moveDirection;  // Arah pergerakan

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main.GetComponent<Camera>();
    }

    private void Update()
    {
        // Input horizontal untuk gerakan
        float horizontal = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(horizontal, 0f).normalized; // Tidak ada gerakan vertikal
    }

    private void FixedUpdate()
    {
        // Batasi kecepatan horizontal agar tidak lebih dari maxSpeed
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y); // Hanya batasi kecepatan horizontal
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y); // Batasi kecepatan negatif horizontal
        }

        // Set kecepatan horizontal berdasarkan arah gerakan
        Vector2 currentVelocity = rb.velocity;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, currentVelocity.y); // Tidak ada perubahan vertikal

        // Rotasi karakter mengikuti arah gerakan
        if (moveDirection.x != 0)
        {
            float targetAngle = moveDirection.x > 0 ? 0f : 180f;
            float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
