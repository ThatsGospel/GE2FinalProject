using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public float healingRate; //How much we heal per second when wandering
    private BoidStateController boidStateController;

    private void Start()
    {
        boidStateController = GetComponent<BoidStateController>();
        health = maxHealth;
    }

    private void Update()
    {
        if (boidStateController.currentState == BoidStateController.BoidStates.Wander && health < maxHealth)
        {
            health += healingRate * Time.deltaTime;
            health = Mathf.Clamp(health, 0, maxHealth);
        }

        if (health <= 0)
        {
            //EXPLODING DEATH HERE HOW SAD
        }
    }

    public void TakeDamage(float amt)
    {
        health -= amt;
    }
}
