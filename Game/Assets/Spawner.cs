using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public GameObject blockPrefab;
    public ScoreCounter sc;
    public float[] spawnRates;

    private float spawnRate;
    private Coroutine spawnRoutine;
    private bool isSpawning;

    public void ResetSpawner()
    {
        spawnRate = spawnRates[0];
    }

    public void StartSpawning()
    {
        ResetSpawner();
        isSpawning = true;
        spawnRoutine = StartCoroutine(Spawn());
    }

    public void StopSpawning()
    {
        isSpawning = false;
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
    }

    private void Update()
    {
        if (!isSpawning) return;

        // adjust difficulty
        if (sc.CurrentScore > 50 && spawnRate == spawnRates[2]) spawnRate = spawnRates[3];
        else if (sc.CurrentScore > 30 && spawnRate == spawnRates[1]) spawnRate = spawnRates[2];
        else if (sc.CurrentScore > 10 && spawnRate == spawnRates[0]) spawnRate = spawnRates[1];
    }

    private IEnumerator Spawn()
    {
        while (isSpawning)
        {
            float t = Random.Range(spawnRate - .5f, spawnRate + .5f);
            yield return new WaitForSeconds(t);
            Instantiate(
                blockPrefab,
                spawnPoints[Random.Range(0, spawnPoints.Length)],
                Quaternion.identity);
        }
    }
}
