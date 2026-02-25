using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor;

    private GameObject turret;

    public BuildManager buildManager;

    private Renderer rend;
    private Color startColor;


    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild,transform.position, transform.rotation);
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        rend.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        rend.material.color = startColor; 
    }
}