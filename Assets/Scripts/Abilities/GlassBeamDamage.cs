using UnityEngine;

public class GlassBeamDamage : MonoBehaviour
{
    public int damage = 10;
    public float damageInterval = 2f;
    public int maxTotalDamage = 40;

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