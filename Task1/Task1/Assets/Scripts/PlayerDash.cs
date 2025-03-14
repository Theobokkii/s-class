using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Player
{
    public float dashDistance = 10f;    // Jarak dash
    public float dashCooldown = 1f;     // Waktu cooldown antar dash
    private Rigidbody2D rb;             // Referensi ke Rigidbody2D
    private float currentDashCooldown;

    private Vector2 dashDirection;      // Arah dash (sama dengan arah gerakan player)

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Menurunkan waktu cooldown
        currentDashCooldown -= Time.deltaTime;

        // Cek jika tombol dash ditekan dan cooldown selesai
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentDashCooldown <= 0)
        {
            // Dapatkan arah gerakan pemain dari PlayerMovement
            dashDirection = GetComponent<PlayerMovement>().moveDirection;

            // Jika dashDirection kosong (bernilai 0), paksa arah dash ke kanan (default)
            if (dashDirection == Vector2.zero)
            {
                dashDirection = Vector2.right;
            }

            // Lakukan dash
            StartCoroutine(Dash());

            // Reset cooldown setelah dash
            currentDashCooldown = dashCooldown;
        }
    }

    private IEnumerator Dash()
    {
        // Simpan posisi awal sebelum dash
        Vector2 startPosition = transform.position;

        // Hitung posisi akhir setelah dash, hanya mengubah posisi X
        Vector2 dashTargetPosition = startPosition + new Vector2(dashDirection.x * dashDistance, 0);  // Tidak ada perubahan di sumbu Y

        // Batasi posisi dash agar tidak keluar dari area map
        dashTargetPosition.x = Mathf.Clamp(dashTargetPosition.x, -5f, 5f);  // Sesuaikan batas X dengan ukuran map kamu
        dashTargetPosition.y = startPosition.y;  // Y tetap sama (bola tetap berada di posisi Y yang sama)

        // Lakukan dash dengan mengubah posisi langsung
        float dashTime = 0f;
        float dashDuration = 0.1f; // Dash berlangsung 0.1 detik
        while (dashTime < dashDuration)
        {
            // Menggunakan MoveTowards untuk pergerakan yang mulus
            transform.position = Vector2.MoveTowards(transform.position, dashTargetPosition, dashDistance * Time.deltaTime / dashDuration);
            dashTime += Time.deltaTime;
            yield return null;
        }

        // Pastikan posisi akhir dash tepat
        transform.position = dashTargetPosition;
    }
}
