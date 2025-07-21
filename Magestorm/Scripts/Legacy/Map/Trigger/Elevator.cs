namespace Magestorm.Legacy.Map.Trigger
{
    [System.Serializable]
    public class Elevator : Trigger
    {
        /// <summary>
        /// Height of floor when OFF
        /// </summary>
        public int off_height;

        /// <summary>
        /// Height of floor when ON
        /// </summary>
        public int on_height;

        /// <summary>
        /// Upper left corner of elevator
        /// </summary>
        public int x1;
        public int y1;
        public int x2;
        public int y2;

        /// <summary>
        /// Speed of elevator in Height units per second
        /// </summary>
        public int speed;

        public bool move_floor;

        /// <summary>
        /// Move ceiling with floor?
        /// </summary>
        public bool move_ceiling;

        /// <summary>
        /// Move rooftop with floor?
        /// </summary>
        public bool move_roof;

        /// <summary>
        /// Move rooftop with floor?
        /// </summary>
        public bool move_rooftop;

        public int on_sound;
        public int off_sound;
    }
}