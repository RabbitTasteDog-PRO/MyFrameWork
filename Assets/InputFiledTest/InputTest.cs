using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class InputTest : MonoBehaviour
{

    public InputField inputTest00;
    public InputField inputTest11;
    public InputField inputTest22;
    public InputField inputTest33;


    void Awake()
    {
        /// Regex.Replace(word, @"[^0-9a-zA-Z가-힣]"
        /// Regex.Replace(word, @"[^0-9a-zA-Z]", ""));
        /// Regex.Replace(word, @"[ ^0-9a-zA-Z가-힣\& ]{1,10}", "", RegexOptions.Singleline)
        /// Regex.Replace(word, @"[ ^0-9a-zA-Z\`~!@#$%^&*()-_=+[]{}|;':,./<>? ]{1,10}", "")

        /// 영문, 숫자 
        inputTest00.onValueChanged.AddListener((word) => inputTest00.text = Regex.Replace(word, @"[^0-9a-zA-Z가-힣]", "")); 
        /// 영문, 숫자, 지정한 특수문자
        inputTest11.onValueChanged.AddListener((word) => inputTest11.text = Regex.Replace(word, @"[^0-9a-zA-Z`~!@#$%^&*()_,./<>?]", "")); 
        /// 숫자
        inputTest22.onValueChanged.AddListener((word) => inputTest22.text = Regex.Replace(word, @"[^0-9]", ""));  
        /// 영문 숫자 한글 지정한 특수문자 
        inputTest33.onValueChanged.AddListener((word) => inputTest33.text = Regex.Replace(word, @"[ ^0-9a-zA-Z\`~!@#$%^&*()-_=+[]{}|;':,./<>? ]{1,10}", "")); 

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
