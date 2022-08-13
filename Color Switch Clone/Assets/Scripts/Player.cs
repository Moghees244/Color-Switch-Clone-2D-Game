using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform camPosition;
    public float jumpForce;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Color[] circleColors;
    string playerCurrentColor;
    int score;
    public Text scoreText;
    public Text scoreText2;
    public GameObject gameOverUI;

    [System.NonSerialized]
    public int obstaclesCrossed;
    public GameObject spawner;
    public GameObject audio;

    private void Start()
    {
        gameOverUI.SetActive(false);
        score = 0;
        setRandomColor();
    }

    private void setRandomColor()
    {
        Color prevColor = spriteRenderer.color;

        spriteRenderer.color = circleColors[UnityEngine.Random.Range(0, 4)];

        if (spriteRenderer.color == prevColor)
            setRandomColor();
    }

    void Update()
    {
        scoreText.text = score.ToString("D5");

        if (Input.GetButtonDown("Jump") || Input.GetMouseButton(0))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 3f;
            rigidBody.velocity = Vector2.up * jumpForce;
        }

        if (transform.position.y <= spawner.GetComponent<Spawner>().lastObstacleHeight)
            if (obstaclesCrossed != 0)
                Die();

        if (obstaclesCrossed == 0 && transform.position.y < -10f)
            Die();
    }

    private void OnTriggerEnter2D(Collider2D color)
    {
        if (spriteRenderer.color == circleColors[0])
            playerCurrentColor = "Blue";
        else if (spriteRenderer.color == circleColors[1])
            playerCurrentColor = "Yellow";
        else if (spriteRenderer.color == circleColors[2])
            playerCurrentColor = "Purple";
        else if (spriteRenderer.color == circleColors[3])
            playerCurrentColor = "Pink";

        if (color.tag != playerCurrentColor && color.tag != "ColorChanger")
            Die();

        if (color.tag == "ColorChanger")
        {
            spriteRenderer.color = color.GetComponent<SpriteRenderer>().color;
            audio.GetComponent<gameAudio>().onColorChange();
            score += 5;
            obstaclesCrossed++;
            Destroy(color.gameObject);
        }
    }

    public void Die()
    {
        spawner.GetComponent<Spawner>().onDeath();

        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameOverUI.SetActive(true);

        audio.GetComponent<gameAudio>().onGameOver();
        scoreText2.text = score.ToString("D5");
    }
}
