using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Dialogue[] dialogue;
	public string next;

	public Queue<Dialogue> dialogues;
	private bool first;

	void Start () {
		first = true;
		dialogues = new Queue<Dialogue>();
		foreach (Dialogue dial in dialogue) {
			dialogues.Enqueue(dial);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (dialogues.Count == 0)
		{
			if (first) {
				first = false;
			} else {
				EndDialogue();
			}
			return;
		}

		Dialogue dialogue = dialogues.Dequeue();
		nameText.text = dialogue.name;
		if (dialogue.name == "Arthur") {
			nameText.color = Color.white;
		} else if (dialogue.name == "Karadoc") {
			nameText.color = Color.red;
		} else {
			nameText.color = Color.blue;
		}
		StopAllCoroutines();
		StartCoroutine(TypeSentence(dialogue.sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		SceneManager.LoadScene(next);
	}

}
