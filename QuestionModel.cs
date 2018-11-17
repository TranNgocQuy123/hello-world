using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionPackage
{
	public List<Question> questions = new List<Question> ();
}

[System.Serializable]
public class Question
{

	public string content;
	public string correctAnswer;
	public List<Answer> answers = new List<Answer> ();
}

[System.Serializable]
public class Answer
{
	public string content;

	public Answer (string content)
	{
		this.content = content;
	}
}

