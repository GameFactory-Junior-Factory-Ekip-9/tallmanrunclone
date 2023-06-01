using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvascontrol : MonoBehaviour
{ 
    public float toplananelmassayýsý;
    [Header("objeler")]
    public GameObject winpage;
    public GameObject losepage;
    public GameObject settingspage;
    public GameObject settingsicon;
    public GameObject taptostart;
    public GameObject elmastext;
    public GameObject karakter;
    public GameObject winpageelmassayýsý;
    private void Start()
    {
        if (PlayerPrefs.HasKey("elmassayýsý")) {karakter.GetComponent<stats>().elmassayýsý =PlayerPrefs.GetFloat("elmassayýsý"); }
        
    }
    private void Update()
    {
        elmastext.GetComponent<TextMeshProUGUI>().text =karakter.GetComponent<stats>().elmassayýsý.ToString("0");
        if (Input.touchCount > 0)
        {
            taptostart.SetActive(false);

        }
    }
    public void opensettings()
    {
        settingsicon.SetActive(false);
        settingspage.SetActive(true);
    }
    public void closesettings()
    {
        settingsicon.SetActive(true);
        settingspage.SetActive(false);
    }
    public void openwinpage() {
        settingsicon.SetActive(false);
        settingspage.SetActive(false);
        winpage.SetActive(true);
        karakter.GetComponent<stats>().elmassayýsý += toplananelmassayýsý * karakter.GetComponent<stats>().çarpan;
        winpageelmassayýsý.GetComponent<TextMeshProUGUI>().text = ":"+(toplananelmassayýsý* karakter.GetComponent<stats>().çarpan).ToString("0");
        PlayerPrefs.SetFloat("elmassayýsý", karakter.GetComponent<stats>().elmassayýsý);
    }
    public void openlosepage() {
        settingsicon.SetActive(false);
        settingspage.SetActive(false);
        losepage.SetActive(true);
    }
    public void nextlevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
