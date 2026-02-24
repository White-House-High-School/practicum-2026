using System.Diagnostics;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    
    public static BuildManager instance;
    
    void Awake ()
    {
        if (instance != null)
        {
            UnityEngine.Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


    public GameObject PurchaseTower1;
    public GameObject PurchaseTower2;
    public GameObject PurchaseTower3;
    public GameObject PurchaseTower4;
    public GameObject PurchaseTower5;
    public GameObject PurchaseTower6;
    
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}
/* 18:14 */