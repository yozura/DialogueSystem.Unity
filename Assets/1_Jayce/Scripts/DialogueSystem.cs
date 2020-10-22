﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;

    Queue<string> sentences = new Queue<string>();

    public Animator anim;

    public void Begin(Dialogue info)
    {
        anim.SetBool("IsOpen", true);
        sentences.Clear();

        txtName.text = info.name;

        foreach(var sentence in info.sentences)
            sentences.Enqueue(sentence);

        Next();
    }

    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void End()
    {
        txtSentence.text = string.Empty;
        anim.SetBool("IsOpen", false);
        Debug.Log("End");
    }
}
