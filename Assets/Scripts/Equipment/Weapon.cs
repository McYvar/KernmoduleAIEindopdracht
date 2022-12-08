using UnityEngine;

[System.Serializable]
public class Weapon : Equipment
{
    [SerializeField] protected int damage;
    [SerializeField] protected int range;

    public override void UseEquipment(Transform target)
    {
        Debug.Log("BANG");
    }
}
