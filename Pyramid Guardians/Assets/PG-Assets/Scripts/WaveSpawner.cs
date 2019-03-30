using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float cntDown = 2.5f;

    public Text waveCntDownTxt;

    private int waveIndex = 1;

    private void Update()
    {
        if(cntDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            cntDown = timeBetweenWaves;
        }

        cntDown -= Time.deltaTime;

        cntDown = Mathf.Clamp(cntDown, 0f, Mathf.Infinity);

        waveCntDownTxt.text = "Wave: " + string.Format("{0:00}", cntDown);
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
