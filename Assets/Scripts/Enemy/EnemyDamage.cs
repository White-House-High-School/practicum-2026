using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1000;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Goal"))
        {

            BaseHealth baseHealth = collision.gameObject.GetComponentInParent<BaseHealth>();

            Debug.Log("BaseHealth found: " + baseHealth);

            if (baseHealth != null)
            {
                baseHealth.TakeDamage(damage);
                
            }

            

            Destroy(gameObject);
        }
    }
}