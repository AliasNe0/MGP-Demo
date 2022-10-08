using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblePopper
{
    public class GameBall : MonoBehaviour
    {
        private BallType _ballType;
        public BallType BallType => _ballType;
        private Dictionary<string, BallType> _ballNameToType;
        public bool ScoreAdded;
        public bool Checked;
        
        public List<GameObject> touchingObjects;
        
        private void Awake()
        {
            touchingObjects = new List<GameObject>();

            _ballNameToType = new Dictionary<string, BallType>
            {
                { "Blue", BallType.Blue }, { "Green", BallType.Green }, { "Red", BallType.Red }, { "Yellow", BallType.Yellow }
            };
        }

        void Start()
        {
            foreach(string color in _ballNameToType.Keys)
            {
                if(gameObject.name.StartsWith(color))
                {
                    _ballType = _ballNameToType[color];
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameBall collisionGameBall = collision.gameObject.GetComponent<GameBall>();

            if (collisionGameBall != null && collisionGameBall.BallType == _ballType)
            {
                touchingObjects.Add(collision.gameObject);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            GameBall collisionGameBall = other.gameObject.GetComponent<GameBall>();

            if (collisionGameBall != null && touchingObjects.Contains(other.gameObject))
            {
                touchingObjects.Remove(other.gameObject);
            }
        }

        public void TouchedBall()
        {
            for (int i = 0; i < touchingObjects.Count; i++)
            {
                Destroy(touchingObjects[i]);
            }
            Destroy(gameObject);
        }

        // private void OnCollisionEnter(Collision collision)
        // {
        //     GameBall collisionGameBall = collision.gameObject.GetComponent<GameBall>();
        //
        //     if(collisionGameBall != null && collisionGameBall.BallType == BallType)
        //     {
        //         if(CheckIfScoreHasBeenAdded(collisionGameBall))
        //         {
        //             BubblePopperManager.Instance.AddScore();
        //         }
        //
        //         collisionGameBall.ScoreAdded = true;
        //         ScoreAdded = true;
        //
        //         Destroy(collisionGameBall.gameObject);
        //         Destroy(gameObject);
        //     }
        // }

        private bool CheckIfScoreHasBeenAdded(GameBall collisionGameBall)
        {
            return !ScoreAdded && !collisionGameBall.ScoreAdded;
        }
    }
}