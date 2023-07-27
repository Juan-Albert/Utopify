using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  Player, Hand, Deck, Card, Trait, Board, Connection, Square, Happiness, Score, Milestone, character, terrain
  
  Put Card in Square
  Compare Traits between squares with cards
  Calculate happiness in Connection
  
   
 */
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
            mousePosition.z = 10;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log(Input.mousePosition);
            Debug.Log(mouseWorldPos);
            transform.position = mouseWorldPos;
        }
    }
}
