using UnityEngine;

public class FoodController : MonoBehaviour
{
    public Transform[] target;
    public int indexGay;

    private float speed = 1f;
    private int newTarget;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpawnerFood").GetComponent<Generator>().positions;
        newTarget = Random.Range(0, target.Length);

        indexGay = Random.Range(0, 2);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target[newTarget].position,
            speed * Time.deltaTime);
    }
}

