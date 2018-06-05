using UnityEngine;
// using UnityEngine.UI; //lets you use the UI -Text 

public class BuildManager : MonoBehaviour
{
    // a way to build one buildmanager and share it 
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More then one buildmanager is in scene!");
            return;
        }
        instance = this; // this says this buildmanager is going to be put into instance variable.

    }

    public GameObject standardTurretPrefab;
    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; }  } //propery (can never be set, this is checking if turret is not null, giving true or false)
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; }  } 

   
    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}

