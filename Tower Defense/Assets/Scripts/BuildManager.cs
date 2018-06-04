using UnityEngine;
using UnityEngine.UI; //lets you use the UI -Text 

public class BuildManager : MonoBehaviour
{
    // a way to build one buildmanager and share it 
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More then one builfmanager is in scene!");
            return;
        }
        instance = this; // this says this buildmanager is going to be put into instance variable.

    }

    public GameObject standardTurretPrefab;
    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public Text moneyText;

    public bool CanBuild { get { return turretToBuild != null; }  } //propery (can never be set, this is checking if turret is not null, giving true or false)
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; }  } 

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
       
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Built! Money left: " + PlayerStats.Money);
        moneyText.text = ("$" + PlayerStats.Money).ToString();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}

