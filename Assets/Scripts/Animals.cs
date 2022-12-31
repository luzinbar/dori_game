using UnityEngine;

public class Animals : MonoBehaviour
{
    // public float speed = 5f;
    public float speed;
    public float leftEdge;

    private void Start()
    {
        speed = FindObjectOfType<GameManager>().Get_score() / 15 + 5f; // speed up every 15 obstacles
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        Debug.Log("speed is: " + speed);
    }  

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}
