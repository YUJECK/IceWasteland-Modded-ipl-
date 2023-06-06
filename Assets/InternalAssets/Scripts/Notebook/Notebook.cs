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
            var newNotePosition = new Vector3(notes[notes.Count-1].transform.position.x, notes[notes.Count-1].transform.position.y-80, 0f);
            var newNoteUI = Instantiate(notePrefab, newNotePosition, Quaternion.identity, transform);
            notes.Add(newNoteUI);
            
            newNoteUI.InitNote(newNote);
        }
        public void SetActive()
            => gameObject.SetActive(!gameObject.activeSelf);
    }
}
