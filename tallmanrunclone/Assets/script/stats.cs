using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public GameObject canvascontrol;
    public float uzunluk;
    public float geniþlik;
    public float elmassayýsý;
    public float sonuzunluk;
    public float songeniþlik;
    bool isfinished;
    public float çarpan;
    
    private void Update()
    {
        if (uzunluk < 45||geniþlik<=0)
        {
            if (this.gameObject.GetComponent<koþmaveanimasyon>().isfinishing == true){Invoke("kazanmaekranýaçma",3);}
            else { Invoke("kaybetmeekranýaçma", 3); }
                if (!isfinished)
            {
                isfinished = true;
                this.gameObject.GetComponent<scalevepositionayarlama>().kollar.SetActive(false);
                this.gameObject.GetComponent<scalevepositionayarlama>().bacaklar.SetActive(false);
                this.gameObject.GetComponent<scalevepositionayarlama>().vücut.SetActive(false);
                this.gameObject.GetComponent<scalevepositionayarlama>().kafa.AddComponent<Rigidbody>();
                this.gameObject.GetComponent<scalevepositionayarlama>().kafa.GetComponent<Rigidbody>().AddForce(-1000, 100, Random.Range(-1000, 1000));
                this.gameObject.GetComponent<scalevepositionayarlama>().kafa.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<scalevepositionayarlama>().enabled = false;
                this.gameObject.GetComponent<koþmaveanimasyon>().enabled = false;
            } 
            

           
        }

    }
    private void FixedUpdate()
    {
        
            float deðiþmehýzý = 3*(sonuzunluk - uzunluk);
        if(deðiþmehýzý<0.5f&& deðiþmehýzý > -0.5f) { uzunluk = sonuzunluk; }
           else if (deðiþmehýzý < 3&& deðiþmehýzý >0) { deðiþmehýzý = 3; }
            else if (deðiþmehýzý > -3 && deðiþmehýzý < 0) { deðiþmehýzý = -3; }
            uzunluk = uzunluk+deðiþmehýzý*Time.fixedDeltaTime;
        float geniþlikdeðiþmehýzý = 3 * (songeniþlik - geniþlik);
        if (geniþlikdeðiþmehýzý < 0.5f && geniþlikdeðiþmehýzý > -0.5f) { geniþlik = songeniþlik; }
        else if (geniþlikdeðiþmehýzý < 3 && geniþlikdeðiþmehýzý > 0) { geniþlikdeðiþmehýzý = 3; }
        else if (geniþlikdeðiþmehýzý > -3 && geniþlikdeðiþmehýzý < 0) { geniþlikdeðiþmehýzý = -3; }
        geniþlik = geniþlik + geniþlikdeðiþmehýzý * Time.fixedDeltaTime;


    }
    void kazanmaekranýaçma() { canvascontrol.GetComponent<Canvascontrol>().openwinpage(); }
    void kaybetmeekranýaçma() { canvascontrol.GetComponent<Canvascontrol>().openlosepage(); }
}
