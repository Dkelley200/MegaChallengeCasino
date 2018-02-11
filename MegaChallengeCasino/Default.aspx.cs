using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string[] reels = new string[] { spinReels(), spinReels(), spinReels() };
                showImages(reels);
               ViewState.Add("PlayerMoney",100);
                displayBalance();
             
            }
        }

        public void pullButton_Click(object sender, EventArgs e)
        {
            int bet = 0;
            displayWarningBet();
            if (!int.TryParse(yourBetTextBox.Text, out bet)) return;
            int winnings = imageSet(bet);
            showSpinValue(bet, winnings);
            adjustMoney(bet,winnings);
        }

        private void displayWarningBet()
        {
            if (yourBetTextBox.Text == "")
            { placeBetWarningLabel.Text = ("You must place a bet before pulling the lever"); }
            else  { placeBetWarningLabel.Text = "";
                };
        }

        private void showSpinValue(int bet, int winnings)
        {
            if (winnings > 0)
            {
                winningsLabel.Text = string.Format(" you bet {0:C} and won {1:C}!", bet, winnings);
            }
            else
            {
                winningsLabel.Text = string.Format("Sorry you lost {0:C}. Better Luck new time.", bet);
            }


        }

        private int imageSet(int bet)
        {
        
            string[] reels = new string[] { spinReels(), spinReels(), spinReels() };
            showImages(reels);
            int multiplier = spin(reels);
            return multiplier * bet;

        }

        private void showImages(string[] reels)
        {
            Image1.ImageUrl = "/Images/" + reels[0] + ".png";
            Image2.ImageUrl = "/Images/" + reels[1] + ".png";
            Image3.ImageUrl = "/Images/" + reels[2] + ".png";
        }




        private string spinReels()
        {
            string[] images = new string[] { "Strawberry", "Bar", "Lemon", "Bell", "Clover", "Cherry", "Diamond", "Orange", "Seven", "HorseShoe", "Plum", "Watermellon" };

            return images[random.Next(11)];
        }


        private int spin(string[] reels)
        {
            if (hasBar(reels)) return 0;
            if (hasJackpot(reels)) return 100;
            //cherryWins
            int multiplier = 0;
            if (cherryWins(reels, out multiplier)) return multiplier;


            return 0;
        }

        private bool hasBar(string[] reels)
        {
            if ((reels[0] == "Bar") || (reels[1] == "Bar") || (reels[2] == "Bar")) return true;
            return false;
        }

        private bool hasJackpot(string[] reels)
        {
            if ((reels[0] == "Seven" && reels[1] == "Seven" && reels[2] == "Seven")) return true;
            return false;
        }

        private int cherryCount(string[] reels)
        {
            //count number of cherries in the spin
            int cherry = 0;
            if (reels[0] == "Cherry") cherry++;
            if (reels[1] == "Cherry") cherry++;
            if (reels[2] == "Cherry") cherry++;
            return cherry;
        }

        private int cherryCountMultiplier(string[] reels)
        {
            //add multiplier Value to cherry spins
            int cherry = cherryCount(reels);
            if (cherry == 1) return 2;
            if (cherry == 2) return 3;
            if (cherry == 3) return 4;
            return 0;
        }

        private bool cherryWins(string[] reels, out int multiplier)
        {
          
            // calculate cherry count = multiplier
            multiplier = cherryCountMultiplier(reels);

            if (multiplier > 0) return true;
            return false;
        }

        ////display players money
        private void displayBalance()
        {
            resultLabel.Text = string.Format("Player's Money:  {0:C}", ViewState["PlayerMoney"]);
        }

        //adjust players money (bet, money
        private void adjustMoney(int bet, int winnings)
        {
            int playerMoney = int.Parse(ViewState["PlayerMoney"].ToString());
            playerMoney -= bet;
            playerMoney += winnings;
            ViewState["PlayerMoney"]= playerMoney;
        }

      

       

    }
}