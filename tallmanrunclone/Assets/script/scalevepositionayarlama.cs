using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalevepositionayarlama : MonoBehaviour
{
    public GameObject[] kol;
    public GameObject[] bacak;
    public GameObject vücut;
    public GameObject kollar;
    public GameObject bacaklar;
    public GameObject kafa;
    public GameObject kollider;
    
    private void Start()
    {
        bacak = GameObject.FindGameObjectsWithTag("bacak");
        kol = GameObject.FindGameObjectsWithTag("kol");
    }
    private void Update()
    {
        #region geniþletme
        for (int i = 0; i < kol.Length; i++)
        {
kol[i].transform.localScale=new Vector3(this.gameObject.GetComponent<stats>().geniþlik/100, 1, this.gameObject.GetComponent<stats>().geniþlik / 100);
        }
        for (int i = 0; i < bacak.Length; i++)
        {
            bacak[i].transform.localScale = new Vector3(this.gameObject.GetComponent<stats>().geniþlik / 100, this.gameObject.GetComponent<stats>().geniþlik / 100, 1);
        }
        
        #endregion
        #region uzunluk
        vücut.transform.localScale=new Vector3(this.gameObject.GetComponent<stats>().geniþlik / 100, this.gameObject.GetComponent<stats>().uzunluk / 100, this.gameObject.GetComponent<stats>().geniþlik / 100);
        vücut.transform.localPosition =new Vector3(0, this.gameObject.GetComponent<stats>().uzunluk / 100 - 1,0);
        kollar.transform.localPosition = new Vector3(0, 4*(this.gameObject.GetComponent<stats>().uzunluk / 100 - 1), 0);
        kafa.transform.localPosition = new Vector3(0, 4 * (this.gameObject.GetComponent<stats>().uzunluk / 100 - 1)+4, 0);
        kollider.transform.localPosition = new Vector3(0,2* this.gameObject.GetComponent<stats>().uzunluk / 100 - 2.5f, 0);
        kollider.transform.GetComponent<CapsuleCollider>().height =10+3.5f* this.gameObject.GetComponent<stats>().uzunluk / 100;
        #endregion
    }
}
