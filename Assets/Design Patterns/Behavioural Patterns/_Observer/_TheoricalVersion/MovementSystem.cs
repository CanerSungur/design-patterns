using UnityEngine;

namespace DesignPatterns.Observer
{
    public class MovementSystem : Subject
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                ForwardOnClick();
            if (Input.GetKeyDown(KeyCode.S))
                BackOnClick();
            if (Input.GetKeyDown(KeyCode.A))
                LeftOnClick();
            if (Input.GetKeyDown(KeyCode.D))
                RightOnClick();
        }

        public void ForwardOnClick()
        {
            Notify(NotificationType.ForwardButton);
        }
        public void BackOnClick()
        {
            Notify(NotificationType.BackButton);
        }
        public void LeftOnClick()
        {
            Notify(NotificationType.LeftButton);
        }
        public void RightOnClick()
        {
            Notify(NotificationType.RightButton);
        }
    }
}
