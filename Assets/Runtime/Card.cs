using UnityEngine;

/*
  Player, Hand, Deck, Card, Trait, Board, Connection, Square, Happiness, Milestone, Character, Terrain
  
  Build Board
  Build Deck
  Draw Cards
  Put Card in Square
  Compare Traits between squares with cards
  Calculate happiness in Connection
  Calculate total happiness
  
 */

namespace Runtime
{
    public class Card : MonoBehaviour
    {
        private bool _grabbed;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast (ray, out var hit, 100))
                {
                    _grabbed = true;
                }
            }
            else if(_grabbed && Input.GetMouseButtonUp(0))
            {
                _grabbed = false;
            }

            if (_grabbed)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 5;
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = mouseWorldPos;
            }
        }
    }
}
