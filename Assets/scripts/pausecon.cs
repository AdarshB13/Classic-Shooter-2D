using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausecon : MonoBehaviour
{
    [SerializeField]
    GameObject button1,button2,button4,button3,result,Robot;
    Button resume,reswave,restart,exit;
    shootercon robconscript;

    void Start()
    {
        gameObject.SetActive(false);
        resume=button1.GetComponent<Button>();
        reswave=button2.GetComponent<Button>();
        restart=button3.GetComponent<Button>();
        exit=button4.GetComponent<Button>();
        resume.onClick.AddListener(resumeg);
        reswave.onClick.AddListener(waveshift);
        result.SetActive(false);
        exit.onClick.AddListener(retmmm);
        restart.onClick.AddListener(restartg);
    }

    void resumeg()
    {
        Time.timeScale=1;
        gameObject.SetActive(false);
    }

    public void Result()
    {
        result.SetActive(true);
        result.GetComponent<TMPro.TextMeshProUGUI>().text="YOU LOSE";
        button1.SetActive(false);
        Time.timeScale=0;
    }

    void lose()
    {
        result.SetActive(true);
        result.GetComponent<TMPro.TextMeshProUGUI>().text="CONGRATULATIONS";
        button1.SetActive(false);
        Time.timeScale=0;
    }

    void waveshift()
    {
        robconscript=Robot.GetComponent<shootercon>();
        robconscript.wave();
        resumeg();
    }

    void retmmm()
    {
        SceneManager.LoadScene("Title");
    }

    void restartg()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
