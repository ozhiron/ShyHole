using UnityEngine;

public class GeneratorForHoles : MonoBehaviour
{
    public Transform[] positions;
    public GameObject hole;
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
        int position = Random.Range(0, positions.Length-1);
        
        if (time >= delay)
        {
            Spawn(position);
        }
        
        time += Time.deltaTime;
    }
    void Spawn(int position)
    {
        Instantiate(hole, positions[position]);
        
        if (time > 0)
        {
            delay += firstStep;
        } else if (time > 25)
        {
            delay += nextStep;
        } else if (time > 50)
        {
            delay += secondStep;
        } else if (time > 90)
        {
            delay += lastStep;
        } else if (time < 150)
        {
            delay += lastStep;
        }
    }
}
