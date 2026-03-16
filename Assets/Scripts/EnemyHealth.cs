using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public RectTransform healthBarFill;
    public RectTransform healthBarBackground;
    private Animator animator;
    public bool isDead = false;

    
    

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // REMOVE LATER
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
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

        animator.SetTrigger("Die");

        // Stop movement
        EnemyMovement movement = GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.enabled = false;
        }


        // Optional: destroy after animation
        Destroy(gameObject, 2f);
    }
    

}
