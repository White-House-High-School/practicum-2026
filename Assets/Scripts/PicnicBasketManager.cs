using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PicnicBasketManager : MonoBehaviour

{

    private GameManager gameManager;
    [SerializeField] private int antDamage; // Adjust the damage value as needed
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameManager.CalculatePicnicHP(antDamage);
        }
        
    }

}
