using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Player player;
    public float dashDistance = 10f;     // Jarak dash
    public float dashCooldown = 1f;      // Waktu cooldown dash
    private float currentDashCooldown;

    private Rigidbody2D rb;
    private Vector2 dashDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        // Hitung mundur cooldown
        currentDashCooldown -= Time.deltaTime;

        // Cek tombol dash ditekan dan cooldown selesai
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentDashCooldown <= 0f)
        {
            float horizontal = GetComponent<PlayerMovement>().moveDirection;
            dashDirection = new Vector2(horizontal, 0f).normalized;

            // Default ke kanan jika tidak ada input
            if (dashDirection == Vector2.zero)
                dashDirection = Vector2.right;

            StartCoroutine(Dash());
            currentDashCooldown = dashCooldown;
        }
    }

    private IEnumerator Dash()
    {
        Vector2 startPosition = transform.position;
        Vector2 dashTargetPosition = startPosition + dashDirection * dashDistance;

        // Clamp agar tidak keluar dari area tertentu (bisa kamu sesuaikan)
        dashTargetPosition.x = Mathf.Clamp(dashTargetPosition.x, -5f, 5f);
        dashTargetPosition.y = startPosition.y;

        float dashTime = 0f;
        float dashDuration = 0.1f;

        while (dashTime < dashDuration)
        {
            transform.position = Vector2.MoveTowards(transform.position, dashTargetPosition, dashDistance * Time.deltaTime / dashDuration);
            dashTime += Time.deltaTime;
            yield return null;
        }

        transform.position = dashTargetPosition;
    }
}
