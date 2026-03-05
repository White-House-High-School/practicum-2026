using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    
    
    [SerializeField] private int picnicBasketHealth;
    [SerializeField] private bool isGameOver;
    [SerializeField] private GameObject GameOverScreen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (picnicBasketHealth <= 0)
        {
            if (!isGameOver)
            {
                GameOver();
            }
        }
    }
    public void CalculatePicnicHP(int antDamage)
    {
        picnicBasketHealth -= antDamage;
        UnityEngine.Debug.Log("Picnic Basket Health Is Now: " + picnicBasketHealth);
    }
    public void GameOver()
    {
        isGameOver = !isGameOver;
        {
            if (isGameOver)
            {
                UnityEngine.Debug.Log("Game Over!");
                Time.timeScale = 0.0f;
                GameOverScreen.SetActive(true);
                return;
            }
            else
            {
                Time.timeScale = 1.0f;
                GameOverScreen.SetActive(false);
                return;
            }
        }
    }
}
