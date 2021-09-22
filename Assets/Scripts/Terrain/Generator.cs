using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public Transform[] positions;
    public GameObject[] starships;
    public float delay;

    private float firstStep, nextStep, secondStep, lastStep, time;

    private void Start()
    {
        firstStep = delay;
        nextStep = delay - 0.1f;
        secondStep = delay - 0.2f;
        lastStep = delay - 0.25f;
    }

    void Update()
    {
        int position = Random.Range(0, positions.Length);
        int starship = Random.Range(0, starships.Length);
        
        if (time >= delay)
        {
            Spawn(position, starship);
        }

        time += Time.deltaTime;
    }
    void Spawn(int position, int starship)
    {
        Instantiate(starships[starship], positions[position]);
        Instantiate(starships[1], positions[position]);
        
        if (time > 0)
        {
            delay += firstStep;
        } else if (time > 30)
        {
            delay += nextStep;
        } else if (time > 50)
        {
            delay += secondStep;
        } else if (time > 90)
        {
            delay += lastStep;
        }
    }
}
