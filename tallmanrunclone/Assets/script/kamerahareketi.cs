using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class kamerahareketi : MonoBehaviour
{

    public bool takipet;
    public GameObject karakter;
    [SerializeField] float �arpanx;
    [SerializeField] float �arpany;
    private void FixedUpdate()
    {
        if (takipet) 
        { this.transform.position = new Vector3(karakter.GetComponent<stats>().uzunluk * �arpanx / 100 + 18, karakter.GetComponent<stats>().uzunluk * �arpany / 100 + 11, -karakter.transform.position.z + 5) + karakter.transform.position; }
        if (!takipet)
        {
            this.gameObject.transform.DOLocalMove(new Vector3(-100,79,0),2);


        }
    }
    
}
