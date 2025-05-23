using UnityEngine;

public class SimpleChase : MonoBehaviour
{
    public Transform player;           // Referensi ke Player
    public float speed = 3f;           // Kecepatan enemy
    public float chaseRange = 8f;      // Jarak untuk mulai mengejar
    public float stopDistance = 1.5f;  // Jarak minimum agar tidak terlalu dekat

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange && distance > stopDistance)
        {
            // Gerakkan enemy ke arah player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Atau: transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
