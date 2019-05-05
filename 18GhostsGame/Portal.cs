using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Portal
    {
        public string RedPortalState { get; private set; }

        public string BluePortalState { get; private set; }

        public string YellowPortalState { get; private set; }

        public Portal()
        {
            // Portals default positions
            RedPortalState =    "up";
            BluePortalState =   "down";
            YellowPortalState = "right";
        }

        // Returns the new rotation, clockwise, of the given portal
        private string NewRotation(string portal)
        {
            string newPosition = "";
            switch (portal)
            {
                case "up":
                    newPosition = "right";
                    break;

                case "down":
                    newPosition = "left";
                    break;

                case "right":
                    newPosition = "down";
                    break;

                case "left":
                    newPosition = "up";
                    break;
            }
            return newPosition;
        }

        // Used outside of class to know what ghost died
        public void Rotate(string color)
        {
            switch (color)
            {
                case "red":
                    RedPortalState = NewRotation(RedPortalState);
                    break;
                case "blue":
                    BluePortalState = NewRotation(BluePortalState);
                    break;
                case "yellow":
                    YellowPortalState = NewRotation(YellowPortalState);
                    break;
            }
        }
    }
}
