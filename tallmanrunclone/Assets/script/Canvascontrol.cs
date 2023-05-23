using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvascontrol : MonoBehaviour
{
    [Header("objeler")]
    public GameObject winpage;
    public GameObject losepage;
    public GameObject settingspage;
    public GameObject settingsicon;
    public GameObject taptostart;


    private void Update()
    {
        
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
    }
    public void openlosepage() {
        settingsicon.SetActive(false);
        settingspage.SetActive(false);
        losepage.SetActive(true);
    }
}
