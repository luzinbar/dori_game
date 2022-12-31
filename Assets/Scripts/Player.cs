using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f; // how difficult the game will be - as real life
    public float strength = 5f; // how difficult the game will be

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // first frame for the game
    private void Start() {
        // invokes the method 'methodName' in 'time' seconds, then repeatedly every 'repeatRate' seconds
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); 
    }

    private void OnEnable() { // return the player to the canter of the frame
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // the player goes up OR left click mouse
            direction = Vector3.up * strength; // change the players' spot
        }
        // apply gravity and update the position
        direction.y += gravity * Time.deltaTime; // 12:00 in video
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite() {
        spriteIndex++;
        if (spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } 
        else if (other.gameObject.CompareTag("Scoring")) {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
