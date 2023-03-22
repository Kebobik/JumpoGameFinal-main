using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
	[SerializeField] Text codeText;
	string codeTextValue = "";

	void Update()
	{
		codeText.text = codeTextValue;

		if (codeTextValue == "3824")
		{
			PlayerMovement.isSafeOpened = true;
		}
		if (codeTextValue.Length >= 4)
		codeTextValue = "";
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}
