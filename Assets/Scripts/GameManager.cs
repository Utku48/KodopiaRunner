using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private List<GameObject> roads = new List<GameObject>();
    [SerializeField] private Transform player;
    [SerializeField] private Transform carSpawn;
    [SerializeField] private ParticleSystem explosion;

    private float previousPlayerZ;

    [SerializeField] private int roadCount = 5;
    [SerializeField] private float roadLength = 3.2f;

    private float nextRoadZ;
    private bool explosionPlayed = false;

    void Start()
    {
        nextRoadZ = player.position.z;
        previousPlayerZ = player.position.z;

        explosion.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        for (int i = 0; i < roadCount; i++)
        {
            CreateRoad();
        }
    }

    void Update()
    {
        if (player.position.z > nextRoadZ - (roadLength * roadCount))
        {
            CreateRoad();
        }

        if (characterController.isdead && !explosionPlayed)
        {
            explosionPlayed = true;

            ParticleSystem newExplosion = Instantiate(
                explosion,
                player.position,
                Quaternion.identity
            );

            newExplosion.Play(true);
        }
    }

    private void FixedUpdate()
    {
        float deltaZ = player.position.z - previousPlayerZ;

        carSpawn.position += new Vector3(0, 0, deltaZ);

        previousPlayerZ = player.position.z;
    }

    void CreateRoad()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, nextRoadZ);

        GameObject selectedRoad = roads[Random.Range(0, roads.Count)];

        Instantiate(selectedRoad, spawnPosition, Quaternion.identity);

        nextRoadZ += roadLength;
    }
}