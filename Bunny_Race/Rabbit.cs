using System.Windows.Forms;

namespace Bunny_Race
{

    public abstract class Bunny
    {
        public int BunnyID { get; set; }
        public string Name { get; set; }
        public PictureBox MyPictureBox { get; set; }

        private int newDistance = 76;


        public void UpdatePostition()
        {
            //moves the picture box to new postion
            MyPictureBox.Left = newDistance;
        }
        public void StartingPostition()
        {
            // new distance of the Bunny
            newDistance = 76;
            // current location
            var location = MyPictureBox.Location;
            // changes the current location to new location
            location.X = newDistance;
            //moves the picture box
            MyPictureBox.Location = location;
            //updates the postion
            UpdatePostition();
        }
        public void Run()
        {
            //new distance + random move of 1, 2, 3, or 4 spaces
            newDistance += Factory.Number();
            //updates the postion
            UpdatePostition();
        }
    }

    class Bunny01 : Bunny
    {
        public Bunny01()
        {
            BunnyID = 1;
            Name = "Bola";
        }
    }

    class Bunny02 : Bunny
    {

        public Bunny02()
        {
            BunnyID = 2;
            Name = "Bunty";
        }
    }

    class Bunny03 : Bunny
    {
        public Bunny03()
        {
            BunnyID = 3;
            Name = "Kato";
        }
    }

    class Bunny04 : Bunny
    {
        public Bunny04()
        {
            BunnyID = 4;
            Name = "Sona";
        }
    }
}
