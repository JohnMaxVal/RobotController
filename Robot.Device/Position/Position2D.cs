using System;
using System.Collections.Generic;
using System.Text;
using Robot.ControlPanel.InputParameters;

namespace Robot.Device.Position
{
    /// <summary>
    /// Position of <see cref="IMachine"/> instance
    /// </summary>
    public class Position2D
    {
        /// <summary>
        /// X coordinate of <see cref="IMachine"/> instance
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of <see cref="IMachine"/> instance
        /// </summary>
        public int Y { get; set; }

        public Direction Direction { get; set; }

        protected Position2D head;

        protected Position2D next;

        protected Position2D prev;

        /// <summary>
        /// Pointer to the last position
        /// </summary>
        internal Position2D Last => head.prev;

        /// <summary>
        /// Construct instance of <see cref="Position2D"/>
        /// </summary>
        public Position2D()
        {
            InsertPositionToEmptyHead();
        }

        /// <summary>
        /// Add new <see cref="Position2D"/> instance to list
        /// </summary>
        /// <param name="newPosition"></param>
        public void Add(Position2D newPosition)
        {
            InsertBefore(newPosition);
        }

        protected void InsertBefore(Position2D newPosition)
        {
            newPosition.next = head;
            newPosition.prev = head.prev;
            head.prev.next = newPosition;
            head.prev = newPosition;
        }

        protected void InsertPositionToEmptyHead()
        {
            this.next = this;
            this.prev = this;
            head = this;
        }
    }
}
