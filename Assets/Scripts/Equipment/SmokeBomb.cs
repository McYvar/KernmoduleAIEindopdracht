using System.Collections;
using UnityEngine;

[System.Serializable]
public class SmokeBomb : Equipment
{
    [SerializeField] private int radius;
    [SerializeField] private float throwingStrenghtVert;
    [SerializeField] private float throwingStrenghtHor;
    [SerializeField] private float popTime;
    [SerializeField] private float destroyTime;

    public override void UseEquipment(Transform target)
    {
        Debug.Log("Throwing smoke bomb!");

        GameObject smoke = Instantiate(this, agent.transform.position + Vector3.up * 2, Quaternion.identity).gameObject;

        Rigidbody rb = smoke.GetComponent<Rigidbody>();

        rb.useGravity = true;
        rb.velocity = (target.position - smoke.transform.position) * throwingStrenghtHor + Vector3.up * throwingStrenghtVert;

        StartCoroutine(poppingSmoke(smoke));
    }

    private IEnumerator poppingSmoke(GameObject _smoke)
    {
        yield return new WaitForSeconds(popTime);

        _smoke.GetComponent<MeshRenderer>().enabled = true;

        _smoke.transform.localScale = Vector3.one * radius;

        yield return new WaitForSeconds(destroyTime);
        Destroy(_smoke);
    }
}