using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // the speed of the ant
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        //to get the ant to actually move by direction and magnitude
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
