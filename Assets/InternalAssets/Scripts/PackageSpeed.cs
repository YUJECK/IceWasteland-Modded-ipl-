using System;
using IceWasteland.Notebook;
using UnityEngine;

public class PackageSpeed : MonoBehaviour, IPickable
{
    [SerializeField] private Sprite _sprite;
    public event Action OnPickedUp;

    public void PickUp()
    {
        FindObjectOfType<Notebook>(true).PushNote(new NoteInfo("Тест", "Тест 2", _sprite));
    }
}