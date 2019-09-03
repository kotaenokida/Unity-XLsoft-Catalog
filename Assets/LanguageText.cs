using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{

    public Text display = null;
    // Start is called before the first frame update
    void Start()
    {

        if (Application.systemLanguage == SystemLanguage.English)
        {
            display.text = "Long Tap on XLsoft logo \nto find more information!";
        }
        else
        {
            display.text = "XLsoftロゴをロングタップして\n詳細を確認してください！";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
