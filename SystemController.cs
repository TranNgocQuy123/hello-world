using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SystemController : MonoBehaviour
{

	public QuestionController question;
	public QuestionPackage questionData;

	//	int questionIndex;

	void Start ()
	{
		// RestAPI.Instance.Get(APIConfig.DEMO, DataHandler);
//		RestAPI.Instance.Get (APIConfig.MOCK, DataHandler);

		TextAsset textAsset = Resources.Load<TextAsset> ("TOP");
		GetDemo (DataConvert.GetData (textAsset.text));
	}

	void GetDemo (QuestionPackage questionPackage)
	{
		question.SetData (questionPackage);
		question.SetQuestion (0);


		questionData = questionPackage;
	}

	void DataHandler (string json)
	{
		Debug.Log (json);
		QuestionPackage q = JsonUtility.FromJson<QuestionPackage> (json);
		question.SetData (q);
		question.SetQuestion (0);

		questionData = q;
	}

	// Test Save json
	[ContextMenu ("save Json")]
	public void SaveJson ()
	{
		string json = JsonUtility.ToJson (questionData);
		File.WriteAllText (Application.dataPath + "/package1.json", json);
	}
}

