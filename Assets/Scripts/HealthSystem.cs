using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    // private TMP_Text healthText;
    private float health = 100;
    [SerializeField]

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Heal(float heal)
    {
        if (health < 100)
        {
            health += heal;
            if (health>100) { health = 100; }
            healthBar.fillAmount = health / 100;
        }
    }
}
