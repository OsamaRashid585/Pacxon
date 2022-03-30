using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    public Text timer;
    public Text lifeTXT;
    public static int life = 3;
    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        lifeTXT.text = "Life: " + life.ToString();
        if(life <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Timer()
    {
        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                yield return new WaitForSeconds(1);
                timer.text = "Timer: " + j.ToString();
            }
        }
    }
}
