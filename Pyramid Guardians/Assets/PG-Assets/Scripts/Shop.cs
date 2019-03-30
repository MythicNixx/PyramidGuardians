using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint fireTurret;
    public TurretBlueprint waterTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectFireTurret()
    {
        Debug.Log("Fire Turret Selected");
        buildManager.SelectTurretToBuild(fireTurret);

    }

    public void SelectWaterTurret()
    {
        Debug.Log("Water Launcher Selected");
        buildManager.SelectTurretToBuild(waterTurret);
    }
}
