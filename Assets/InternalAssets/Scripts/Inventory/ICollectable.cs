using UnityEngine;

public interface IStorable
{
    Sprite Icon { get; }
    string Name { get; }

    void OnAdded();
    void OnRemoved();
    void OnInInventory();
}