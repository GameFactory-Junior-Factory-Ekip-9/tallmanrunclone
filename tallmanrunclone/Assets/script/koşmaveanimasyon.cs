using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class koşmaveanimasyon : MonoBehaviour
{
    public GameObject canvascontrol;
    public GameObject kollar;
    public GameObject bacaklar;
    public float speed;
    public float çarpan;
    public float zkoordinatı;
    public bool isjumping;
    public bool isbetterjumping;
    public bool isfinishing;
    public float yspeed;
    public bool ishittedboss;
    public bool winpageopened;
   
    private void FixedUpdate()
    {
        if (!isfinishing) { 
        if (isjumping) {
            yspeed -= 0.5f * Time.fixedDeltaTime;
        yspeed = Mathf.Clamp(yspeed,-0.5f,0.5f);
        transform.Translate(0,yspeed,0); }
        if (isbetterjumping)
        {
            yspeed -= 2f * Time.fixedDeltaTime;
            yspeed = Mathf.Clamp(yspeed, -2f, 2f);
            transform.Translate(0, yspeed, 0);
        }
        #region hızayarlama
        if (!isjumping&&!isbetterjumping) {
            if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);
            speed+=7f*Time.fixedDeltaTime;
            speed = Mathf.Clamp(speed,0,7);
            zkoordinatı = +5f + ((touch.position.x - (Screen.width / 2)) * çarpan / Screen.height);
            zkoordinatı = Mathf.Clamp(zkoordinatı,-0.5f,11);
transform.position = new Vector3(transform.position.x, transform.position.y,
                   zkoordinatı);


        }
        else {
            speed -= 7f * Time.fixedDeltaTime;
            speed = Mathf.Clamp(speed, 0, 7);



        } }
        else if (isbetterjumping) { speed = 42; }
        else
        {
            speed = 7;
        }
        
        
        transform.Translate(speed*Time.fixedDeltaTime,0,0);
            #endregion
#region animasyonayarlama
            if (speed > 0&&!isjumping) {
            kollar.GetComponent<Animator>().SetBool("koşuyor",true);
            bacaklar.GetComponent<Animator>().SetBool("koşuyor",true);
            kollar.GetComponent<Animator>().SetBool("bekliyor", false);
            bacaklar.GetComponent<Animator>().SetBool("bekliyor", false);
        }
        else {
            kollar.GetComponent<Animator>().SetBool("koşuyor", false);
            bacaklar.GetComponent<Animator>().SetBool("koşuyor", false);
            kollar.GetComponent<Animator>().SetBool("bekliyor", true);
            bacaklar.GetComponent<Animator>().SetBool("bekliyor", true);
        }
            #endregion
        }
        else
        {
            if (isbetterjumping)
            {
                if (ishittedboss) {
                    speed = 0;
                    this.gameObject.transform.DOMoveY(6,2);
                    if (!winpageopened) {Invoke("openwinpage", 3); winpageopened = true; }
                }
                else { 
                    kollar.GetComponent<Animator>().SetBool("koşuyor", false);
                bacaklar.GetComponent<Animator>().SetBool("koşuyor", false);
                kollar.GetComponent<Animator>().SetBool("bekliyor", false);
                bacaklar.GetComponent<Animator>().SetBool("bekliyor", false);
                kollar.GetComponent<Animator>().SetBool("tekmeatıyor", true);
                bacaklar.GetComponent<Animator>().SetBool("tekmeatıyor", true);
            speed += 28f * Time.fixedDeltaTime;
            speed = Mathf.Clamp(speed, 0, 28);
            transform.Translate(2*speed * Time.fixedDeltaTime, 0, 0);
                yspeed -= 1f * Time.fixedDeltaTime;
                yspeed = Mathf.Clamp(yspeed, 0f, 1f);
                transform.Translate(0, yspeed*1.25f, 0); 
                }
            }
            else
            {
                speed += 14f * Time.fixedDeltaTime;
                speed = Mathf.Clamp(speed, 0, 14);
                transform.Translate(2 * speed * Time.fixedDeltaTime, 0, 0);
            }
        }
    }
    public void openwinpage() {
        canvascontrol.GetComponent<Canvascontrol>().openwinpage();
    
    
    }
}
