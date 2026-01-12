using UnityEngine;

public class Test : MonoBehaviour
{
    public int enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemies);
    }
}
