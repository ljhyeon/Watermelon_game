using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    public GameObject score;

    public int total_score;

    // Start is called before the first frame update
    void Start()
    {
      //  this.total_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // print(total_score);
        this.score.GetComponent<Text>().text = total_score.ToString("F0");
        
    }
}
