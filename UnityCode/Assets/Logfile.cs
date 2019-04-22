using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logfile : MonoBehaviour


{
    

    // Start is called before the first frame update
    void Start()
    {
        WriteToFile("you suck!!!");
    }

    
    public void WriteToFile(string message)
    {
        using (System.IO.StreamWriter logFile = new System.IO.StreamWriter(@"LogFile.txt"))
        {
            logFile.WriteLine(message);
        }
           
        
    }
}
