using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f; // seconds
    public float minHeight = -1f; // range fpr animals
    public float maxHeight = 1f;

    private void OnEnable() {
        // invokes the method 'methodName' in 'time' seconds, then repeatedly every 'repeatRate' seconds
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {
        // create a new object from an existing one, choose the position and the rotation (no rotation for now)
        GameObject animals = Instantiate(prefab, transform.position, Quaternion.identity);
        animals.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}

