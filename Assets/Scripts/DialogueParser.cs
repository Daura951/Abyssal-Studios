using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueParser : MonoBehaviour
{

    public TextAsset file;
    public Text name;
    public Text dialogue;
    private int lineIndex = 0;
    private string[] lines;
    private GameObject dialogueBox;
    private bool isInteracted = false;
    private bool isFinished;
    private string strName = "";
   private  string strDialogue = "";
    private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        lines = file.text.Split('\n');
        dialogueBox = GameObject.FindGameObjectWithTag("DBOX");
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteracted)
        {
            parse();
        }

        if(Input.GetKeyDown(KeyCode.Q) && !isEnd)
        {
            name.text = "";
            dialogue.text = "";
            strDialogue = "";
            strName = "";
            lineIndex++;
            isFinished = false;
        }
    }

    void parse()
    {
        if (!isFinished)
        {
            dialogueBox.SetActive(true);
            string currentLine = lines[lineIndex];
            string[] tokens = currentLine.Split(' ');

            if (tokens[0] == "END")
            {
                dialogueBox.SetActive(false);
                isEnd = true;
            }


            int start = 0;
            bool isNameFound = false;
            for(int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                for (int j = 0; j < token.Length; j++)
                {
                    if (token[j] != ':')
                    {
                        strName += token[j];
                    }

                    else
                    {
                        isNameFound = true;
                        break;
                    }

                }

                if (isNameFound)
                    break;

                start++;

            }

            name.text = strName;
            

            for(int i = start; i < tokens.Length; i++)
            {
                string token = tokens[i];
                if(i==start)
                {
                    token = token.Substring(1);
                }

                else
                {
                    for (int j = 0; j < token.Length; j++)
                    {
                        if (token[j] != '\"')
                        {
                            strDialogue += token[j];
                        }

                        else
                        {
                            break;
                        }
                    }

                    strDialogue += ' ';
                }
            }

            dialogue.text = strDialogue;
            isFinished = true;



        }
    }

    public void setInteracted(bool newInteracted)
    {
        isInteracted = newInteracted;
    }
}
