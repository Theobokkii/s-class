using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health {get;set;}
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }
}