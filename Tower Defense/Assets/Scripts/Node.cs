using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffSet; //needed this because turret was half burried in node.

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }


    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Cant build there - ToDO: Display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
        void OnMouseEnter ()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!buildManager.CanBuild)
                return;

            if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor; //changes color on hover.
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

           

        }

        void OnMouseExit ()
        {
            rend.material.color = startColor; // changes back to original color when not hovered.
        }

    }
