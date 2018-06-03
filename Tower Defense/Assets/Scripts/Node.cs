using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffSet; //needed this because turret was half burried in node.

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start ()
	{
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
	}

	private void OnMouseDown ()
	{

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (buildManager.GetTurretToBuild() == null)
            return;

		 if (turret != null)
        {
            Debug.Log("Cant build there - ToDO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
       turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);
	}



	void OnMouseEnter()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;
        
        rend.material.color = hoverColor; //changes color on hover.

	}

	void OnMouseExit()
	{
        rend.material.color = startColor; // changes back to original color when not hovered.
	}

}
