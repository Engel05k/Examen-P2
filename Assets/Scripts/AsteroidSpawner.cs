using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnRate = 2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    private void SpawnAsteroid()
    {
        Camera cam = Camera.main;

        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float offset = 1.5f;

        Vector3 spawnPos = Vector3.zero;

        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0:
                spawnPos = cam.transform.position + new Vector3(Random.Range(-camWidth / 2f, camWidth / 2f), camHeight / 2f + offset, 0);
                break;
            case 1:
                spawnPos = cam.transform.position + new Vector3(Random.Range(-camWidth / 2f, camWidth / 2f), -camHeight / 2f - offset, 0);
                break;
            case 2:
                spawnPos = cam.transform.position + new Vector3(-camWidth / 2f - offset, Random.Range(-camHeight / 2f, camHeight / 2f), 0);
                break;
            case 3:
                spawnPos = cam.transform.position + new Vector3(camWidth / 2f + offset, Random.Range(-camHeight / 2f, camHeight / 2f), 0);
                break;
        }

        spawnPos.z = 0f;

        Vector3 randomOffset = Random.insideUnitCircle.normalized * 2f;
        Vector3 targetPos = cam.transform.position + randomOffset;
        targetPos.z = 0f;
        Vector2 directionToCenter = (targetPos - spawnPos).normalized;

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        Asteroid a = asteroid.GetComponent<Asteroid>();
        a.SetDirection(directionToCenter);
        a.SetSpeed(Random.Range(1f, 3f));
    }
}