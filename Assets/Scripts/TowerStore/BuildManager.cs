using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    
    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }
    
    public void BuildTowerOn (Node node)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log ("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= towerToBuild.cost;

        GameObject tower = Instantiate(towerToBuild.prefab, node.GetBuildPosition() + towerToBuild.positionOffset, Quaternion.identity);
        node.tower = tower;

        Debug.Log ("Turret build! Money left: " + PlayerStats.Money);
        return;
    }

    public void SelectTowerToBuild (TowerBlueprint tower)
    {
        towerToBuild = tower;
    }

}