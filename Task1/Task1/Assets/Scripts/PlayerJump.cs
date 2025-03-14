using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Player{
    public float jumpForce;          // Kekuatan lompat
    public bool isGrounded;          // Menyatakan apakah karakter berada di tanah
    public int totalJump;            // Total lompatan yang diperbolehkan (misalnya 2 untuk double jump)
    private Rigidbody2D rb;          // Komponen Rigidbody2D untuk fisika
    [HideInInspector] public int currentTotalJump;  // Jumlah lompatan yang telah dilakukan

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentTotalJump < totalJump)
        {
            // Lompat jika berada di tanah atau belum mencapai total lompatan
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentTotalJump++;
        }
    }

    // Menangani deteksi apakah pemain ada di tanah
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Pastikan objek tanah memiliki tag "Ground"
        {
            isGrounded = true;
            currentTotalJump = 0;  // Reset lompatan ketika menyentuh tanah
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
