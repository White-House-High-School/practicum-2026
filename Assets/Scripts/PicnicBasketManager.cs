using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PicnicBasketManager : MonoBehaviour

{

    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private int antDamage = 100; // Adjust the damage value as needed
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            buttonManager.CalculatePicnicHP(antDamage);
        }
        
    }

}
