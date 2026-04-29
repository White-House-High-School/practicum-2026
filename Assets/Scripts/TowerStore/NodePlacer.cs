using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
[ExecuteAlways]
public class NodePlacer : MonoBehaviour
{

[SerializeField] private float nodeGap = 1.25f; // Gap between the nodes
private float NodeX; // Size of the node on the X axis + NG
private float NodeZ; // Size of the node on the Z axis + NG
[SerializeField] private int mapLength; // Map X in nodes.
[SerializeField] private int mapWidth; // Map Z in nodes.
[SerializeField] private GameObject NodePrefab; // A node object
[SerializeField] private Transform startPos; // The one and only ANTHILLLLLLL
private GameObject[,] NodeArray; // The total area of the playable field, in nodes.

BoxCollider nodeCollider;
    private int mapArea; // The total area of the playable field, in nodes.
    void Start()
    {
        
        NodeX = startPos.position.x;
        NodeZ = startPos.position.z;
        nodeCollider = NodePrefab.GetComponent<BoxCollider>();
        NodeArray = new GameObject[mapLength, mapWidth];
        makeNodeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu ("Place Node Grid")]
    void makeNodeGrid()
    {
        float nodeSizeX = NodePrefab.transform.localScale.x;
        float nodeSizeZ = NodePrefab.transform.localScale.z;

        float defaultX = startPos.position.x;
            for (int i = 0; i < mapLength; i++)
            {       
                 
                for (int j = 0; j < mapWidth; j++)
                {
                    bool canPlace = true;

                    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Scene Object") )
                    {
                        if (pointIsInsideGameObject(obj, new Vector3(NodeX, 0, NodeZ)))
                        {
                            canPlace = false;
                            Debug.Log(canPlace);
                        }
                        else
                        {
                            canPlace = true;
                            Debug.Log(canPlace);
                        }
                    }

                    if (canPlace)
                    {
                        NodeArray[i, j] = placeNode("Tower Node", NodeX, NodeZ);
                        Debug.Log("Placing");
                    }
                     
                    NodeX += nodeGap + nodeSizeX; // Problem here
                    //Debug.Log(nodeSizeZ);
                    
                }
                NodeZ += nodeGap + nodeSizeZ;
                NodeX = defaultX; 
            }
    }

    [ContextMenu ("Remove All Nodes")]
    void RemoveNodes()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tower Node") )
        {
            DestroyImmediate(obj);
        }
    }
    bool pointIsInsideGameObject(GameObject obj, Vector3 point)
    {

        Vector3 closest = obj.GetComponent<Collider>().ClosestPoint(point);
        
        return closest == point;
    }

    GameObject placeNode(string tag, float Nx, float Nz)
    {

        Vector3 position = new Vector3(Nx, 0, Nz);
        GameObject node = Instantiate(NodePrefab, position, Quaternion.identity);
        
        node.gameObject.tag = tag;

        return node;
    }
    
}
