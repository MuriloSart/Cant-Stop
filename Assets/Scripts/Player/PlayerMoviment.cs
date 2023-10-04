using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMoviment : Singleton<PlayerMoviment>
{
    //publics
    [Header("Colisions")]
    public string tagToObstacle = "Obstacle";
    public string tagToEndLine = "EndLine";
    public GameObject endScreen;

    [Header("Power Ups")]
    public bool invencible = false;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    [Header("Moviment")]
    public float speed = 1f;

    [Header("Animation")]
    public AnimatorManager animatorManager;
    public Rigidbody myRigidBody;
    public float ScaleStartDuration = 1f;

    [SerializeField] private BounceHelper _bounceHelper;

    //privates
    private bool _canRun = false;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 1f;

    protected override void Awake()
    {
        base.Awake();
        _baseSpeedToAnimation = speed;
    }
    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
        ScaleWhenStart();
    }
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * Time.deltaTime * _currentSpeed);
    }
    public void ScaleWhenStart()
    {
        myRigidBody.transform.localScale = Vector3.zero;
        transform.DOScale(1, ScaleStartDuration).SetEase(Ease.OutBack);
    }
    public void Bounce()
    {
        myRigidBody.transform.localScale = Vector3.one;
        DOTween.Kill(myRigidBody.transform);
        if (_bounceHelper != null)
            _bounceHelper.Bounce();
    }
    private void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative();
    }
    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }
    public void StopToRun()
    {
        _canRun = false;
        animatorManager.Play(AnimatorManager.AnimationType.IDLE, 1f);
    }
    public void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType, 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToObstacle)
        {
            if(!invencible)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.DEAD);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == tagToEndLine)
        {
            EndGame();
        }
    }

    #region PowerUps
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }
    public void ChangeHeight(float amount , float durationTransition , Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, durationTransition).SetEase(ease);
    }
    public void ResetHeight(float duration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y, duration).SetEase(ease);
    }
    #endregion
}
