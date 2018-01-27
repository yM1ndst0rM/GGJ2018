using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public bool alive { get; private set; }
    public float life = 1;

    // Use this for initialization
    void Start()
    {
        alive = true;
    }

    public void DamagePlayer(float damage)
    {
        if (damage < 0 || !alive) return;

        life -= damage;

        if (life < 0)
        {
            triggerDeath();
        }
    }

    private void triggerDeath()
    {
        if (!alive) return;

        Debug.Log("Player Died");
        alive = false;
        //todo: detha death anims, sounds etc..    
    }
}
