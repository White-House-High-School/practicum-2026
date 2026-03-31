using UnityEngine;

public class BasicTower : Tower
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
                if (target == null)
            return; 
            if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
         }
       fireCountdown -= Time.deltaTime;
    }

}