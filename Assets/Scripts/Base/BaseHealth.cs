using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 3000; 
    public float currentHealth;
    
    public bool isDead; 

    
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
        
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

void UpdateHealthBar()
    {
        float newWidth = currentHealth / maxHealth * healthBarBackground.sizeDelta.x;
        healthBarFill.sizeDelta = new Vector2(newWidth, healthBarFill.sizeDelta.y);
    }


    void Die()
    {
        isDead = true;
    }
}