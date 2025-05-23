using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float health { get; set; }
    public float maxHealth = 100f;
    public GameObject youDiedUI;

    private bool isDead = false;

    public void Start()
    {
        health = maxHealth;

        youDiedUI.SetActive(false);
    }

    // Hapus pengecekan di Update, cukup di TakeDamage saja
    //protected void Update()
    //{
    //    if (health <= 0)
    //    {
    //        Die();
    //    }
    //}

    public void TakeDamage(float damage)
    {
        if (isDead) return;  // Jika sudah mati, ignore damage berikutnya

        health -= damage;
        Debug.Log("Player kena damage. Sisa: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        if (isDead) return;  // prevent multiple calls
        isDead = true;

        var playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        var shootFireball = GetComponent<ShootFireball>();
        if (shootFireball != null)
        {
            shootFireball.enabled = false;
        }
        youDiedUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Player mati!");
    }
}

