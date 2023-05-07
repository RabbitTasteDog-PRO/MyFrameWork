using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

public class BuildDisplayer : MonoBehaviour
{

    public Text textVersion;
    public string BuildNumber = "1.0.0";

    // Start is called before the first frame update
    void Start()
    {
        textVersion.text = Application.version.ToString();
    }

   
   
}
