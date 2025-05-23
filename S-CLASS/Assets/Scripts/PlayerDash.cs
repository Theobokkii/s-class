using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Player
{
    
    public float dashDistance;
    public float dashCooldown;
    private Rigidbody rb;
    private float currentDashCooldown;


    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void Update(){
        currentDashCooldown -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftShift) && currentDashCooldown <= 0){
            rb.AddForce(GetComponent<PlayerMovement>().moveDirection * dashDistance, ForceMode.Impulse);
            currentDashCooldown = dashCooldown;
        }
    }
    
}
