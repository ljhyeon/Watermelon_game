using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadline : MonoBehaviour
{

    int count;

    // Start is called before the first frame update
    void Start()
    {
     //   gameObject.SetActive(false);
        this.count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(count);
        if(count >= 1)
        {
            Invoke("ChangeScene", 5f);
        }
    }    

    void OnTriggerEnter2D(Collider2D other)
    {
        this.count += 1;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.count -= 1;
    }
    
    void ChangeScene()
    {
        if(count >= 1)
        {
            print("game over");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
