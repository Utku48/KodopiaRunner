using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [Header("Hız Ayarları")]
    [SerializeField] private float speed =2f;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float maxSpeed = 10f;
    void Update()
    {
        float currentSpeed = speed * Time.timeSinceLevelLoad * speedIncrease;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
    }
}
