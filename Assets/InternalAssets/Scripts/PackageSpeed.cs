﻿using IceWasteland.Player;
using System;
using UnityEngine;

public class PackageSpeed : MonoBehaviour, IPickable
{
    public event Action OnPickedUp;

    public void PickUp()
    {
        FindObjectOfType<PlayerMovable>().MoveSpeed += 2;
        Destroy(gameObject);
    }
}