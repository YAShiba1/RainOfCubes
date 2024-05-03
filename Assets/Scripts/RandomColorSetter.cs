using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorSetter : MonoBehaviour
{
    private Renderer _renderer;

    private bool _isCollorSet = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground) && _isCollorSet == false)
        {
            SetRandomColor();
        }
    }

    private void SetRandomColor()
    {
        float randomRed = Random.value;
        float randomGreen = Random.value;
        float randomBlue = Random.value;

        Color randomColor = new Color(randomRed, randomGreen, randomBlue);

        Material material = _renderer.material;

        material.color = randomColor;

        _isCollorSet = true;
    }
}
