using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Text Score;
    public int scoreNum;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + scoreNum;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Points")
        {
            scoreNum = scoreNum += 10;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "water")
        {
            Destroy(gameObject);
        }
    }
}
