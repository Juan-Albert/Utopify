using System;
using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class PlayerView : MonoBehaviour
    {
        private bool _cardGrabbed;
        private PlayerInput _playerInput;
        private HandView _handView;
        private CardView _cardToPlay;
        private Player _player;

        private void Awake()
        {
            _playerInput = gameObject.AddComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _playerInput.OnClickDown += CheckCardGrab;
            _playerInput.OnDrag += CheckCardDrag;
            _playerInput.OnClickUp += CheckCardDrop;
        }

        private void OnDisable()
        {
            _playerInput.OnClickDown -= CheckCardGrab;
            _playerInput.OnDrag -= CheckCardDrag;
            _playerInput.OnClickUp -= CheckCardDrop;
        }

        public void Setup(Player player, HandView handView)
        {
            _player = player;
            _handView = handView;

            _playerInput.EnableInput(true);
        }

        private void CheckCardGrab(Vector3 mousePos)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            mousePos.z = Camera.main.nearClipPlane;
            if (Physics.Raycast(cameraPos, Camera.main.ScreenToWorldPoint(mousePos) - cameraPos, out RaycastHit cardHit,
                    Mathf.Infinity, LayerMask.GetMask("Card")))
            {
                _cardToPlay = cardHit.collider.GetComponent<CardView>();
                _cardGrabbed = true;
            }
        }

        private void CheckCardDrag(Vector3 mousePos)
        {
            if (_cardGrabbed)
            {
                mousePos.z = 5;
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
                int cardMoveSpeed = 25;
                var cardPos = _cardToPlay.transform.position;
                cardPos = Vector3.Lerp(cardPos,
                    new Vector3(mouseWorldPos.x, mouseWorldPos.y, mouseWorldPos.z), Time.deltaTime * cardMoveSpeed);
                _cardToPlay.transform.position = cardPos;

                Vector3 direction = mousePos - cardPos;
                _cardToPlay.transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(cardPos+direction, -_cardToPlay.transform.forward),Time.deltaTime/10f);
            }
        }

        private void CheckCardDrop(Vector3 mousePos)
        {
            if (!_cardGrabbed) 
                return;
            
            Vector3 cameraPos = Camera.main.transform.position;

            mousePos.z = Camera.main.nearClipPlane;

            if (Physics.Raycast(cameraPos, Camera.main.ScreenToWorldPoint(mousePos) - cameraPos, out RaycastHit hit,
                    Mathf.Infinity, LayerMask.GetMask("Square")))
            {
                SquareView currentSquare = hit.collider.GetComponent<SquareView>();

                if (currentSquare.HasCard)
                {
                    _handView.ReturnCard(_cardToPlay);
                }
                else
                {
                    PutCard(_cardToPlay, currentSquare);
                }
            }
            else
            {
                _handView.ReturnCard(_cardToPlay);
            }

            _cardToPlay = null;
            _cardGrabbed = false;
        }

        private void PutCard(CardView cardToPlay, SquareView squareView)
        {
            _player.PlayCard(cardToPlay.Card, squareView.Square.Coordinate);
            _handView.DropCard(_cardToPlay);
            squareView.PutCard(cardToPlay);
        }
    }
}