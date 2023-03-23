using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPartController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.5f;

    private MeshRenderer meshRenderer;
    private new Rigidbody rigidbody;
    private new Collider collider;

    private void Awake()
    {
        meshRenderer    = GetComponent<MeshRenderer>();
        rigidbody       = GetComponent<Rigidbody>();
        collider        = GetComponent<Collider>();
    }

    // Debug Test
    private void Start()
    {
        Invoke(nameof(BreakingPart), Mathf.Abs(transform.position.y));
    }

    private void BreakingPart()
    {
        rigidbody.isKinematic   = false;
        collider.enabled        = false; // �ٸ� ������Ʈ�� �浹���� �ʵ��� ����

        Vector3 forcePoint      = transform.parent.position;
        float parentXPosition   = transform.parent.position.x;
        // �ٿ�� �ڽ��� �߽��� ���ϴ� �ڵ�
        float xPosition         = meshRenderer.bounds.center.x;
    }
}
