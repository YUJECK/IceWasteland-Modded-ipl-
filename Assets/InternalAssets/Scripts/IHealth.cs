using UnityEngine.Events;

public interface IHealth
{
    public int MaximumHealth { get; }
    public int CurrentHealth { get; }

    public UnityEvent<int, int> OnHealthChanged { get; }
    public UnityEvent<int, int> OnTookHit { get; }
    public UnityEvent<int, int> OnHealed { get; }

    void DecreaseMaximumHealth(int addHealth); 
    void IncreaseMaximumHealth(int removeHealth); 
    void ApplyDamage(int damage);
    void Heal(int heal);
}