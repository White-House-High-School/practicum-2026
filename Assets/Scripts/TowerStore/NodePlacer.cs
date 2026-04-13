using UnityEngine;

public class NodePlacer : MonoBehaviour
{

    [SerializeField] private int mapWidth; // The width of the playable field, in nodes.
    [SerializeField] private int mapHeight; // The height of the playable field, in nodes.
    [SerializeField] private GameObject Node; // A node object
    private int mapArea; // The total area of the playable field, in nodes.
    void Awake()
    {

        for (int i = 0; i < mapArea; i++)
        {
            //Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
