using UnityEngine;

[System.Serializable]
public class Equipment : MonoBehaviour
{
    [SerializeField] protected string itemName;

    public virtual void UseEquipment(Transform target) 
    {
        Debug.Log("Hit!");
    }
}
