
using UnityEngine;
using TMPro;

public class CharacterController : MonoBehaviour
{
    [Header("Karakter")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int speed = 5;
    [SerializeField] private float smooth_speed = 10f;

    [Header("Arayuz")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI FinalscoreText;

    [Header("Oyun")]
    [SerializeField] private GameManager gameManager;

    private int health = 1;
    private int score = 0;
    private bool isDead = false;

    private float[] xPositions = { -0.33f, 0f, 0.33f };
    private int currentPosIndex = 1;


    [SerializeField] private AudioSource backgroundMusic;

    void Start()
    {
        Time.timeScale = 1f;

        gameOverPanel.SetActive(false);

        scoreText.text = "Score: " + score;
        FinalscoreText.text = score.ToString();
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.A) && currentPosIndex > 0)
        {
            currentPosIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentPosIndex < 2)
        {
            currentPosIndex++;
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 currentPosition = rb.position;


        float newX = Mathf.MoveTowards(
            currentPosition.x,
            xPositions[currentPosIndex],
            smooth_speed * Time.fixedDeltaTime
        );


        float newZ = currentPosition.z + speed * Time.fixedDeltaTime;

        Vector3 newPosition = new Vector3(
            newX,
            currentPosition.y,
            newZ
        );

        rb.MovePosition(newPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("car"))
        {
            health--;

            Vector3 explosionPosition = other.transform.position;

            Destroy(other.gameObject);


            gameManager.PlayExplosion(explosionPosition);

            Debug.Log("Kalan can: " + health);

            if (health <= 0)
            {
                Die();
            }

            return;
        }

        if (other.CompareTag("torch"))
        {
            score++;

            scoreText.text = "Score: " + score;
            FinalscoreText.text = score.ToString();

            Destroy(other.gameObject);

            Debug.Log("Skor: " + score);


            if (score % 5 == 0)
            {
                health++;

                Debug.Log("Can kazandin! Can: " + health);
            }
        }
    }

    private void Die()
    {
        isDead = true;

        FinalscoreText.text = score.ToString();

        gameOverPanel.SetActive(true);


        backgroundMusic.Stop();

        Time.timeScale = 0f;

        Debug.Log("GAME OVER! Final Score: " + score);
    }
}
