using System;

public interface ISellable
{
    int Cost { get; }

    void OnSold();
}