using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnerscript : MonoBehaviour {

    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] protected Transform obstacleParent;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    private float timeUntilObstacleSpawn;

    private void Start() {
        GameManager.instance.onGameOver.AddListener(ClearObstacles);
    }

    private void Update() {
        if (GameManager.instance.isPlaying) {
            SpawnLoop();
        }
        }
    private void SpawnLoop() {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime) {
            spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void ClearObstacles() {
        foreach(Transform child in obstacleParent) {
            Destroy(child.gameObject);
        }
    }
         
    private void spawn() {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }

}