using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public Slider healthslider;
    public int scoreValue = 5;
    public int hp = 10;
    public bool isEnemy = true;
    public int currentHealth;
    public void Damage(int damageCount)

    {
        currentHealth -= damageCount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject, 0.0001f);
            ScoreManager.score += scoreValue;
        }
    }
    void Update()
    {
        if (healthslider != null)
        {
            healthslider.value = currentHealth;
        }

    }

    void OnTriggerEnter2D(Collider2D otherColliders)
    {
        Shooting2 shot = otherColliders.gameObject.GetComponent<Shooting2>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

            }
        }
    }

}