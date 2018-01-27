using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public bool alive { get; private set; }
    public float life = 1;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        alive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamagePlayer(float damage)
    {
        if (damage < 0 || !alive) return;

        life -= damage;

        if (life <= 0)
        {
            triggerDeath();
        }
    }

    private void triggerDeath()
    {
        if (!alive) return;

        // darken player color
        spriteRenderer.color = new Color(
            spriteRenderer.color.r * 0.3f,
            spriteRenderer.color.g * 0.3f,
            spriteRenderer.color.b * 0.3f
         );

        Debug.Log("Player Died");
        alive = false;
        //todo: detha death anims, sounds etc..    
    }
}
