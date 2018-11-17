using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionController : MonoBehaviour
{
    public QuestionPackage data;

    public int index;
    public string content;
    public string correctAnswer;
    //	public AnswerController answer;
    public AnswerItem[] answerItems;

    [Header("Color")]
    public Color SelectedColor;
    public Color CorrectColor;

    [Header("View")]
    public Text txtContent;

    public void SetData(QuestionPackage questionPackage)
    {
        data = questionPackage;
    }

    public void SetQuestion(int index)
    {
        UpdateCurrentQuestion(data.questions[index]);
    }

    public void Next()
    {
        ++index;
        if (index >= data.questions.Count)
            return;

        for (int i = 0; i < answerItems.Length; i++)
        {
            answerItems[i].btnAction.interactable = true;
        }

        UpdateCurrentQuestion(data.questions[index]);
    }

    void UpdateCurrentQuestion(Question question)
    {
        //		content = "<b> Câu " + (index + 1) + " </b>: " + question.content;
        content = "" + question.content;
        correctAnswer = question.correctAnswer;

        txtContent.text = content;

        for (int i = 0; i < answerItems.Length; i++)
        {

            int index = i;
            answerItems[index].SetContent("<b>" + answerItems[index].answerName + "</b>: " + question.answers[index].content);
            answerItems[index].SetColor(Color.white);

            answerItems[index].btnAction.onClick.RemoveAllListeners();
            answerItems[index].btnAction.onClick.AddListener(() =>
            {
                StartCoroutine(IEOnClickAnswer(answerItems[index]));
                //				Debug.Log (answerItems [index].answerName);
            });
        }
    }

    IEnumerator IEOnClickAnswer(AnswerItem answerItem)
    {
        int indexCorrectAnswer = ConvertAnswerNameToId(correctAnswer);
        answerItem.SetColor(SelectedColor);

        for (int i = 0; i < answerItems.Length; i++)
        {
            answerItems[i].btnAction.interactable = false;
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 7; i++)
        {
            if (i % 2 == 0)
                answerItems[indexCorrectAnswer].SetColor(CorrectColor);
            else
                answerItems[indexCorrectAnswer].SetColor(Color.white);

            yield return new WaitForSeconds(0.5f);
        }

        if (ConvertAnswerNameToId(answerItem.answerName) != indexCorrectAnswer)
        {
            yield break;
        }

        yield return new WaitForSeconds(2);

        Next();
    }

    int ConvertAnswerNameToId(string name)
    {
        if (name.Contains("A"))
            return 0;

        if (name.Contains("B"))
            return 1;

        if (name.Contains("C"))

            return 2;

        if (name.Contains("D"))
            return 3;

        return 0;
    }
}
