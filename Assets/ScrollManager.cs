using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] GameObject scroll_text;
    [SerializeField] GameObject scroll_content;
    void Start()
    {
        for(int i=0; i<10; i++)
        {
            var txt = Instantiate(scroll_text, scroll_content.transform);
            txt.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
        }
    }

    void Update()
    {
        
    }
}
