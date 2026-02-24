using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;
    
    
    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            Debug.Log("No turret selected to build.");
                return;
        }
        
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild,transform.position, transform.rotation);
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
            return;

        Debug.Log("Hovering over node.");
        rend.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        rend.material.color = startColor; 
    }
}

