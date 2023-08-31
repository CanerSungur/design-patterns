using UnityEngine;

namespace DesignPatterns.Observer
{
    public class FunctionalMovement : MonoBehaviour
    {
        // Observer

        private void OnEnable()
        {
            FunctionalMovementSystem.OnMoveForward += MoveForward;
            FunctionalMovementSystem.OnMoveBack += MoveBack;
            FunctionalMovementSystem.OnMoveLeft += MoveLeft;
            FunctionalMovementSystem.OnMoveRight += MoveRight;
        }

        private void OnDisable()
        {
            FunctionalMovementSystem.OnMoveForward -= MoveForward;
            FunctionalMovementSystem.OnMoveBack -= MoveBack;
            FunctionalMovementSystem.OnMoveLeft -= MoveLeft;
            FunctionalMovementSystem.OnMoveRight -= MoveRight;
        }

        private void MoveForward() => transform.Translate(Vector3.forward);
        private void MoveBack() => transform.Translate(Vector3.back);
        private void MoveLeft() => transform.Translate(Vector3.left);
        private void MoveRight() => transform.Translate(Vector3.right);
    }
}
