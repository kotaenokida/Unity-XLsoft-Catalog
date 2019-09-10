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
            display.text = "Long tap on a product page to jump\n to the online version of the product page.";
        }
        else
        {
            display.text = "各製品のページでロングタップすると\nそれぞれの製品のページに飛びます。";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
