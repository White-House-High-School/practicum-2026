/* SHOP CODE */
using System.Runtime.Serialization;
using UnityEngine;

public class Shop : MonoBehaviour
{


    public TowerBlueprint tower1;
    public TowerBlueprint tower2;
    public TowerBlueprint tower3;
    public TowerBlueprint tower4;
    public TowerBlueprint tower5;
    public TowerBlueprint tower6;
    BuildManager buildManager;
    
    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    
    
    public void PurchaseTower1 ()
    {
        Debug.Log("Tower 1 Selected");
        buildManager.SelectTowerToBuild(tower1);
    }
    public void PurchaseTower2 ()
    {
        Debug.Log("Tower 2 Selected");
        buildManager.SelectTowerToBuild(tower2);
    }
    public void PurchaseTower3 ()
    {
        Debug.Log("Tower 3 Selected");
        buildManager.SelectTowerToBuild(tower3);
    }
    public void PurchaseTower4 ()
    {
        Debug.Log("Tower 4 Selected");
        buildManager.SelectTowerToBuild(tower4);
    }

    public void PurchaseTower5 ()
    {
        Debug.Log("Tower 5 Selected");
        buildManager.SelectTowerToBuild(tower5);
    }

    public void PurchaseTower6 ()
    {
        Debug.Log("Tower 6 Selected");
        buildManager.SelectTowerToBuild(tower6);
    }




    
}
