using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ScanButton : MonoBehaviour
{
    public GameObject scanBeamSpawn;

    public void ScanPressed()
    {
        {
            scanBeamSpawn.SetActive(true);
        } 
    }
    
    //public void ScanReleased()
   // {
    //    {
    //        scanBeamSpawn.SetActive(false);
    //    }
   // }
}
