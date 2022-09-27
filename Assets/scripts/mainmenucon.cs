using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenucon : MonoBehaviour
{
    [SerializeField]
    GameObject button1,button2;
    Button start,exit;
    AudioSource bgmusic;

    void Start()
    {
        start=button1.GetComponent<Button>();
        exit=button2.GetComponent<Button>();
        start.onClick.AddListener(firstscene);
        exit.onClick.AddListener(quit);
        bgmusic=GetComponent<AudioSource>();
        bgmusic.PlayDelayed(3);
    }

    void firstscene()
    {
        SceneManager.LoadScene("FirstScene");
    }

    void quit()
    {
        Application.Quit();
    }
}
