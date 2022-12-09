using UnityEngine;

[System.Serializable]
public class Weapon : Equipment
{
    public override void UseEquipment(Transform target)
    {
        Debug.Log("BANG");
        target.GetComponent<IDamageable>().TakeDamage(agent.gameObject, damage);
    }
}
