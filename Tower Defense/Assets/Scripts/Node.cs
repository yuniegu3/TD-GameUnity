using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffSet;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    void Start ()
	{
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
	}

	private void OnMouseDown ()
	{
		 if (turret != null)
        {
            Debug.Log("Cant build there - ToDO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
       turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffSet, transform.rotation);
	}



	void OnMouseEnter ()
	{
        rend.material.color = hoverColor; //changes color on hover.

	}

	void OnMouseExit ()
	{
        rend.material.color = startColor; // changes back to original color when not hovered.
	}

}
