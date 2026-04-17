using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 3000; 
    public float currentHealth;
    
    public bool isDead; 

    [Header("UI Bar Settings")]
    public RectTransform healthBarFill;
    public RectTransform healthBarBackground;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar(); 
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        
        // Clamp prevents health from going below zero
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null && healthBarBackground != null)
        {
            float healthPercent = currentHealth / maxHealth;
            
            float newWidth = healthPercent * healthBarBackground.rect.width;
            healthBarFill.sizeDelta = new Vector2(newWidth, healthBarFill.sizeDelta.y);
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("The picnic basket is empty! Game Over.");
    }
}