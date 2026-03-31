/*
using UnityEngine;
using UnityEngine.UI;

public class RainbowColorFlow : MonoBehaviour
{
    public float speed = 1f;  // Color change speed
    private Image img;
    private float hue; // 

    void Awake()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        hue += speed * Time.deltaTime;
        if (hue > 1f) hue = 0f;

        img.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}
*/