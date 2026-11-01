using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Takip Edilecek Karakter")]
    [SerializeField] private Transform player;

    [Header("Kamera Konumu")]
    [SerializeField] private float height = 1.5f;
    [SerializeField] private float distance = 2.5f;

    [Header("Kamera Takip Hizi")]
    [SerializeField] private float followSpeed = 15f;

    void LateUpdate()
    {
        if (player == null) return;

        // Kamera karakterin X, Y ve Z konumunu takip eder.
        Vector3 targetPosition = new Vector3(
            player.position.x,
            player.position.y + height,
            player.position.z - distance
        );

        // Yumuşak takip
        float smooth = 1f - Mathf.Exp(
            -followSpeed * Time.deltaTime
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smooth
        );

        // Kamera sabit açıyla ileri bakar.
        transform.rotation = Quaternion.Euler(15f, 0f, 0f);
    }
}