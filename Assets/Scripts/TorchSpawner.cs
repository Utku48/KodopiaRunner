using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    [SerializeField] private Transform player;

    [SerializeField] private float minSpawnTime = 3f;
    [SerializeField] private float maxSpawnTime = 6f;

    [SerializeField] private float spawnDistance = 12f;
    [SerializeField] private float torchY = 0.5f;

    private float[] xPositions = { -0.33f, 0f, 0.33f };

    void Start()
    {
        StartCoroutine(SpawnTorch());
    }


    IEnumerator SpawnTorch()
    {
        while (true)
        {
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(randomTime);

            int randomIndex = Random.Range(0, xPositions.Length);

            Vector3 spawnPosition = new Vector3(xPositions[randomIndex], torchY,
                player.position.z + spawnDistance);

            Instantiate(torch, spawnPosition, Quaternion.Euler(0, -270, 0));
        }
    }

}
