/* SHOP CODE */
using System.Runtime.Serialization;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    BuildManager buildManager;
    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    


    public void PurchaseTower1 ()
    {
        Debug.Log("Tower 1 Selected");
        buildManager.SetTurretToBuild(buildManager.PurchaseTower1);
    }
    public void PurchaseTower2 ()
    {
        Debug.Log("Tower 2 Selected");
        buildManager.SetTurretToBuild(buildManager.PurchaseTower2);
    }
    public void PurchaseTower3 ()
    {
        Debug.Log("Tower 3 Selected");
        buildManager.SetTurretToBuild(buildManager.PurchaseTower3);
    }
    public void PurchaseTower4 ()
    {
        Debug.Log("Tower 4 Selected");
        buildManager.SetTurretToBuild(buildManager.PurchaseTower4);
    }

    public void PurchaseTower5 ()
    {
        Debug.Log("Tower 5 Selected");
        buildManager.SetTurretToBuild(buildManager.PurchaseTower5);
    }

    public void PurchaseTower6 ()
    {
        Debug.Log("Tower 6 Selected");
        buildManager.SetTurretToBuild(buildManager.PurchaseTower6);
    }




    
}
