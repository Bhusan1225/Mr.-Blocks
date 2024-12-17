
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalInput ;
    private float verticalInput;
    public float speed = 5f;
    private Rigidbody2D rb;

   
    //level complete reference
    public LevelManager levelManager;
    [SerializeField]  private SoundManager soundManager;


    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
     
       
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Debug.Log($"Horizontal: {horizontalInput}, Vertical: {verticalInput}");
    }

    private void MovePlayer()
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        soundManager.PlayGameOverAudio();
        levelManager.OnPlayerDeath();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }



    private void LevelComplete()
    {
        //soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
}
