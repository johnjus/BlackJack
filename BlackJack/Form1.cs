using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//add the ability to split cards with same value done????????

/*To Do List:
 * add ability for user to choose between 1 or 10 on ace
 * [COMPLETE] add overlapp image if the player or dealer takes another card besides two
 * add application overlay alerts if player wins, bust or hits black jack
 * [COMPLETE} look into adding the images to be a part of the Card object
 * rebuild image overlay system for ui to handle a split oppurtunity on players side
 */

namespace BlackJack
{
    public partial class Form1 : Form
    {
        //og deck of cards created at the beginning of app to be used. We do not want to alter the contents of this object array
        private List<Card> playingCards = new List<Card>();

        //this is a "copy" of the og deck, but is used to have the shuffling ability. This can be altered in anyway we want to shuffle card objects within it
        private List<Card> shufflingDeck = new List<Card>();

        //this will hold the cards that have been dealt during play. Its main purpose is to store those dealt cards for a period of time until the shuffling deck hits 75% capacity. At which point we will use this deck and shufflingdeck to create a new unique playable deck for the application
        private List<Card> usedCards = new List<Card>();

        //object arrray to hold the players current cards. Needed to keep track of what cards the player has during a current hand and to count their value for calculations on whether they beat the dealer
        private PlayersCards playersCards = new PlayersCards();

        //object array to hold the dealers current cards. needed to keep track of what cards the player has during a current hand and to count their value for calculations on whether they beat the player
        private DealersCards dealersCards = new DealersCards();

        //needed to store the created picture boxes of cards hit by player so I can remove them from ui when a new hand is dealt
        private List<PictureBox> hitCards = new List<PictureBox>();
        
        //needed to store the created picture boxes of cards hit by dealer so I can remove them from ui when a new hand is dealt
        private List<PictureBox> hitCardsByDealer = new List<PictureBox>();
        
        //x & y points for where new imagebox should be placed for players card
        private int newCardPointXForPlayersHitCard;
        private int newCardPointYForPlayersHitCard;

        //x & y points for where new imagebox should be place for dealers card
        private int newCardPointXForDealersHitCard;
        private int newCardPointYForDealersHitCard;
        


        private List<PlayersCards> playersSplitHand = new List<PlayersCards>();
        /* 2 means cards are not split. Play cards together as one hand
         * 0 or 1 indicates that cards have been split
         * 0 means play the 1st card dealt until player stands
         * 1 means play the 2nd card dealt until player stands
         */
        private int splitCardsIndicator = 2;

        public Form1()
        {
            InitializeComponent();
            BuildPlayingCardsDeckArray();
            buildShufflingDeckArray();
            MainShuffling();
            HideUIElements();
        }
        //UI function to elimanate buttons on opening screen
        public void HideUIElements()
        {
            this.hitBt.Hide();
            this.standbt.Hide();
            this.splitbt.Hide();
            this.highLightCard1.Hide();
            this.hightLightCard2.Hide(); 
            this.playersHitCardIB.Hide();
            this.dealersHitCardIB.Hide();
        }
        //UI fucntions to show buttons when they are needed to be used
        public void ShowButtons()
        {
            this.hitBt.Show();
            this.standbt.Show();
        }
        public void ShowSplitButton()
        {
            this.splitbt.Show();
        }

        public void GetCoordinatesforHitCardPictureBox()
        {
            //players default hit card image box location
            this.newCardPointXForPlayersHitCard = this.playersHitCardIB.Location.X;
            this.newCardPointYForPlayersHitCard = this.playersHitCardIB.Location.Y;

            //dealers default hit card image box location
            this.newCardPointXForDealersHitCard = this.dealersHitCardIB.Location.X;
            this.newCardPointYForDealersHitCard = this.dealersHitCardIB.Location.Y;
    }



