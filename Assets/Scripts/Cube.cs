using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SelfDestroyWithDelay());
    }

    private IEnumerator SelfDestroyWithDelay()
    {
        int minLifetime = 2;
        int maxLifetime = 6;

        int randomNumber = Random.Range(minLifetime, maxLifetime);

        var waitForSeconds = new WaitForSeconds(randomNumber);

        yield return waitForSeconds;

        Destroy(gameObject);
    }
}
