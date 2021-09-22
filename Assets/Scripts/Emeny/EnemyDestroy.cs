using System;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private float time;
    void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Finish!"))
        {
            if (time > 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
