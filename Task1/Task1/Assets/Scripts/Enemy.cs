using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health {get;set;}
    public float maxHealth;
    private bool isDead = false;


    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;  // Jika sudah mati, ignore damage berikutnya

        health -= damage;
        Debug.Log("Enemy kena damage. Sisa: " + health);
    }

    void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }
}