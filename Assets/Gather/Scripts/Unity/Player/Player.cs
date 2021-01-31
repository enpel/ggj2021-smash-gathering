
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gather.Scripts.Domain.Data;
using Gather.Scripts.FieldObjectComponent;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Gather.Scripts.Character;
using Gather.Scripts.Unity.Basket;
using Rewired;

namespace Gather.Scripts.Player
{
    public class Player : MonoBehaviour, ICharacter

    {
    [SerializeField] private Transform _model;
    [SerializeField] private Transform _grabPoint;
    [SerializeField] private Transform _basketPoint;
    [SerializeField] private Transform _playerRingPoint;
    [SerializeField] private Collider _attackAreaTrigger;
    [SerializeField] private CharaAnimationController _animationController;

    private Rewired.Player _player;
    
    private KeyCode _attackButton = KeyCode.X;
    private KeyCode _grabButton = KeyCode.Z;
    
    private Rigidbody _rigidbody;

    private IPickableObject _currentTargetPickableObject;
    private IPickableObject _currentPickedObject;

    private List<IDestructibleObject> _targetDestructibleObjects = new List<IDestructibleObject>();
    public PlayerData PlayerData => _playerData;
    private PlayerData _playerData;

    private void Start()
    {
    }

    public void Initialize(PlayerData playerData)
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _grabPoint.OnTriggerEnterAsObservable()
            .Select(x => x.GetComponent<IPickableObject>())
            .Subscribe(x => _currentTargetPickableObject = x)
            .AddTo(this);
        _grabPoint.OnTriggerExitAsObservable()
            .Select(x => x.GetComponent<IPickableObject>())
            .Where(x => _currentTargetPickableObject == x)
            .Subscribe(x => _currentTargetPickableObject = null)
            .AddTo(this);

        _attackAreaTrigger.OnTriggerEnterAsObservable()
            .Do(x=>Debug.Log(x.name))
            .Select(x => x.GetComponent<IDestructibleObject>())
            .Where(x => x != null)
            .Subscribe(x => _targetDestructibleObjects.Add(x))
            .AddTo(this);

        _attackAreaTrigger.OnTriggerExitAsObservable()
            .Select(x => x.GetComponent<IDestructibleObject>())
            .Where(x => x != null && _targetDestructibleObjects.Contains(x))
            .Subscribe(x => _targetDestructibleObjects.Remove(x))
            .AddTo(this);

        _playerData = playerData;
        _player = Rewired.ReInput.players.GetPlayer(playerData.ID);
    }

    public void SetBasket(Basket basket)
    {
        basket.transform.SetParent(_basketPoint);
    }

    private void Update()
    {
        KeyInput();
    }

    void KeyInput()
    {
        // var x = Input.GetAxis("Horizontal");
        // var z = Input.GetAxis("Vertical");
        var x = _player.GetAxis("Move Horizontal");
        var z = _player.GetAxis("Move Vertical");
        var dir = new Vector3(x, 0, z);
        Move(dir);
        if (dir.sqrMagnitude > 0.1f)
        {
            _animationController.Run();
        }
        else
        {
            _animationController.Idle();
        }

        if (_player.GetButtonDown("Mine"))
        {
            Attack();
            _animationController.Mine();
        }
        if (_player.GetButtonDown("GrabAndThrow")|| Input.GetKeyDown(_grabButton))
        {
            GrabAction();
        }
    }

    private void CheckGrabAction()
    {
        // attack
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Grab();
        }
    }

    void GrabAction()
    {
        if (_currentPickedObject != null)
        {
            Throw();
        }
        else
        {
            Grab();
        }
    }

    public void Move(Vector3 dir)
    {
        if (Camera.main != null)
        {
            var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 dirFromCameraForward = cameraForward * dir.z + 
                                Camera.main.transform.right * dir.x;

            dir = dirFromCameraForward;
        }
        _rigidbody.velocity = dir * 5.0f + Vector3.down * 3.0f;

        if (dir.sqrMagnitude > 0.1f)
        {
            _model.rotation = Quaternion.LookRotation(dir);
        }
    }

    public void Attack()
    {
        _targetDestructibleObjects.ForEach(x => x.ApplyDamage(new AttackData(1, this._playerData)));
    }

    public void Grab()
    {
        var pickableObject = _currentTargetPickableObject?.TryPickup();
        if (pickableObject != null)
        {
            _currentPickedObject = _currentTargetPickableObject;
            _currentPickedObject.SetParent(_grabPoint);
            pickableObject.localPosition = Vector3.zero;
        }
    }

    public void Throw()
    {
        _currentPickedObject.Release(_model.forward * 20.0f);
        _currentPickedObject.SetParent(null);
        _currentPickedObject = null;
    }
    }
}