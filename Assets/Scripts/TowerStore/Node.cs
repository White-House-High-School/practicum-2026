using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;
    
    [Header("Optional")]
    public GameObject tower;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
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
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        if (!buildManager.CanBuild)
            return;

        Debug.Log("Hovering over node.");
        rend.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        rend.material.color = startColor; 
    }
}