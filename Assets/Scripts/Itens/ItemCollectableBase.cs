using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("Referenciais")]
    public ParticleSystem particles;
    public GameObject item;

    [Header("Configurações")]
    public float timeToHide = 4f;
    public string compareTag = "Player";
    private bool _collectVerification;

    private void Awake()
    {
        _collectVerification = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if (_collectVerification == false)
        {
            if (item != null) item.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
            _collectVerification = true;
        }
    }
    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect()
    {
        if (particles != null) particles.Play();
    }
}
