using UnityEngine;

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
    public GameObject anotherTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}

