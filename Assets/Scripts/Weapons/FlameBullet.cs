using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBullet : Bullet
{

    private void Start()
    {
        StartCoroutine(StartFadeCountDown());
    }

    private void Update()
    {
        base.Update();
    }

    private IEnumerator StartFadeCountDown()
    {
        Color spriteRenderer = GetComponent<SpriteRenderer>().color;
        while (spriteRenderer.a != 0)
        {
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.a -= 0.05f;
            GetComponent<SpriteRenderer>().color = spriteRenderer;
        }
        Destroy(gameObject);
    }
}
