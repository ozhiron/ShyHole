using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public Text terminal, MaxScoreGoodGay, MaxBadassGay, afterNeedEat;
    
    public Image Bar;
    public GameObject deathPanel, winBadPanel, winGoodPanel, EndScorePanel;
    public AudioSource audioSource;
    public AudioClip bite;
    
    private float HP = 50f;
    private int scoreGood, scoreBad;
    private int scoreEat = 15;
    private bool hasMassage;

    private string[] firstPartForGood =
    {
        "Capitan Fidgenton, ", "Captain Rofleen, ", "Captain Fon Avarken, ", "Captain El Du Pua , ", "Captain Rojers , ", "Captain Vahtang , ",
        "Pilot Woodens, ", "Pilot Gutron, ", "Pilot Vyacheslav, "
    };
    
    private string[] middlePartForGood =
    {
        "wanted to get home for dinner.", "had a full gift rack.", "lost a family in the war against neo-locusts.","loved animals and his wife."
            ,"was an exemplary citizen.", "solved the problem of overpopulation of the earth.", "wanted to become an esportsman.", "dreamed to seeing dark matter.", "can't open doors.", "saved the last living person.",
            "starred in a TV show about body positive.", "served in the space fleet at the call of.", "died of a heart attack.", "caught the thief by the tentacle.", "relatively proved the theory of non-relatively.",
            "discovered a race of goose planetary gutters.", "scared grandfather"
    };

    private string[] firstPartForBadass =
    {
        "Captain Beacon, ", "Captain Gooos, ", "Captain Alex, ", "Captain just cap, ", "Captain Hoolins, ", "Captain Rabbitson, ", "Captain Deernasten, ", "Pilot Ozheron, ",
        "Pilot Frolonter, ", "Pilot Freemad, ", "Pilot IIIgor, "
    };
    private string[] middlePartForBadass =
    {
        "blamed the victim.", "had an accident with a black hole.", "stole a piece of the sun.", "did not get vaccinated.", "raped 14 other races.", "predicts the fate of people.", "envied the younger sister.",
        "foiled the election of 3543.", "on the run for evidence of the absence of G0d.", "grows artificial children for infertile.", "ate the last living person", "brought the neo-locust race.", "lived under an inhabited universe for 120 years.",
        "afraid of black holes", "banned event horizon.", "planned to end the time", "called for revolution in the sun", "held hostage by a reasonable goose"
    };
    
    
    private float time, delay;
    private object Color;

    private void Start()
    {
        if (HP > 1)
        {
            HP /= 100;
        }
}

    void Update()
    {
        transform.Rotate(Vector3.forward);

        afterNeedEat.text = "To eat today: " + scoreEat;
        
        if (HP < 0.3f || HP > 0.7f)
        {
            Bar.GetComponent<Image>().color = new Color(0.6f, 0.1f,0.4f);
        }
        else
        {
            Bar.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
        
        if (time > delay)
        {
            NewScale();
        }

        if (HP <= 0 || HP >= 1)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
            Destroy(gameObject);
        }
        if (scoreEat <= 0)
        {
            if (scoreBad > scoreGood)
            {
                Time.timeScale = 0;
                winBadPanel.SetActive(true);
                MaxBadassGay.text = "Bad guys " + scoreBad;
                MaxScoreGoodGay.text = "Good guys: " + scoreGood;
                EndScorePanel.SetActive(true);
                scoreEat += 5;
            }
            if (scoreGood > scoreBad)
            {
                Time.timeScale = 0;
                winGoodPanel.SetActive(true);
                MaxBadassGay.text = "Bad guys: : " + scoreBad;
                MaxScoreGoodGay.text = "Good guys: " + scoreGood;
                EndScorePanel.SetActive(true);
                scoreEat += 5;
            }
        }
        
        time += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")) 
        {
            hasMassage = true;
            audioSource.clip = bite;
            audioSource.Play();
            Destroy(other.gameObject);
            HP += 0.15f;
            gameObject.transform.localScale += new Vector3(0.15f, 0.15f, 0);

            scoreEat--;

            if (other.GetComponentInChildren<FoodController>().indexGay == 1)
            {
                terminal.text += "                                                               ";;
                
                terminal.text += "Massage: " + firstPartForGood[Random.Range(0, firstPartForGood.Length)] +
                                 middlePartForGood[Random.Range(0, middlePartForGood.Length)];

                scoreGood++;

                hasMassage = false;
            }
            else if (other.GetComponentInChildren<FoodController>().indexGay == 0)
            {
                terminal.text += "                                                               ";
                
                terminal.text += "Massage: " + firstPartForBadass[Random.Range(0, firstPartForBadass.Length)] +
                                 middlePartForBadass[Random.Range(0, middlePartForBadass.Length)];
                
                scoreBad++;

                hasMassage = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("BlackHole")) 
        {
            audioSource.clip = bite;
            audioSource.Play();
            HP -= 0.01f;
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        }
    }

    void NewScale()
    {
        HP = HP - 0.01f;
        Bar.fillAmount = HP;
        delay += 0.5f;
        gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
    }    
}