 //---------------------Code below builds the two Card object arrays----------------------
        //needed to build are og array of cards objects to be used later down the road in code
        public void BuildPlayingCardsDeckArray()
        {
            int count = 0;
            while (count != 4)
            {
                for (int i = 1; i < 11; i++)
                {
                    if (count == 0)//spade
                    {
                        if (i == 1)
                        {
                            playingCards.Add(new Card("Ace", "Spades", 1, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Spades\\Ace.png"));
                            playingCards.Add(new Card("King", "Spades", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Spades\\King.png"));
                            playingCards.Add(new Card("Queen", "Spades", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Spades\\Queen.png"));
                            playingCards.Add(new Card(("Jack"), "Spades", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Spades\\Jack.png"));
                        }
                        else
                        {
                            playingCards.Add(new Card(i.ToString(), "Spades", i, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Spades\\" + i.ToString() + ".png"));
                        }
                    }
                    else if (count == 1)//clubs
                    {
                        if (i == 1)
                        {
                            playingCards.Add(new Card("Ace", "Clubs", 1, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Clubs\\Ace.png"));
                            playingCards.Add(new Card("King", "Clubs", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Clubs\\King.png"));
                            playingCards.Add(new Card("Jack", "Clubs", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Clubs\\Jack.png"));
                            playingCards.Add(new Card(("Queen"), "Clubs", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Clubs\\Queen.png"));
                        }
                        else
                        {
                            playingCards.Add(new Card(i.ToString(), "Clubs", i, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Clubs\\" + i.ToString() + ".png"));
                        }
                    }
                    else if (count == 2)//hearts
                    {
                        if (i == 1)
                        {
                            playingCards.Add(new Card("Jack", "Hearts", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Hearts\\Jack.png"));
                            playingCards.Add(new Card("Ace", "Hearts", 1, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Hearts\\Ace.png"));
                            playingCards.Add(new Card("King", "Hearts", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Hearts\\King.png"));
                            playingCards.Add(new Card(("Queen"), "Hearts", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Hearts\\Queen.png"));
                        }
                        else
                        {
                            playingCards.Add(new Card(i.ToString(), "Hearts", i, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Hearts\\" + i.ToString() + ".png"));
                        }
                    }
                    else if (count == 3)//Diamond
                    {
                        if (i == 1)
                        {
                            playingCards.Add(new Card("Queen", "Diamonds", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Diamonds\\Queen.png"));
                            playingCards.Add(new Card("King", "Diamonds", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Diamonds\\King.png"));
                            playingCards.Add(new Card("Jack", "Diamonds", 10, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Diamonds\\Jack.png"));
                            playingCards.Add(new Card(("Ace"), "Diamonds", 1, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Diamonds\\Ace.png"));
                        }
                        else
                        {
                            playingCards.Add(new Card(i.ToString(), "Diamonds", i, "C:\\Users\\justi\\Desktop\\playindDeckCards\\Diamonds\\" + i.ToString() + ".png"));
                        }
                    }
                }
                count += 1;
            }
        }


        //builds a un-tethered copy of the of playingcards object array of card object so that we can use it to shuffle those objects within it
        public void buildShufflingDeckArray()
        {
            foreach(Card card in playingCards)
            {
                shufflingDeck.Add(card);
            }
        }
//----------------------------------------------------------------------------------------

//------------------------Code below is used for shuffling object array of Cards--------
        //Shuffles cards after a certain amount of cards have been played to keep the application from running out caards, and to revamp the order of playable cards
        public void MidGameShufflingCards()
        {
            if(usedCards.Count() >= 21)
            {
                
                Console.WriteLine("---------------------Mid game shuffling activated----------------");
                shufflingDeck.AddRange(usedCards);
                usedCards.Clear();
                MainShuffling();
                /*
                foreach (Card card in shufflingDeck)
                {
                    Console.WriteLine(card.getCardFace() + " " + card.getCardSuit());
                }
                Console.WriteLine("------------------------------------------------------------------");
                */
            }
        }
        //add random input of how many times to shuffle cards when application opens up
        private void MainShuffling()
        {
            int i = 0;
            while (i != 10)
            {
                i++;
                List<Card> firstHalf = new List<Card>(); // contains card 0 - 25
                List<Card> secondHalf = new List<Card>();// contains card 26- 51
                //populating split decks
                for (int j  = 0; j <= 25; j++)
                {
                    firstHalf.Add(shufflingDeck[j]);
                }
                for (int j = 26; j <= 51; j++)
                {
                    secondHalf.Add(shufflingDeck[j]);
                }
                //clear holding deck
                shufflingDeck.Clear();
                //reverse second deck to increase splitting
                //secondHalf.Reverse();

                //add split decks back into holding deck
                for (int j = 0; j <= 25; j++)
                {
                    shufflingDeck.Add(secondHalf[j]);
                    shufflingDeck.Add(firstHalf[j]);
                }
                firstHalf.Clear();
                secondHalf.Clear();
            }
        }
//--------------------------------------------------------------------------------------

        //add code to alert on app
        private void playerBusted()
        {
            if (splitCardsIndicator == 0)
            {
                if (playersSplitHand[0].getTotalValue() > 21)
                {
                    Console.WriteLine("Players 1st Split Hand Busted");
                    
                    playersSplitHand[0].resetCards();
                    //Console.WriteLine(playersCards.getTotalValue());
                    this.highLightCard1.Hide();
                    this.hightLightCard2.Show();
                    splitCardsIndicator = 1;
                }
            }
            else if (splitCardsIndicator == 1)
            {
                if (playersSplitHand[1].getTotalValue() > 21)
                {
                    Console.WriteLine("Players 1st Split Hand Busted");
                    playersSplitHand[1].resetCards();
                    
                    //Console.WriteLine(playersCards.getTotalValue());
                    HideUIElements();

                }

            }
            else if (splitCardsIndicator == 2)
            {
                if (playersCards.getTotalValue() > 21)
                {
                    this.playerHandValueLB.BackColor = Color.Red;
                    MessageBox.Show("Player busted with " + playersCards.getTotalValue());
                    Console.WriteLine("Player Busted");
                    
                    clearHands();
                    
                    Console.WriteLine(playersCards.getTotalValue());
                    HideUIElements();
                }
            }
        }
 
        //this is garbage!!!!!!!!!!
        private void dealerChecksCards()
        {
            int dealershandvalue = dealersCards.getTotalValue();
            while (dealershandvalue < 17)
            {
                dealersCards.addCard(shufflingDeck[0]);
                CreateNewCardBoxImage(1);
                Console.WriteLine("Dealer hit with : " + shufflingDeck[0].getCardFace() + " of " + shufflingDeck[0].getCardSuit());
                dealershandvalue = dealersCards.getTotalValue();
                Console.WriteLine(dealershandvalue);
                usedCards.Add(shufflingDeck[0]);
                shufflingDeck.RemoveAt(0);
            }

            if (dealershandvalue > 21)
            {
                Console.WriteLine("Dealer Busts with: " + dealershandvalue + "   Player wins");
                MessageBox.Show("Dealer busts with " + dealershandvalue + " Player Wins!");
                clearHands();
                playersSplitHand.Clear();
            }
            else if (dealershandvalue == 21 && dealersCards.getDealersCards().Count() == 2)
            {
                Console.WriteLine("Dealer hits Black Jack " + dealershandvalue);
                MessageBox.Show("Dealer hit Black Jack " + dealershandvalue);
                clearHands();
                playersSplitHand.Clear();
            }
            else if (splitCardsIndicator != 2)
            {
                int firsHandOfPlayer = playersSplitHand[0].getTotalValue();
                int secHandOfPlayer = playersSplitHand[1].getTotalValue();
                if (firsHandOfPlayer == 0)
                {
                    //play second hand against dealer
                    if (dealershandvalue == secHandOfPlayer)
                    {
                        Console.WriteLine("Push! On players hand two");
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue > secHandOfPlayer)
                    {
                        Console.WriteLine("Dealer wins!" + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + secHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue < secHandOfPlayer)
                    {
                        Console.WriteLine("Player Wins " + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + secHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                }
                else if (secHandOfPlayer == 0)
                {
                    //play first hand against dealer
                    if (dealershandvalue == firsHandOfPlayer)
                    {
                        Console.WriteLine("Push! On players hand one");
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue > firsHandOfPlayer)
                    {
                        Console.WriteLine("Dealer wins!" + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + firsHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue < firsHandOfPlayer)
                    {
                        Console.WriteLine("Player Wins " + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + firsHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                }
                else if (firsHandOfPlayer !=0 && secHandOfPlayer !=0)
                {
                    //play both hands against dealer
                    if (dealershandvalue == firsHandOfPlayer)
                    {
                        Console.WriteLine("Push! On players hand one");
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue > firsHandOfPlayer)
                    {
                        Console.WriteLine("Dealer wins!" + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + firsHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue < firsHandOfPlayer)
                    {
                        Console.WriteLine("Player Wins " + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + firsHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }

                    if (dealershandvalue == secHandOfPlayer)
                    {
                        Console.WriteLine("Push! On players hand two");
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue > secHandOfPlayer)
                    {
                        Console.WriteLine("Dealer wins!" + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + secHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                    else if (dealershandvalue < secHandOfPlayer)
                    {
                        Console.WriteLine("Player Wins " + "Dealers Hand: " + dealershandvalue + " Players second Hand: " + secHandOfPlayer);
                        clearHands();
                        playersSplitHand.Clear();
                    }
                }
            }
            else if (splitCardsIndicator == 2)
            {
                
                int playersHandValue = playersCards.getTotalValue();

                if (dealershandvalue == playersHandValue)
                {
                    Console.WriteLine("Push! Dealers hand value: " + dealershandvalue + " & Players hand value: " + playersHandValue);
                    clearHands();
                }
                else if(dealershandvalue > playersHandValue)
                {
                    Console.WriteLine("Dealer Wins " + dealershandvalue);
                    MessageBox.Show("Dealer Wins " + dealershandvalue);
                    clearHands();
                }
                else if(dealershandvalue < playersHandValue)
                {
                    Console.WriteLine("Player wins! Dealers hand value: " + dealershandvalue + " & Players hand value: " + playersHandValue);
                    MessageBox.Show("Player Wins!" + playersHandValue + " VS" + "Dealers Hand " + dealershandvalue);
                    clearHands();
                }
            }

        }

        private bool CheckForSplit()
        {  
            //if the two cards dealt  are the same value. split those two cards up into new playercards object and store them in a list of player hands. Then return that object
            if(playersCards.checkForSplit() == true)
            {
                Console.WriteLine("-------Split is possible");
                ShowSplitButton();
                return true;
            }
            else
            {
                return false;
            }

        }



        public void CreateNewCardBoxImage(int whoHit)
        {
            Image cardImage;
            //player hit == 0
            //dealer hit = 1
            if (whoHit == 0)
            {
                Console.WriteLine("Inside player hit new card");
                //add new card box image to players card section
                PictureBox playersHitCard = new PictureBox();
                playersHitCard.SizeMode = PictureBoxSizeMode.AutoSize;
                cardImage = playersCards.getPlayersCards()[playersCards.getPlayersCards().Count - 1].getCardImage();

                playersHitCard.Location = new Point(this.newCardPointXForPlayersHitCard, this.newCardPointYForPlayersHitCard);


                playersHitCard.Image = cardImage;

                Form1.ActiveForm.Controls.Add(playersHitCard);

                playersHitCard.BringToFront();

                hitCards.Add(playersHitCard);

                this.newCardPointXForPlayersHitCard = playersHitCard.Location.X + 25;
                this.newCardPointYForPlayersHitCard = playersHitCard.Location.Y - 15;
                

            }
            else if( whoHit == 1)
            {
                //add new card box image to dealers card section

                PictureBox dealersHitCard = new PictureBox();
                dealersHitCard.SizeMode = PictureBoxSizeMode.AutoSize;
                cardImage = dealersCards.getDealersCards()[dealersCards.getDealersCards().Count - 1].getCardImage();
                dealersHitCard.Location = new Point(this.newCardPointXForDealersHitCard, this.newCardPointYForDealersHitCard);
                dealersHitCard.Image = cardImage;

                Form1.ActiveForm.Controls.Add(dealersHitCard);

                dealersHitCard.BringToFront();
                hitCards.Add(dealersHitCard);

                this.newCardPointXForDealersHitCard = this.dealersHitCardIB.Location.X -25;
                this.newCardPointYForDealersHitCard = this.dealersHitCardIB.Location.Y + 15;




            }
            
        }
        //removes instances of createnewcardboximage
        public void DeleteCardBoxImagesForHitCards()
        {
            foreach(PictureBox card in hitCards)
            {
                Controls.Remove(card);
            }
        }


        public void cardImage(string cardSuit, string cardFace, int location)
        {
            Image card;
            string imagePath = "C:\\Users\\justi\\Desktop\\playindDeckCards\\" + cardSuit + "\\" + cardFace + ".png";
            card = Image.FromFile(imagePath);
            if (location == 0)
            {
                playerCard1.Image = card;
            }
            else if (location == 1)
            {
                playerCard2.Image = card;
            }
            else if (location == 2)
            {
                dealerCard1.Image = card;
            }
            else if (location == 3)
            {
                dealerCard2.Image = card;
            }

        }

        public void clearHands()
        {
            playersCards.resetCards();
            dealersCards.resetCards();
        }


        //revamp how we fill used card array
        //----------------------Below code deals with button actions---------------------------------------------------------
        private void hitBt_Click(object sender, EventArgs e)
        {
            Console.WriteLine(splitCardsIndicator);
            if(splitCardsIndicator == 0)
            {
                this.highLightCard1.Show();
                //hit on first card
                playersSplitHand[0].addCard(shufflingDeck[0]);
                Console.WriteLine("Players hit with: " + shufflingDeck[0].getCardFace());
                usedCards.Add(shufflingDeck[0]);
                shufflingDeck.RemoveAt(0);
                Console.WriteLine("Players 1st Split Hand hit. New hand value: " + playersSplitHand[0].getTotalValue());
                this.playersSplitHandOneValueTB.Text = playersSplitHand[0].getTotalValue().ToString();

                playerBusted();
            }
            else if(splitCardsIndicator == 1)
            {
                this.hightLightCard2.Show();
                // hit on second card
                playersSplitHand[1].addCard(shufflingDeck[0]);
                Console.WriteLine("Players hit with: " + shufflingDeck[0].getCardFace());
                usedCards.Add(shufflingDeck[0]);
                shufflingDeck.RemoveAt(0);
                Console.WriteLine("Players 2nd Split Hand hit. New hand value: " + playersSplitHand[1].getTotalValue());
                this.playersSplitHandTwoValueTB.Text = playersSplitHand[1].getTotalValue().ToString();

                playerBusted();
            }
            else if (splitCardsIndicator == 2)
            {
                //hit on both cards collectively
                playersCards.addCard(shufflingDeck[0]);
                CreateNewCardBoxImage(0);
                Console.WriteLine("Players hit with: " + shufflingDeck[0].getCardFace() + " of " + shufflingDeck[0].getCardSuit());
                usedCards.Add(shufflingDeck[0]);
                shufflingDeck.RemoveAt(0);
                this.playerHandValueLB.Text = playersCards.getTotalValue().ToString();
                Console.WriteLine("Player hit. New hand value: " + playersCards.getTotalValue());

                playerBusted();
            }




        }
        private void standbt_Click(object sender, EventArgs e)
        {
            Console.WriteLine(splitCardsIndicator);
            if (splitCardsIndicator == 0)
            {
                dealerCard2.Image = dealersCards.getDealersCards()[1].getCardImage();
                this.highLightCard1.Hide();
                this.hightLightCard2.Show();
                Console.WriteLine("Player Stands on split hand 1");
                splitCardsIndicator = 1;

            }
            else if (splitCardsIndicator == 1)
            {
                // stand on second card
                dealerCard2.Image = dealersCards.getDealersCards()[1].getCardImage();
                HideUIElements();
                Console.WriteLine("Player Stands on split hand 2");
                dealerChecksCards();
            }
            else if (splitCardsIndicator == 2)
            {
                //stand on both cards collectively
                dealerCard2.Image = dealersCards.getDealersCards()[1].getCardImage();
                HideUIElements();
                Console.WriteLine("Player Stand");
                
                dealerChecksCards();
            }
            

        }
        //clean up this garabage code
        private void dealbt_Click(object sender, EventArgs e)
        {
            GetCoordinatesforHitCardPictureBox();
            ShowButtons();
            MidGameShufflingCards();
            DeleteCardBoxImagesForHitCards();
            this.playerHandValueLB.ResetText();
            this.playerHandValueLB.BackColor = Color.White;
            Console.WriteLine("Deal Cards");

            playersCards.addCard(shufflingDeck[0]);
            playerCard1.Image = shufflingDeck[0].getCardImage();
            
            playersCards.addCard(shufflingDeck[2]);
            playerCard2.Image = shufflingDeck[2].getCardImage();
            

            Console.WriteLine("Players hand: " + shufflingDeck[0].getCardSuit() + " " + shufflingDeck[0].getCardFace() + " - " + shufflingDeck[2].getCardSuit() + " " + shufflingDeck[2].getCardFace());
            //Console.WriteLine("Players hand: " + playersCards.getPlayersCards()[0].getCardSuit() + " " + playersCards.getPlayersCards()[0].getCardFace() + " - " + playersCards.getPlayersCards()[1].getCardSuit() + " " + playersCards.getPlayersCards()[1].getCardFace());

            dealersCards.addCard(shufflingDeck[1]);
            dealerCard1.Image = dealersCards.getDealersCards()[0].getCardImage();
            
            dealersCards.addCard(shufflingDeck[3]);
            dealerCard2.Image = Image.FromFile("C:\\Users\\justi\\Desktop\\playindDeckCards\\unknown.png");
            

            Console.WriteLine("Dealers hand: " + shufflingDeck[1].getCardSuit() + " " + shufflingDeck[1].getCardFace() + " - " + shufflingDeck[3].getCardSuit() + " " + shufflingDeck[3].getCardFace());
            //Console.WriteLine("Dealers hand: " + dealersCards.getDealersCards()[0].getCardSuit() + " " + dealersCards.getDealersCards()[0].getCardFace() + " - " + dealersCards.getDealersCards()[1].getCardSuit() + " " + dealersCards.getDealersCards()[1].getCardFace());


            //alter this to take cards form dealers and players hand instead of directly from the deck
            usedCards.Add(shufflingDeck[0]);
            usedCards.Add(shufflingDeck[1]);
            usedCards.Add(shufflingDeck[2]);
            usedCards.Add(shufflingDeck[3]);
            shufflingDeck.RemoveAt(0);
            shufflingDeck.RemoveAt(0);
            shufflingDeck.RemoveAt(0);
            shufflingDeck.RemoveAt(0);

            this.playerHandValueLB.Text = playersCards.getTotalValue().ToString();
            Console.WriteLine("Players hand " + playersCards.getTotalValue());
            Console.WriteLine("Dealers hand " + dealersCards.getTotalValue());
            /*
            Console.WriteLine("cards left in shuffling deck---------------");
            foreach (Card card in shufflingDeck)
            {
                Console.WriteLine(card.getCardFace() + " " + card.getCardSuit());
            }
            Console.WriteLine("Used cards");
            foreach (Card card in usedCards)
            {
                Console.WriteLine(card.getCardFace() + " " + card.getCardSuit());
            }
            */
            CheckForSplit();
        }
        //if user gets two cards of the same value they can split it and play two hands at once
        private void splitbt_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Made into here");
            

            if(CheckForSplit() == true)
            {
                this.splitbt.Hide();
                this.highLightCard1.Show();
                PlayersCards handone = new PlayersCards();
                handone.addCard(playersCards.getPlayersCards()[0]);
                playersSplitHand.Add(handone);
                Console.WriteLine("Players 1st hand : " + playersSplitHand[0].getPlayersCards()[0].getCardFace() + " " + playersSplitHand[0].getPlayersCards()[0].getCardSuit());
                this.playersSplitHandOneValueTB.Text = handone.getTotalValue().ToString();


                PlayersCards handtwo = new PlayersCards();
                handtwo.addCard(playersCards.getPlayersCards()[1]);
                playersSplitHand.Add(handtwo);
                Console.WriteLine("Players 2nd hand: " + playersSplitHand[1].getPlayersCards()[0].getCardFace() + " " + playersSplitHand[1].getPlayersCards()[0].getCardSuit());
                this.playersSplitHandTwoValueTB.Text = handtwo.getTotalValue().ToString();


                this.playerHandValueLB.ResetText();



                splitCardsIndicator = 0;
            }
        }
    }
//----------------------Below code are objects used in application---------------------------------

    //needed to store the card data associated to each card in a objective form so that it was accesible later down the road 
    public class Card
    {
        public int cardValue;//add special case for aces 1 or 11
        public string cardSuit;
        public string cardFace; //A-K
        public Image cardImage; //future option
        

        public Card(string cardFace, string cardSuit, int cardValue, String cardImagePath)
        {
            this.cardFace = cardFace;
            this.cardSuit = cardSuit;
            this.cardValue = cardValue;
            this.cardImage = Image.FromFile(cardImagePath);

        }
        public Image getCardImage()
        {
            return this.cardImage;
        }
        public int getCardValue()
        {
            return this.cardValue;
        }
        public string getCardSuit()
        {
            return this.cardSuit;
        }
        public string getCardFace()
        {
            return this.cardFace;
        }

    }
    //objective thinking about a players hand during a hand. Needed to store what cards they so I can use that data in a calculations
    public class PlayersCards
    {
        List<Card> playersCards = new List<Card>();
        int handValue;

        public PlayersCards()
        {
            
            //this.playersCard.Add(card);
            //this.handValue = card.getCardValue();
        }
        //adds a card to playercards object
        public void addCard(Card card)
        {
            this.playersCards.Add(card);
            this.handValue += card.getCardValue();
        }

        public List<Card> getPlayersCards()
        {
            return this.playersCards;
        }
        //gets total numerical value of all cards in playerscards object
        public int getTotalValue()
        {
            return this.handValue;
        }
        public void resetCards()
        {
            this.playersCards.Clear();
            this.handValue = 0;
        }

        public Boolean checkForSplit()
        {
            if(playersCards[0].getCardFace() == playersCards[1].getCardFace())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    //objective thinking about a dealers hand during a hand. Needed to store what cards they have so I can use that data in later calculations
    public class DealersCards
    {
        List<Card> dealersCards = new List<Card>();
        int handValue;

        public DealersCards()
        {
            //this.dealersCards.Add(card);
           // this.handValue = card.getCardValue();
        }

        public void addCard(Card card)
        {
            this.dealersCards.Add(card);
            this.handValue += card.getCardValue();
        }

        public List<Card> getDealersCards()
        {
            return this.dealersCards;
        }

        public int getTotalValue()
        {
            return this.handValue;
        }

        public void resetCards()
        {
            this.dealersCards.Clear();
            this.handValue = 0;
        }
    }
}
