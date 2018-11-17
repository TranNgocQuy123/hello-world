using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerItem : MonoBehaviour
{
	public string answerName;

	public Button btnAction;
	public Text txtContent;
	public Image image;

	public void SetContent (string content)
	{
		txtContent.text = content;
	}

	public void SetColor (Color newColor)
	{
		image.color = newColor;
	}
}
