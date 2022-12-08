using UnityEngine;

[System.Serializable]
public class Weapon : Equipment
{
    [SerializeField] private int range;

    public override void UseEquipment(Transform target)
    {
        Debug.Log("BANG");
        target.GetComponent<IDamageable>().TakeDamage(agent.gameObject, damage);
    }
}
