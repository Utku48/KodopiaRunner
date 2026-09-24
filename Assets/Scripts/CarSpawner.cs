using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPosition;
    [SerializeField] private GameObject[] carPrefabs;

    [SerializeField] private float minSpawnTime = 1;
    [SerializeField] private float maxSpawnTime = 3;


    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);


            //Rasgele referans noktası seç
            int randomIndex = Random.Range(0, spawnPosition.Length);
            Transform spawnPoint = spawnPosition[randomIndex];

            //Rasgele araba üret
            Instantiate(carPrefabs[
                Random.Range(0, carPrefabs.Length)], spawnPoint.position, spawnPoint.rotation);


        }
    }

}
