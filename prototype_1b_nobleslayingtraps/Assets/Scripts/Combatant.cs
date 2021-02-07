using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    private float health = 100.0f;
    private float exp = 10.0f;
    private int strength = 5;

    public float Health {
        get { return health; }
        set {
            health += value; // positive or negative values
        }
    }

    public float Exp { // Exp returned by monster
        get { return exp; }
        set { if(value >= 0)
            {
                exp = value;
            }
        }
    }

    public int Strength {
        get { return strength; }
        set {
            if(value >= 0) {
                strength = value;
            }
        }
    }

    private bool alive = true;
    public bool Alive {
        get { return alive; }
        set {
            alive = value;
        }
    }

    public bool TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Damage taken! " + damage);
        Debug.Log("HP: " + health);
        if(health <= 0)
        {
            alive = false;
            Die();
            // Show overkill damage?
            // Trigger FX?
        }
        return alive;
    }

    public void Die()
    {
        Debug.Log("Death ensued.");
        Destroy(this.gameObject);
    }
}
