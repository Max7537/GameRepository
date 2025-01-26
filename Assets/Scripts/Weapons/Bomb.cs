using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explodeSpeed;
    [SerializeField] private ParticleSystem _explostionParticle;

    void Start()
    {
        StartCoroutine(Explode());
    }

    private void FixedUpdate()
    {
        transform.Translate(0, -0.1f, 0, Space.World);
        transform.Rotate(0, 0, 3);
    }

    private IEnumerator Explode()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        while (color.g > 0 && color.b > 0)
        {
            yield return null;
            color.g -= 0.5f * Time.deltaTime;
            color.b -= 0.5f * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = color;
        }
        ParticleSystem particleSystem = Instantiate(_explostionParticle, transform.position, Quaternion.identity);
        particleSystem.Play();
        Destroy(gameObject);
    }
}
