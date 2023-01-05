using UnityEngine;

public sealed class MoneyAddSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffect;

    private void OnEnable() => MoneyManager.OnMoneyChanged.AddListener(PlaySoundEffect);
    private void OnDisable() => MoneyManager.OnMoneyChanged.RemoveListener(PlaySoundEffect);


    private void PlaySoundEffect(int money) => soundEffect.Play();
}