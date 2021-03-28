using System.Windows.Forms;

namespace Bunny_Race
{
    public class Property
    {
        public string NotBetYet { get; set; } = " has not placed a bet.";
        public string Busted { get; set; } = " you have run out of Cash! BUSTED!";
        public string LBLAli { get; set; } = "";
        public string LBLJay { get; set; } = "";
        public string LBLMarry { get; set; } = "";
        public RadioButton FakeRB { get; set; } = new RadioButton();

        public bool isWinner { get; set; } = false;

        public int Bunny { get; set; }
        public int BunnyID { get; set; }
        public int Punter { get; set; }

        public int BunnyRaceNum { get; set; }

    }
}
