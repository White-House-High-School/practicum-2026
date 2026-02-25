using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Transform target;
    private float speed = 70f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Seek(Transform target)
    {
        this.target = target;
    }   

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame , Space.World);
    }
    void HitTarget()
    {
        Destroy(gameObject);
    }
}
