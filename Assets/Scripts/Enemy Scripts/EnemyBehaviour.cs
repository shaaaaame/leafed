using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyType enemyType;
    public Collider2D collider2d;
    public Rigidbody2D rigidbody2d;

    public FloatVariable playerCurrentHealth;
    public FloatReference playerDamage;

    void Start()
    {
        EnemyManager.instance.RegisterEnemy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DealDamage(collision);
    }

    void TakeDamage()
    {
        enemyType.health -= playerDamage;
    }

    void DealDamage(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Player has taken damage!");

            //deal damage
            playerCurrentHealth.ApplyChange(-playerDamage);

            //player flashes white 
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            if (playerCombat != null)
            {
                playerCombat.PlayDamagedAnimation();
            }

            //set player to static before knockback
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.SetStatic();
            }

            //knockback player
            Rigidbody2D rigidbody2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody2d != null)
            {
                StartCoroutine(PerformKnockback(rigidbody2d, (collision.transform.position - transform.position)));
            }
        }
    }

    IEnumerator PerformKnockback(Rigidbody2D rb2d, Vector3 dir)
    {
        InputManager.instance.DisableControls();
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(dir * enemyType.knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(enemyType.knockbackLength);
        InputManager.instance.EnableControls();
    }



}
