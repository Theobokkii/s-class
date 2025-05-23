using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public GameObject fireballObject;
    public float fireballCooldown;
    private float currentCooldown;

    void Start()
    {
        currentCooldown = fireballCooldown;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.E) && currentCooldown <= 0)
        {
            currentCooldown = fireballCooldown;

            float direction = transform.localScale.x > 0 ? 1f : -1f;
            Vector2 shootDir = direction > 0 ? Vector2.right : Vector2.left;
            Quaternion fireballRotation = Quaternion.Euler(0f, 0f, direction > 0 ? 0f : 180f);

            Vector3 spawnPos = transform.position + new Vector3(direction * 0.5f, 0, 0); // biar ga nabrak player

            GameObject fireball = Instantiate(fireballObject, spawnPos, fireballRotation);
            fireball.GetComponent<Fireball>().SetDirection(shootDir);
            
            // Optional: biar gak nabrak diri sendiri
            Physics2D.IgnoreCollision(fireball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

}