using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class Portal
    {
        public static string RedPortalState { get; private set; }

        public static string BluePortalState { get; private set; }

        public static string YellowPortalState { get; private set; }

        static Portal()
        {
            // Portals default positions
            RedPortalState =    "up";
            BluePortalState =   "down";
            YellowPortalState = "right";
        }

        // Used outside of class to know what ghost died
        public static void Rotate(byte color)
        {
            switch (color)
            {
                case 0:
                    RedPortalState = NewRotation(RedPortalState);
                    break;
                case 1:
                    BluePortalState = NewRotation(BluePortalState);
                    break;
                case 2:
                    YellowPortalState = NewRotation(YellowPortalState);
                    break;
            }
        }

        // Returns the new rotation, clockwise, of the given portal
        private static string NewRotation(string portal)
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

        
    }
}
