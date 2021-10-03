using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Spawning")]
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] Vector3 PlayerSpawnPoint;
    [SerializeField] float PlayerRespawnTimer;

    [Header("Skeleton Spawning")]
    [SerializeField] GameObject SkeletonPrefab;
    [SerializeField] Collider2D SkeletonSpawnZone;
    int skeletonsToSpawn = 1;
    [SerializeField] int extraSkeletonsPerRound;

    [Header("Bat Spawning")]
    [SerializeField] GameObject BatPrefab;
    [SerializeField] List<Collider2D> BatSpawnZones;
    int batsToSpawn = 0;
    [SerializeField] int extraBatsPerRound;

    [Header("User Interface")]
    [SerializeField] UI UserInterface;

    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        EndEventBroker.EndRoundEvent += OnRoundEnd;
        EndEventBroker.GameOverEvent += OnGameOver;
    }

    private void OnDestroy()
    {
        EndEventBroker.EndRoundEvent -= OnRoundEnd;
        EndEventBroker.GameOverEvent -= OnGameOver;
    }

    void OnRoundEnd()
    {
        score++;
        skeletonsToSpawn += extraSkeletonsPerRound;
        batsToSpawn += extraBatsPerRound;
        StartCoroutine(SpawnEntities());
    }

    void OnGameOver()
    {
        UserInterface.ShowGameOverScreen();
    }

    IEnumerator SpawnEntities()
    {
        //player first
        yield return new WaitForSeconds(PlayerRespawnTimer);
        Instantiate(PlayerPrefab, PlayerSpawnPoint, Quaternion.identity);

        //skeletons
        for (int i = 0; i < skeletonsToSpawn; i++)
        {
            // Get a location from inside the spawn zone
            float spawn_x = Random.Range(SkeletonSpawnZone.bounds.min.x, SkeletonSpawnZone.bounds.max.x);
            float spawn_y = Random.Range(SkeletonSpawnZone.bounds.min.y, SkeletonSpawnZone.bounds.max.y);
            Vector3 spawnPoint = new Vector3(spawn_x, spawn_y, -1.5f);
            Instantiate(SkeletonPrefab, spawnPoint, Quaternion.identity);
        }

        //bats
        for (int i = 0; i < batsToSpawn; i++)
        {
            // Get a location from inside the spawn zone
            int index = Random.Range(0, BatSpawnZones.Count);
            Collider2D spawnZone = BatSpawnZones[index];
            bool isMovingRight = index == 0;
            float spawn_x = Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x);
            float spawn_y = Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y);
            Vector3 spawnPoint = new Vector3(spawn_x, spawn_y, -2f);
            Bat bat = Instantiate(BatPrefab, spawnPoint, Quaternion.identity).GetComponent<Bat>();
            bat.isMovingRight = isMovingRight;
        }

    }
}
