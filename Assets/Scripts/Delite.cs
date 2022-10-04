using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delite : MonoBehaviour
{
    private Button button;
    private ProgrammManeger ProgrammManegerScript;
    public Sprite sprite1;
    public Sprite sprite2;
    // Start is called before the first frame update
    void Start()
    {

        ProgrammManegerScript = FindObjectOfType<ProgrammManeger>();
        button = GetComponent<Button>();
        
        button.onClick.AddListener(DeliteFun);
    }

    // Update is called once per frame
    void DeliteFun()
    {

        if (ProgrammManegerScript.Delite)
        {
            ProgrammManegerScript.Delite= false;
            GetComponent<Image>().sprite = sprite1;
        }
        else
        {
            ProgrammManegerScript.Delite = true;
            GetComponent<Image>().sprite =sprite2;
        }
    }
}
