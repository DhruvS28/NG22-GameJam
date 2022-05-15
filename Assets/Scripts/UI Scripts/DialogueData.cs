using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Data", menuName = "Create a Dialogue")]
public class DialogueData : ScriptableObject
{
    public string[] dialogueLines;

    public int[] actorsIndices;
}