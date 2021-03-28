using System.Windows.Forms;

namespace Bunny_Race
{
    public abstract class Punter
    {
        public int PunterID { get; set; }
        public string PunterName { get; set; }
        public int MaxCash { get; set; }
        public int AmountBet { get; set; }
        public int BettorBunnyNum { get; set; }

        public RadioButton MyRadioButton { get; set; }
    }
}
