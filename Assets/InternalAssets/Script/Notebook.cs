using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    [SerializeField] private List<UINote> notes = new();
    [SerializeField] private UINote notePrefab;

    public void PushNote(NoteInfo newNote)
    {
        Vector3 newNotePosition = new Vector3(notes[notes.Count].transform.position.x, notes[notes.Count].transform.position.y+1, 0f);
        UINote newNoteUI = Instantiate(notePrefab, newNotePosition, Quaternion.identity, transform);
        
        newNoteUI.InitNote(newNote);
    }
}