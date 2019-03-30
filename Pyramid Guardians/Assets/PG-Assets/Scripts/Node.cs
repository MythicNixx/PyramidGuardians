using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 posOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer nodeRenderer;
    private Color startColor;

    private void Start()
    {
        buildManager = BuildManager.instance;
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("This spot has been used --- TODO: Disaply on Screen.");
            return;
        }

        buildManager.BuildTurretOn(this);

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + posOffset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(buildManager.HasMoney)
        {
            nodeRenderer.material.color = hoverColor;
        }

        else
            nodeRenderer.material.color = notEnoughMoneyColor;

    }

    void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }
}
