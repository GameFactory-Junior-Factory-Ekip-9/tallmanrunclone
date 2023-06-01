using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvascontrol : MonoBehaviour
{ 
    public float toplananelmassay�s�;
    [Header("objeler")]
    public GameObject winpage;
    public GameObject losepage;
    public GameObject settingspage;
    public GameObject settingsicon;
    public GameObject taptostart;
    public GameObject elmastext;
    public GameObject karakter;
    public GameObject winpageelmassay�s�;
    private void Start()
    {
        if (PlayerPrefs.HasKey("elmassay�s�")) {karakter.GetComponent<stats>().elmassay�s� =PlayerPrefs.GetFloat("elmassay�s�"); }
        
    }
    private void Update()
    {
        elmastext.GetComponent<TextMeshProUGUI>().text =karakter.GetComponent<stats>().elmassay�s�.ToString("0");
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
        karakter.GetComponent<stats>().elmassay�s� += toplananelmassay�s� * karakter.GetComponent<stats>().�arpan;
        winpageelmassay�s�.GetComponent<TextMeshProUGUI>().text = ":"+(toplananelmassay�s�* karakter.GetComponent<stats>().�arpan).ToString("0");
        PlayerPrefs.SetFloat("elmassay�s�", karakter.GetComponent<stats>().elmassay�s�);
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
