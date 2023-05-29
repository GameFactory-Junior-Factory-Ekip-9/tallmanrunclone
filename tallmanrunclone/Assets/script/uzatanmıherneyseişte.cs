using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class uzatanmıherneyseişte : MonoBehaviour
{
    public int type;//1:uzatan 2:kalınlaştıran 
    public int işlem;//1:toplama 2:çıkarma 3:çarpma 4:bölme
    public int işlemyapacaksayı;
    public GameObject text;
    private void Start()
    {
        switch (işlem)
        {
            case 1:
                text.GetComponent<TextMeshProUGUI>().text ="+"+işlemyapacaksayı.ToString();
                break;
            case 2:
                text.GetComponent<TextMeshProUGUI>().text = "-" + işlemyapacaksayı.ToString();
                break;
            case 3:
                text.GetComponent<TextMeshProUGUI>().text = "x" + işlemyapacaksayı.ToString();
                break;
            case 4:
                text.GetComponent<TextMeshProUGUI>().text = "÷" + işlemyapacaksayı.ToString();
                break;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.transform.DOMove(this.gameObject.transform.position+new Vector3(0,-5,0),0.5f);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            switch (işlem)
            {

                case 1:
                    if (type == 1) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().sonuzunluk+=işlemyapacaksayı; }        
                    if (type == 2) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().songenişlik += işlemyapacaksayı; }
                        break;
                case 2:
                    if (type == 1) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().sonuzunluk -= işlemyapacaksayı; }
                    if (type == 2) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().songenişlik -= işlemyapacaksayı; }
                    break;
                case 3:
                    if (type == 1) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().sonuzunluk *= işlemyapacaksayı; }
                    if (type == 2) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().songenişlik *= işlemyapacaksayı; }
                    break;
                case 4:
                    if (type == 1) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().sonuzunluk /= işlemyapacaksayı; }
                    if (type == 2) { other.gameObject.transform.parent.gameObject.GetComponent<stats>().songenişlik /= işlemyapacaksayı; }
                    break;
            }





        }
    }
}
