using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject third;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().health == 2)
        {
            Destroy(third);
        }
        if (player.GetComponent<PlayerController>().health == 1)
        {
            Destroy(second);
        }
        if (player.GetComponent<PlayerController>().health == 0)
        {
            Destroy(first);
            SceneManager.LoadScene("Menu");
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
}
