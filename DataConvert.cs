using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataConvert
{
	public static QuestionPackage GetData (string content)
	{
		QuestionPackage questionPackage = new QuestionPackage ();
		string[] lines = content.Split ('\n');

		for (int i = 0; i < lines.Length; i++) {

			Question question = new Question (); 

			string[] values = lines [i].Split ('|');

			if (values.Length < 6)
				continue;

			question.content = values [0];

			question.answers.Add (new Answer (values [1]));
			question.answers.Add (new Answer (values [2]));
			question.answers.Add (new Answer (values [3]));
			question.answers.Add (new Answer (values [4]));

			question.correctAnswer = values [5];

			questionPackage.questions.Add (question);
		}

		questionPackage = questionPackage;

		return questionPackage;
	}

}
