
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health = 50;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
