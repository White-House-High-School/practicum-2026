using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Node : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;
    
    
    public GameObject tower;
    public Vector3 positionOffset = new Vector3(10f, 10f, 10f);
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    // For the blue pulsing effect on nodes
    private bool isHovering = false;
    private float pulseTime = 0f;
    // end
    void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.material = new Material(rend.material);
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void Update() // Update runs on the monitors frame rate so the blues update smoothly
    {
        if (isHovering)
        {
            pulseTime += Time.deltaTime; // Pretty much a clock that only runs when you hover over a node

            float t = Mathf.PingPong(pulseTime, 1f); // Takes a given number and goes back and forth between that and 0
                                                     // like a slider going from one side to the other.

            Color darkBlue = new Color(0f, 0.2f, 0.8f);
            Color lightBlue = new Color(0.4f, 0.7f, 1f);

            rend.material.color = Color.Lerp(darkBlue, lightBlue, t); 
            // Lerp is a function that blends between 2 colors
            // and its based on a value between 0 and 1. So when t is 0, the color will be dark blue, 
            // when t is 1, the color will be light blue, and when t is 0.5, it will be a mix of both blues.
            // PingPong makes the animation go back and forth
        }
    }




    public Vector3 GetBuildPosition ()
    {
        return transform.position;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!buildManager.CanBuild)
        {
            Debug.Log("No tower selected to build.");
                return;
        }
        
        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildTowerOn(this);
    }
    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        if (tower != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        if (!buildManager.CanBuild)
            return;

        Debug.Log("Hovering over node.");
        isHovering = true;
        pulseTime = 0f;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        isHovering = false; 
        rend.material.color = startColor; 
    }
}






