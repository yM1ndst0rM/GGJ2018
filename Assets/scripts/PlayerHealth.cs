using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IImpactedByLaserHit {

    public GameObject deathExplosion;

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
            TriggerDeath();
        }
    }

    private void TriggerDeath()
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

        GameObject explosion = Instantiate(deathExplosion);
        explosion.transform.position.Set(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        explosion.transform.rotation.SetEulerAngles(0.0f, 0.0f, Random.value * 1000.0f);
    }

    public void OnLaserImpact(GameObject source)
    {
        DamagePlayer(1);
    }
}
