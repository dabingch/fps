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

        StartCoroutine(EnemySpawnRoutine());
    }

    public IEnumerator EnemySpawnRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _sprite.enabled = true;
        _collider.enabled = true;
        transform.position = new Vector3(Random.Range(-8.5f, .5f), Random.Range(2f, 6.3f), transform.position.z);
    }
}
