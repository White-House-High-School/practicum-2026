using UnityEngine;

public class BugSprayDamage : MonoBehaviour
{
    public int damage = 5;
    public float damageInterval = 5f;
    public int maxTotalDamage = 25;

    private float timer;
    private int totalDamageDealt = 0;

    private void OnTriggerStay(Collider other)
    {
        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();

        if (enemy != null)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                enemy.TakeDamage(damage);

                totalDamageDealt += damage;

                timer = damageInterval;

                if (totalDamageDealt >= maxTotalDamage)
                {
                    Destroy(gameObject, 2f);
                }
            }
        }
    }
}