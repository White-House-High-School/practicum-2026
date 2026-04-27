using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 3000f; 
    public float currentHealth;
    
    public bool isDead; 
    private GameObject HealthBar;  
    public RectTransform healthBarFill;
    public RectTransform healthBarBackground;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar(); 
        HealthBar = GameObject.Find("CurrentHealth");
        
    }

    

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Destroy(HealthBar);
        }
    }

void UpdateHealthBar()
    {
        float newWidth = currentHealth / maxHealth * healthBarBackground.sizeDelta.x;
        healthBarFill.sizeDelta = new Vector2(newWidth, healthBarFill.sizeDelta.y);
    }

public float GetHealth()
    {
        return currentHealth;
    }
    public void SetHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

}