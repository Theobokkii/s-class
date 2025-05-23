using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform player;
    public float cooldown = 2f;
    public float range = 10f; // jarak maksimal deteksi horizontal
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && player != null)
        {
            Vector2 direction = player.position - transform.position;
            float absX = Mathf.Abs(direction.x);

            if (absX <= range && Mathf.Abs(direction.y) < 0.5f) // hanya di 1 garis horizontal
            {
                timer = cooldown;
                Vector2 shootDir = direction.x > 0 ? Vector2.right : Vector2.left;
                float zRotation = direction.x > 0 ? 0f : 180f;

                // Spawn fireball
                GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.Euler(0, 0, zRotation));
                fireball.GetComponent<EnemyFireball>().SetDirection(shootDir);
            }
        }
    }
}
