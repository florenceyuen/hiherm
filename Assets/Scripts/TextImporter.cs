using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextImporter4 : MonoBehaviour
{
    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    // public PlayerController player;

    void Start()
    {
        // player = findObjectOfType<PlayerController>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n')); // grab text file and split into separate for each new line
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    void Update()
    {

        theText.text = textLines[currentLine];

       /* if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentLine += 1;
            }
        } */

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }
    }
}