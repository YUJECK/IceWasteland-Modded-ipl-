using System.Collections.Generic;
using UnityEngine;

namespace IceWasteland.Notebook
{
    public class Notebook : MonoBehaviour
    {
        [SerializeField] private List<UINote> notes = new();
        [SerializeField] private UINote notePrefab;

        public void PushNote(NoteInfo newNote)
        {
            var newNotePosition = new Vector3(notes[notes.Count].transform.position.x, notes[notes.Count].transform.position.y+1, 0f);
            var newNoteUI = Instantiate(notePrefab, newNotePosition, Quaternion.identity, transform);
            
            newNoteUI.InitNote(newNote);
        }
    }
}
