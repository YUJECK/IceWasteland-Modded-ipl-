using UnityEngine;

public class NoteInfo 
{
    public string NoteText { get; private set; }
    public string NoteTitle { get; private set; }
    public Sprite NoteIcon { get; private set; }

    public NoteInfo(string noteText, string noteTitile, Sprite noteSprite)
    {
        NoteText = noteText;
        NoteTitle = noteTitile;
        NoteIcon = noteSprite;
    }
}
