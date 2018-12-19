using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxManger : MonoBehaviour
{
    public Text dialogOnScreen;

    public GameObject gameManger;
    public Animator animator;

    private Queue<string> sentance;
    // Use this for initialization
    void Start()
    {
        sentance = new Queue<string>();
    }

    public void StartDialog(Dialog dialogs)
    {
        sentance.Clear();
        animator.SetBool("IsOpen", true);
        foreach(var dialog in dialogs.Dialogue)
        {
            sentance.Enqueue(dialog);
        }
        NextDialog();
    }

    public void NextDialog()
    {
        if(sentance.Count == 0 )
        {
            EndDialog();
            return;
        }
        string sen = sentance.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sen));
    }

    IEnumerator TypeSentence(string sen)
    {
        dialogOnScreen.text = "";
        foreach(var letter in sen.ToCharArray())
        {
            dialogOnScreen.text += letter;
            yield return null;
        }
    }

    private void EndDialog()
    {
        //Start Game
        animator.SetBool("IsOpen", false);
        gameManger.GetComponent<GameManger>().StartGame();
    }
}
