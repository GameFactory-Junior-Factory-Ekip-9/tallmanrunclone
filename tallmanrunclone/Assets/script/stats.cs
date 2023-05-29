using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public GameObject canvascontrol;
    public float uzunluk;
    public float geni�lik;
    public float elmassay�s�;
    public float sonuzunluk;
    public float songeni�lik;
    bool isfinished;
    public float �arpan;
    
    private void Update()
    {
        if (uzunluk < 45||geni�lik<=0)
        {
            if (this.gameObject.GetComponent<ko�maveanimasyon>().isfinishing == true){Invoke("kazanmaekran�a�ma",3);}
            else { Invoke("kaybetmeekran�a�ma", 3); }
                if (!isfinished)
            {
                isfinished = true;
                this.gameObject.GetComponent<scalevepositionayarlama>().kollar.SetActive(false);
                this.gameObject.GetComponent<scalevepositionayarlama>().bacaklar.SetActive(false);
                this.gameObject.GetComponent<scalevepositionayarlama>().v�cut.SetActive(false);
                this.gameObject.GetComponent<scalevepositionayarlama>().kafa.AddComponent<Rigidbody>();
                this.gameObject.GetComponent<scalevepositionayarlama>().kafa.GetComponent<Rigidbody>().AddForce(-1000, 100, Random.Range(-1000, 1000));
                this.gameObject.GetComponent<scalevepositionayarlama>().kafa.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<scalevepositionayarlama>().enabled = false;
                this.gameObject.GetComponent<ko�maveanimasyon>().enabled = false;
            } 
            

           
        }

    }
    private void FixedUpdate()
    {
        
            float de�i�meh�z� = 3*(sonuzunluk - uzunluk);
        if(de�i�meh�z�<0.5f&& de�i�meh�z� > -0.5f) { uzunluk = sonuzunluk; }
           else if (de�i�meh�z� < 3&& de�i�meh�z� >0) { de�i�meh�z� = 3; }
            else if (de�i�meh�z� > -3 && de�i�meh�z� < 0) { de�i�meh�z� = -3; }
            uzunluk = uzunluk+de�i�meh�z�*Time.fixedDeltaTime;
        float geni�likde�i�meh�z� = 3 * (songeni�lik - geni�lik);
        if (geni�likde�i�meh�z� < 0.5f && geni�likde�i�meh�z� > -0.5f) { geni�lik = songeni�lik; }
        else if (geni�likde�i�meh�z� < 3 && geni�likde�i�meh�z� > 0) { geni�likde�i�meh�z� = 3; }
        else if (geni�likde�i�meh�z� > -3 && geni�likde�i�meh�z� < 0) { geni�likde�i�meh�z� = -3; }
        geni�lik = geni�lik + geni�likde�i�meh�z� * Time.fixedDeltaTime;


    }
    void kazanmaekran�a�ma() { canvascontrol.GetComponent<Canvascontrol>().openwinpage(); }
    void kaybetmeekran�a�ma() { canvascontrol.GetComponent<Canvascontrol>().openlosepage(); }
}
