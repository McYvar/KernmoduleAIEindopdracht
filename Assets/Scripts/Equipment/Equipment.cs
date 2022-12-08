using UnityEngine;

[System.Serializable]
public class Equipment : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected string itemName;
    [SerializeField] public Agent agent;

    public virtual void UseEquipment(Transform target) 
    {
        Debug.Log("Hit!");
        target.GetComponent<IDamageable>().TakeDamage(agent.gameObject, damage);
    }
}
