using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elmas : MonoBehaviour
{
   float elapsedTime = 0;
   public Color ilkrenk;
   public  Color sonrenk;
   public  bool yokoluyor;

   
    
    private void Start()
    {
        ilkrenk = this.GetComponent<MeshRenderer>().material.color;
        sonrenk = new Color(ilkrenk.r, ilkrenk.g, ilkrenk.b, 0);
    }

    private void FixedUpdate()
    {
        if (yokoluyor) {
        if (elapsedTime < 1)
        {
                transform.Translate(0,1*Time.fixedDeltaTime,0);
            transform.GetComponent<Renderer>().material.color = Color.Lerp(ilkrenk, sonrenk, elapsedTime);
            elapsedTime += Time.fixedDeltaTime;
            
        }
         }
        
    }
    
        
    
}
