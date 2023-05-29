using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class collidertrigger : MonoBehaviour
{
    public GameObject kamera;
    public GameObject canvascontrol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jumper")
        {
            
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isjumping = true;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().yspeed=0.5f;



        }
        if (other.gameObject.tag == "betterjumper")
        {

            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isbetterjumping = true;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().yspeed = 2f;



        }
        if (other.gameObject.tag == "ground")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isbetterjumping = false;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isjumping = false;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().yspeed = 0;



        }
        if (other.gameObject.tag == "elmas")
        {
            other.gameObject.GetComponent<elmas>().yokoluyor = true;
            canvascontrol.gameObject.GetComponent<Canvascontrol>().toplananelmassayýsý++;

        }
        if (other.gameObject.tag == "Finish")
        {
            kamera.transform.parent =this.gameObject.transform.parent.transform;
            kamera.GetComponent<kamerahareketi>().takipet = false;
            this.gameObject.transform.parent.gameObject.transform.position = new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x, this.gameObject.transform.parent.gameObject.transform.position.y,5);
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isbetterjumping = false;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isjumping = false;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().yspeed = 0;
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().isfinishing = true;


        }
        if (other.gameObject.tag == "barrier")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-200, 50f, Random.Range(-50f,50f));
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            if (this.gameObject.transform.parent.gameObject.GetComponent<stats>().songeniþlik >= 50) {this.gameObject.transform.parent.gameObject.GetComponent<stats>().songeniþlik-=5; }
            else { this.gameObject.transform.parent.gameObject.GetComponent<stats>().sonuzunluk -= 15; }


        }
        if (other.gameObject.tag == "longbarrier")
        {
           
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-100, 50f,-50);
            other.gameObject.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(-100, 50f,50f);
            other.gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.transform.GetChild(1).GetComponent<Rigidbody>().useGravity = true;


            if (this.gameObject.transform.parent.gameObject.GetComponent<stats>().songeniþlik >= 50) { this.gameObject.transform.parent.gameObject.GetComponent<stats>().songeniþlik -= 10; }
            else { this.gameObject.transform.parent.gameObject.GetComponent<stats>().sonuzunluk -= 30; }
        }
        if (other.gameObject.tag == "boss")
        {
            other.gameObject.GetComponent<Animator>().SetBool("dead",true);
            this.gameObject.transform.parent.gameObject.GetComponent<koþmaveanimasyon>().ishittedboss = true;


        }
        if (other.gameObject.tag == "çarpan") { this.gameObject.transform.parent.gameObject.GetComponent<stats>().çarpan+=0.2f; }
    }
}
