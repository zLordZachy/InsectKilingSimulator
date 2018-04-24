
using System.Windows.Controls;

namespace InsectMurderSimulator.Objects
{
    public class Insect
    {
        public Image Image { get; set; }
        public InsectStatus Stav { get; set; }
        public int PictureStats { get; set; }
        public int FilghtToPositionTime { get; set; }
        public int DistancCounter { get; set; }

        public int FallingToPositionTime { get; set; }
        public int FallingCounter { get; set; }

        public bool MoveFront { get; set; }
        public bool MoveBack { get; set; }

        public bool MoveTop { get; set; }
        public bool MoveDown { get; set; }

        public bool MoveRight { get; set; }
        public bool MoveLeft { get; set; }


    }

    public enum InsectStatus
    {
        Alive,
        Falling,
        Dead
    }
}
