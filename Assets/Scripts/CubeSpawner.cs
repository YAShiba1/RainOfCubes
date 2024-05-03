using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField][Min(0)] private float _spawnAreaRadius;
    [SerializeField] private float _delay;
    [SerializeField] private Cube _cubePrefab;

    private void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _spawnAreaRadius);
    }

    private IEnumerator SpawnWithDelay()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            yield return waitForSeconds;

            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        Vector2 randomPointInsideCircle = Random.insideUnitCircle * _spawnAreaRadius;

        float randomX = transform.position.x + randomPointInsideCircle.x;
        float randomZ = transform.position.z + randomPointInsideCircle.y;

        Instantiate(_cubePrefab, new Vector3(randomX, transform.position.y, randomZ), Quaternion.identity);
    }
}
