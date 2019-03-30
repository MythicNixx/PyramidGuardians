using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager in scene");
            return;
        }

        instance = this;
    }

    public GameObject fireTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.costOfTurret; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.costOfTurret)
        {
            Debug.Log("You're too poor");
            return;
        }

        PlayerStats.Money -= turretToBuild.costOfTurret;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject builtEffect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(builtEffect, 5f);

        Debug.Log("Turret Built! Money Left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
