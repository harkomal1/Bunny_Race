using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Bunny_Race
{
    public partial class RaceTrack : Form
    {
        Punter[] myPunter = new Punter[3];
        Bunny[] myBunny = new Bunny[4];
        Property myProperty = new Property();
        public RaceTrack()
        {
            InitializeComponent();
            TransparentBackground();
            LoadData();
        }
        private void TransparentBackground()
        {
            //Makes Backgrounds transparent for pictureboxes
            this.PointToScreen(pb1.Location);
            pb1.Parent = pbRaceTrack;
            pb1.BackColor = Color.Transparent;

            this.PointToScreen(pb2.Location);
            pb2.Parent = pbRaceTrack;
            pb2.BackColor = Color.Transparent;

            this.PointToScreen(pb3.Location);
            pb3.Parent = pbRaceTrack;
            pb3.BackColor = Color.Transparent;

            this.PointToScreen(pb4.Location);
            pb4.Parent = pbRaceTrack;
            pb4.BackColor = Color.Transparent;
        }
        private void LoadData()
        {
            PunterRadioButtons();
            BunnyPictureBoxes();
            BunnyIDCount();
        }

        private void BunnyIDCount()
        {
            // will give me how many Bunnys I have
            foreach (var id in myBunny)
            {
                if (Factory.BunnyCount < id.BunnyID)
                {
                    Factory.BunnyCount = id.BunnyID;
                    Factory.BunnyCount += 1;
                }

            }
        }

        private void BunnyPictureBoxes()
        {
            for (myProperty.Bunny = 0; myProperty.Bunny < 4; myProperty.Bunny++)
            {
                myBunny[myProperty.Bunny] = Factory.GetABunny(myProperty.Bunny);
                myBunny[myProperty.Bunny].BunnyID = myProperty.Bunny;
            }

            myBunny[0].MyPictureBox = pb1;
            myBunny[1].MyPictureBox = pb2;
            myBunny[2].MyPictureBox = pb3;
            myBunny[3].MyPictureBox = pb4;
        }

        private void PunterRadioButtons()
        {
            for (myProperty.Punter = 0; myProperty.Punter < 3; myProperty.Punter++)
            {
                myPunter[myProperty.Punter] = Factory.GetAPunter(myProperty.Punter);
                myPunter[myProperty.Punter].PunterID = myProperty.Punter;
            }

            LBLs();

            PunterNotBetYet();

            myPunter[0].MyRadioButton.Text = "Ali";
            myPunter[1].MyRadioButton.Text = "Jay";
            myPunter[2].MyRadioButton.Text = "Marry";

            panelBetting.Visible = true;
            panelBets.Visible = true;
            lblMaxBet.Visible = true;
            btnBet.Enabled = true;
        }

        private void LBLs()
        {
            myProperty.LBLAli = myProperty.NotBetYet;
            myProperty.LBLJay = myProperty.NotBetYet;
            myProperty.LBLMarry = myProperty.NotBetYet;
        }

        private void PunterNotBetYet()
        {
            myPunter[0].MyRadioButton = Ali_RadioBtn;
            lblAli.Text = myPunter[0].PunterName + myProperty.LBLAli;
            myPunter[1].MyRadioButton = Jay_RadioBtn;
            lblJay.Text = myPunter[1].PunterName + myProperty.LBLJay;
            myPunter[2].MyRadioButton = Marry_RadioBtn;
            lblMarry.Text = myPunter[2].PunterName + myProperty.LBLMarry;
        }
        private void allRB_CheckedChanged(object sender, EventArgs e)
        {
            lblMaxBet.Visible = true;
            btnBet.Enabled = true;
            // RadioButton FakeRB = new RadioButton();
            myProperty.FakeRB = (RadioButton)sender;

            if (myProperty.FakeRB.Checked)
            {

                myProperty.Punter = Convert.ToInt16(myProperty.FakeRB.Tag);
                lblBettor.Text = myPunter[myProperty.Punter].PunterName;
                Cash();
                nudBunnyNumber.Minimum = 1;
                nudBunnyNumber.Maximum = Factory.BunnyCount;
                btnBet.Text = "Place Bet for " + lblBettor.Text;// myPunter[myProperty.Punter].PunterName;

            }
            //RadioButtonsClicked(sender);
        }
  
        private void MaxCashUsed()
        {
            for (myProperty.Punter = 0; myProperty.Punter < 3; myProperty.Punter++)
            {
                if (myPunter[myProperty.Punter].MaxCash == 0)
                {
                    myPunter[myProperty.Punter].MyRadioButton.Enabled = false;
                    btnBet.Enabled = false;
                }
                else
                {
                    myPunter[myProperty.Punter].MyRadioButton.Enabled = true;
                    btnBet.Enabled = true;
                }
            }
        }

        private void Cash()
        {
            lblMaxBet.Text = myPunter[myProperty.Punter].PunterName + "'s max bet is $" + myPunter[myProperty.Punter].MaxCash;
            nudCash.Maximum = myPunter[myProperty.Punter].MaxCash;
            nudCash.Text = myPunter[myProperty.Punter].MaxCash.ToString();

            //MaxCashUsed();
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            myProperty.Punter = Convert.ToInt16(myProperty.FakeRB.Tag);
            myPunter[myProperty.Punter].AmountBet = Convert.ToInt32(nudCash.Text);
            //myPunter[myProperty.Punter].MaxCash = myPunter[myProperty.Punter].MaxCash - myPunter[myProperty.Punter].AmountBet;


            AmountBetText();
            Cash();
        }

        private void AmountBetText()
        {
            myProperty.Bunny = Convert.ToInt16(nudBunnyNumber.Text);
            myProperty.BunnyID = myProperty.Bunny - 1;
            myBunny[myProperty.BunnyID].BunnyID = myProperty.Bunny;
            myPunter[myProperty.Punter].BettorBunnyNum = myProperty.Bunny;
            if (myProperty.Punter == 0)
            {
                lblAli.Text = myPunter[0].PunterName + " has bet $" + myPunter[0].AmountBet + " on #" + (myProperty.Bunny) + " " + myBunny[myProperty.BunnyID].Name + ".";
            }
            else if (myProperty.Punter == 1)
            {
                lblJay.Text = myPunter[1].PunterName + " has bet $" + myPunter[1].AmountBet + " on #" + (myProperty.Bunny) + " " + myBunny[myProperty.BunnyID].Name + ".";

            }
            else
            {
                lblMarry.Text = myPunter[2].PunterName + " has bet $" + myPunter[2].AmountBet + " on #" + (myProperty.Bunny) + " " + myBunny[myProperty.BunnyID].Name + ".";
            }
            btnRace.Visible = true;
        }
      
        private void btnRace_Click(object sender, EventArgs e)
        {
            StartRace();
        }


        private void StartRace()
        {
            btnRace.Visible = false;
            btnBet.Visible = false;

            Factory.RaceTrackLength = RaceTrack.ActiveForm.Width - pb1.Width - (pb1.Width / 2);
            while (
                pb1.Location.X < Factory.RaceTrackLength &&
                pb2.Location.X < Factory.RaceTrackLength &&
                pb3.Location.X < Factory.RaceTrackLength &&
                pb4.Location.X < Factory.RaceTrackLength
                )
            //do
            {

                for (myProperty.Bunny = 0; myProperty.Bunny < Factory.BunnyCount; myProperty.Bunny++)
                {
                    myBunny[myProperty.Bunny].Run();
                    //Application.DoEvents();
                    Thread.Sleep(1);
                    if (myBunny[myProperty.Bunny].MyPictureBox.Location.X >= Factory.RaceTrackLength)
                    {
                        myProperty.BunnyRaceNum = myProperty.Bunny + 1;
                        myProperty.BunnyID = myProperty.Bunny;

                        lblWinner.Text = "Winner is Bunny #" + myProperty.BunnyRaceNum + " Name: " + myBunny[myProperty.BunnyID].Name;
                        btnNewRace.Visible = true;

                        IsWinner();
                    }
                }

            };
        }
        private void IsWinner()
        {
            for (myProperty.Punter = 0; myProperty.Punter < 3; myProperty.Punter++)
            {
                if (myPunter[myProperty.Punter].BettorBunnyNum == myProperty.BunnyRaceNum)
                {
                    myPunter[myProperty.Punter].MaxCash += myPunter[myProperty.Punter].AmountBet;
                    btnBet.Enabled = true;
                }
                else
                {
                    myPunter[myProperty.Punter].MaxCash -= myPunter[myProperty.Punter].AmountBet;
                    if (myPunter[myProperty.Punter].MaxCash == 0)
                    {
                        if (myPunter[0].MaxCash == 0)
                        {
                            myProperty.LBLAli = myProperty.Busted;
                            lblAli.Text = myPunter[0].PunterName + myProperty.LBLAli;
                            lblAli.ForeColor = Color.Red;
                            lblMaxBet.Text = myPunter[0].PunterName + "'s max bet is $" + myPunter[0].MaxCash;
                        }
                        if (myPunter[1].MaxCash == 0)
                        {
                            myProperty.LBLJay = myProperty.Busted;
                            lblJay.Text = myPunter[1].PunterName + myProperty.LBLJay;
                            lblJay.ForeColor = Color.Red;
                            lblMaxBet.Text = myPunter[1].PunterName + "'s max bet is $" + myPunter[1].MaxCash;
                        }
                        if (myPunter[2].MaxCash == 0)
                        {
                            myProperty.LBLMarry = myProperty.Busted;
                            lblMarry.Text = myPunter[2].PunterName + myProperty.LBLMarry;
                            lblMarry.ForeColor = Color.Red;
                            lblMaxBet.Text = myPunter[2].PunterName + "'s max bet is $" + myPunter[2].MaxCash;
                        }
                        RestartRace();


                        myPunter[myProperty.Punter].MyRadioButton.Enabled = false;
                        btnBet.Enabled = false;
                    }
                }
            }
        }

        private void RestartRace()
        {
            if (myProperty.LBLAli == " you have run out of Cash! BUSTED!" && myProperty.LBLJay == " you have run out of Cash! BUSTED!" && myProperty.LBLMarry == " you have run out of Cash! BUSTED!")
            {
                btnNewRace.Visible = false;
                btnRestart.Visible = true;
            }
        }


        private void btnNewRace_Click(object sender, EventArgs e)
        {//Moves all the Bunnys back to their starting positions

            StartingPostition();
            //LoadData();
            PunterNotBetYet();

            btnBet.Visible = true;

            btnNewRace.Visible = false;
            lblWinner.Text = "";
        }

        private void StartingPostition()
        {
            for (myProperty.Bunny = 0; myProperty.Bunny < Factory.BunnyCount; myProperty.Bunny++)
            {
                myBunny[myProperty.Bunny].StartingPostition();
            }
            myProperty.Bunny = 0;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartingPostition();

            for (myProperty.Punter = 0; myProperty.Punter < 3; myProperty.Punter++)
            {
                myPunter[myProperty.Punter].MyRadioButton.Enabled = true;
                //btnBet.Enabled = false;

            }
            panelBets.Visible = false;
            panelBetting.Visible = false;
            lblMaxBet.Visible = false;
            btnRestart.Visible = false;
            btnBet.Visible = true;
            lblWinner.Text = "";

            lblAli.ForeColor = Color.Black;
            lblJay.ForeColor = Color.Black;
            lblMarry.ForeColor = Color.Black;

            LoadData();
        }
    }
}
