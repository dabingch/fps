using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;

    [SerializeField]
    private Collider _collider;

    public void Kill()
    {
        _sprite.enabled = false;
        _collider.enabled = false;

        StartCoroutine(RespwanRoutine());
    }

    public IEnumerator RespwanRoutine()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        _sprite.enabled = true;
        _collider.enabled = true;
    }
}