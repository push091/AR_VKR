using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    private Button button;
    private ProgrammManeger ProgrammManegerScript;
    // Start is called before the first frame update
    void Start()
    {
        ProgrammManegerScript = FindObjectOfType<ProgrammManeger>();
        button = GetComponent<Button>();
        button.onClick.AddListener(RotationFun);
    }

    // Update is called once per frame
    void RotationFun()
    {
        if (ProgrammManegerScript.Rotation)
        {
            ProgrammManegerScript.Rotation = false;
            GetComponent<Image>().sprite = sprite1;
        }
        else
        {
            ProgrammManegerScript.Rotation = true;
            GetComponent<Image>().sprite = sprite2;
        }
    }
}
