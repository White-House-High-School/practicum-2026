using UnityEngine;

public class EnemyTestMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 2);
        if (transform.position.z >= 30)
        {
            Destroy(gameObject);
        }
    }
}
