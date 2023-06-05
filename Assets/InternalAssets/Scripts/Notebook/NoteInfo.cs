using UnityEngine;

namespace IceWasteland.Notebook
{
    public sealed class NoteInfo 
    {
        public string NoteText { get; private set; }
        public string NoteTitle { get; private set; }
        public Sprite NoteIcon { get; private set; }

        public NoteInfo(string noteText, string noteTitle, Sprite noteSprite)
        {
            NoteText = noteText;
            NoteTitle = noteTitle;
            NoteIcon = noteSprite;
        }
    }
}
