using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public GameObject canvascontrol;
    public float uzunluk;
    public float genişlik;
    public float elmassayısı;
    public float sonuzunluk;
    public float songenişlik;
    bool isfinished;
    public float çarpan;
    public bool winpageopened;

    private void Update()
    {
        
        if (uzunluk < 45||genişlik<=0)
        {
            if (this.gameObject.GetComponent<koşmaveanimasyon>().isfinishing == true){


                if (!winpageopened) {Invoke("kazanmaekranıaçma",3); winpageopened = true; }
                
            }
            else { Invoke("kaybetmeekranıaçma", 3); }
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
                this.gameObject.GetComponent<koşmaveanimasyon>().enabled = false;
            } 
            

           
        }

    }
    private void FixedUpdate()
    {
        
            float değişmehızı = 3*(sonuzunluk - uzunluk);
        if(değişmehızı<0.5f&& değişmehızı > -0.5f) { uzunluk = sonuzunluk; }
           else if (değişmehızı < 3&& değişmehızı >0) { değişmehızı = 3; }
            else if (değişmehızı > -3 && değişmehızı < 0) { değişmehızı = -3; }
            uzunluk = uzunluk+değişmehızı*Time.fixedDeltaTime;
        float genişlikdeğişmehızı = 3 * (songenişlik - genişlik);
        if (genişlikdeğişmehızı < 0.5f && genişlikdeğişmehızı > -0.5f) { genişlik = songenişlik; }
        else if (genişlikdeğişmehızı < 3 && genişlikdeğişmehızı > 0) { genişlikdeğişmehızı = 3; }
        else if (genişlikdeğişmehızı > -3 && genişlikdeğişmehızı < 0) { genişlikdeğişmehızı = -3; }
        genişlik = genişlik + genişlikdeğişmehızı * Time.fixedDeltaTime;


    }
    void kazanmaekranıaçma() { canvascontrol.GetComponent<Canvascontrol>().openwinpage(); }
    void kaybetmeekranıaçma() { canvascontrol.GetComponent<Canvascontrol>().openlosepage(); }
}
