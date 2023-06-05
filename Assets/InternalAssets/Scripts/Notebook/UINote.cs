using UnityEngine;
using UnityEngine.UI;

namespace IceWasteland.Notebook
{
    public class UINote : MonoBehaviour
    {
        [SerializeField] private Text UITextNoteTitle;
        [SerializeField] private Text UITextNote;
        [SerializeField] private Image UIIcon;

        public void InitNote(NoteInfo noteInfo)
        {
            UITextNoteTitle.text = noteInfo.NoteTitle;
            UITextNote.text = noteInfo.NoteText;
            UIIcon.sprite = noteInfo.NoteIcon;
        }
    }
}
