using UnityEngine;

public class Tower: MonoBehaviour
{
    public Transform target;

    [Header("General")]

    public float range;
    public int damage;
    public int cost;

    [Header("Use bullets (default)")]

    public GameObject pelletPrefab;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Use Laser")]

    public bool useLaser = false;
    public LineRenderer lineRenderer;

    [Header("Unity Setup Field")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;
    

  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
        }
            

        LockOnTarget(); 

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
        }

    }
    public void LockOnTarget()
    {
            // Target lock on code
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); 
    }
    public void Shoot()
    {
        GameObject pelletGO = (GameObject) Instantiate(pelletPrefab, firePoint.position, firePoint.rotation);
        Pellet pellet = pelletGO.GetComponent<Pellet>();
        if (pellet != null)
        {
            pellet.Seek(target);
        }
    }
    public void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}