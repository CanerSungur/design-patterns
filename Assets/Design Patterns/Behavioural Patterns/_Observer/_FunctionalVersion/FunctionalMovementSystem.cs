using System;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class FunctionalMovementSystem : MonoBehaviour
    {
        // Subject

        public static event Action OnMoveForward, OnMoveBack, OnMoveLeft, OnMoveRight;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                OnMoveForward?.Invoke();
            if (Input.GetKeyDown(KeyCode.S))
                OnMoveBack?.Invoke();
            if (Input.GetKeyDown(KeyCode.A))
                OnMoveLeft?.Invoke();
            if (Input.GetKeyDown(KeyCode.D))
                OnMoveRight?.Invoke();
        }
    }
}
