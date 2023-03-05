using UnityEngine;

namespace IceWasteland.Player
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer();
        void CreateHUD();
    }
}