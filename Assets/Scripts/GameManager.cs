
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Yol Sistemi")]
    [SerializeField] private List<GameObject> roads = new List<GameObject>();
    [SerializeField] private Transform player;
    [SerializeField] private Transform carSpawn;

    [SerializeField] private int roadCount = 5;
    [SerializeField] private float roadLength = 3.2f;

    [Header("Patlama Efekti")]
    [SerializeField] private ParticleSystem explosion;

    private float previousPlayerZ;
    private float nextRoadZ;

    void Start()
    {
        nextRoadZ = player.position.z;
        previousPlayerZ = player.position.z;

        for (int i = 0; i < roadCount; i++)
        {
            CreateRoad();
        }
    }

    void Update()
    {
       
        if (player.position.z >
            nextRoadZ - (roadLength * roadCount))
        {
            CreateRoad();
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
        Vector3 spawnPosition = new Vector3(
            0f,
            0f,
            nextRoadZ
        );

        GameObject selectedRoad = roads[
            Random.Range(0, roads.Count)
        ];

        Instantiate(
            selectedRoad,
            spawnPosition,
            Quaternion.identity
        );

        nextRoadZ += roadLength;
    }

    // ARABA PATLAMA SISTEMI
    public void PlayExplosion(Vector3 position)
    {
        if (explosion == null) return;

        ParticleSystem newExplosion = Instantiate(
            explosion,
            position,
            Quaternion.identity
        );

        newExplosion.Play(true);
    }
}
