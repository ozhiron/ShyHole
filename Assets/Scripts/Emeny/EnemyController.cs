using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public Transform[] target;

    private float speed = 1f;
    private int newTarget;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpawnerEnemy").GetComponent<GeneratorForHoles>().positions;
        newTarget = Random.Range(0, target.Length);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward);
        
        transform.position = Vector2.MoveTowards(transform.position, target[newTarget].position,
            speed * Time.deltaTime);
    }
}
