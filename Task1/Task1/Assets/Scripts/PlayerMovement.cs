using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    public float moveSpeed = 10f;        // Kekuatan dorongan horizontal
    public float rotationSpeed = 10f;    // Kecepatan rotasi saat berbalik
    public float maxSpeed = 5f;          // Kecepatan maksimum
    private Camera cam;                  // Kamera utama
    private Rigidbody2D rb;              // Rigidbody2D untuk fisika

    [HideInInspector] public float moveDirection;  // Arah input horizontal (-1, 0, 1)

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        player = GetComponent<Player>();
    }

    private void Update()
    {
        // Ambil input horizontal (A/D atau panah kiri/kanan)
        moveDirection = Input.GetAxisRaw("Horizontal"); // Lebih responsif daripada GetAxis
    }

    private void FixedUpdate()
    {
        // Tambahkan gaya horizontal
        rb.AddForce(new Vector2(moveDirection * moveSpeed, 0f));

        // Batasi kecepatan horizontal maksimum
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        // Rotasi karakter mengikuti arah gerak
        if (moveDirection != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (moveDirection > 0 ? 1 : -1);
            transform.localScale = scale;
        }
    }
}
