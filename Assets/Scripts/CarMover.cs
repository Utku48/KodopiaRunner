using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Translate(0, 0, speed);
    }
}
