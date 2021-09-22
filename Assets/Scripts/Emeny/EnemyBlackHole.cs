using UnityEngine;

public class EnemyBlackHole : MonoBehaviour
{
    public float HP = 10;

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")) 
        {
            Destroy(other.gameObject);
            HP += 10;
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HP += 1;
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
        
        if(other.CompareTag("BlackHole")) 
        {
            if (other.GetComponent<EnemyBlackHole>().HP >= HP)
            {
                HP -= 1;
                gameObject.transform.localScale -= new Vector3(0.02f, 0.02f, 0);
            }
            if (other.GetComponent<EnemyBlackHole>().HP < HP)
            {
                HP += 1;
                gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0);
            }
        }
    }
}
