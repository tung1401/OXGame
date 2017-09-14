using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {

        public static string[] Number = new[] { "9", "T", "J", "Q", "K", "A" };
        public static string[] Type = new[] { "C", "D", "H", "S" };



        public static List<DeckModel> Deck1 = new List<DeckModel>();
        public static List<DeckModel> Deck2 = new List<DeckModel>();

        public static List<DeckModel> WarDeck = new List<DeckModel>();
        public static List<DeckModel> WarDeck1 = new List<DeckModel>();
        public static List<DeckModel> WarDeck2 = new List<DeckModel>();

        static void Main(string[] args)
        {

            var allCard = SetDeck().OrderBy(c => Guid.NewGuid()).ToList();

            var random = new Random();
            var value = random.Next(0, allCard.Count);
            var diff = 12 - value;

            /*   player1 = allCard.Take(value).ToList();
               player2 = allCard.Skip(value).ToList();*/

            Deck1 = DataMockup31().ToList();
            Deck2 = DataMockup32().ToList();//allCard.Where(p => !player1.Select(x => x.Card).Contains(p.Card)).ToList();//allCard.AsEnumerable().OrderBy(x=>x.Value).Where(x=> player1.Any(x2 => x.x)).ToList();// allCard.Where(x=> !player1.Contains(x)).ToList();


            var count = 0;
            var step = 0;
            while (count < 100)
            {
                if (!Deck1.Any())
                {
                    //player 1 lose, player 2 win
                    step = count;
                    Console.WriteLine(string.Format("Deck2 wins in {0} steps", step));
                    break;
                }
                if (!Deck2.Any())
                {
                    //player 2 lose,player 1 win
                    step = count;
                    Console.WriteLine(string.Format("Deck1 wins in {0} steps", step));
                    break;
                }

                count++;
                if (count < 100)
                {
                    Console.WriteLine(string.Format("****** Count: " + count + " **********"));
                    Console.WriteLine(string.Format("Deck 1 Before: " + PrintDeck(Deck1)));
                    Console.WriteLine(string.Format("Deck 2 Before: " + PrintDeck(Deck2)));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Format("[Compare] : " + Deck1.FirstOrDefault().Card + " , " + Deck2.FirstOrDefault().Card));
                    Console.ForegroundColor = ConsoleColor.White;
                    Compare(Deck1.FirstOrDefault(), Deck2.FirstOrDefault());
                }

                if (count >= 100)
                {
                    Console.WriteLine(string.Format("Game ties after 100 steps"));
                    break;
                }
             
                Console.WriteLine(string.Format("Deck 1 After: " + PrintDeck(Deck1)));
                Console.WriteLine(string.Format("Deck 2 After: " + PrintDeck(Deck2)));
                Console.WriteLine(string.Format("****************"));
                Console.WriteLine(string.Format(""));
               /* if (count == 24)
                {

                }*/
            }
        }

        public static string PrintDeck(List<DeckModel> deck)
        {
            var msg = "";
            foreach(var item in deck)
            {
                msg += item.Card + ", ";
            }
            return msg;

        }

        public static List<DeckModel> SetDeck()
        {
            var deck = new List<DeckModel>();
            for (var i = 0; i < Number.Length; i++)
            {
                for (var j = 0; j < Type.Length; j++)
                {
                    var item = new DeckModel();
                    item.Card = Number[i] + Type[j];
                    item.Value = 9 + i;
                    item.Category = j + 100;
                    deck.Add(item);
                }
            }
            return deck;
        }


        public static void Compare(DeckModel card1, DeckModel card2)
        {
            var tempcard1 = card1;
            var tempcard2 = card2;

            if (card1.Value > card2.Value)
            {
                if(WarDeck.Any() && WarDeck.Any())
                {

                    Deck1.AddRange(WarDeck);
                    //  Deck1.AddRange(WarDeck2);

                    WarDeck = new List<DeckModel>();
                    WarDeck = new List<DeckModel>();
                }
                else
                {
                    Deck1.Remove(card1);
                    Deck2.Remove(card2);

                    Deck1.Add(tempcard1);
                    Deck1.Add(tempcard2);
                }

               

            }
            else if (card1.Value == card2.Value)
            {

                //war mode
                WarDeck.Add(tempcard1);
                WarDeck.Add(tempcard2);

                Deck1.Remove(card1);
                Deck2.Remove(card2);

                var m1 = Deck1.FirstOrDefault();
                var m2 = Deck2.FirstOrDefault();

                WarDeck.Add(m1);
                WarDeck.Add(m2);

                Deck1.Remove(card1);
                Deck2.Remove(card2);

                var o1 = Deck1.FirstOrDefault();
                var o2 = Deck2.FirstOrDefault();

                WarMode(o1, o2);


                //if (card1.Category > card2.Category)
                //{
                //    Deck1.Remove(card1);
                //    Deck2.Remove(card2);

                //    Deck1.Add(tempcard1);
                //    Deck1.Add(tempcard2);
                //}
                //else if(card1.Category < card2.Category)
                //{
                //    Deck1.Remove(card1);
                //    Deck2.Remove(card2);

                //    Deck2.Add(tempcard1);
                //    Deck2.Add(tempcard2);

                //}
            }
            else if (card1.Value < card2.Value)
            {
                if (WarDeck.Any() && WarDeck.Any())
                {
                    Deck2.AddRange(WarDeck);
                    //  Deck2.AddRange(WarDeck2);

                    WarDeck = new List<DeckModel>();
                    WarDeck = new List<DeckModel>();
                }
                else
                {
                    Deck1.Remove(card1);
                    Deck2.Remove(card2);

                    Deck2.Add(tempcard1);
                    Deck2.Add(tempcard2);
                }


              
                
            }
        }

        public static void WarMode(DeckModel card1, DeckModel card2)
        {

            Compare(card1, card2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("****** War **********"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public class DeckModel
        {
            public string Card { set; get; }
            public int Value { set; get; }
            public int Category { set; get; }
        }

        enum TypeValue
        {
            C = 100,
            D = 101,
            H = 102,
            S = 103
        }
        enum CardValue
        {
            N = 9,
            T = 10,
            J = 11,
            Q = 12,
            K = 13,
            A = 14
        }
        public static List<DeckModel> DataMockup11()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "9C", Value = (int)CardValue.N,Category = (int)TypeValue.C },
                new DeckModel { Card = "TD", Value = (int)CardValue.T, Category = (int)TypeValue.D },
                new DeckModel { Card = "JH", Value = (int)CardValue.J,Category = (int)TypeValue.H },
                new DeckModel { Card = "QS", Value = (int)CardValue.Q,Category = (int)TypeValue.S  },
            };
            return list;
        }
        public static List<DeckModel> DataMockup12()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "TC", Value = (int)CardValue.T,Category = (int)TypeValue.C   },
                new DeckModel { Card = "JD", Value = (int)CardValue.J,Category = (int)TypeValue.D  },
                new DeckModel { Card = "QH", Value = (int)CardValue.Q,Category = (int)TypeValue.H  },
                new DeckModel { Card = "KS", Value = (int)CardValue.K,Category = (int)TypeValue.S  },
                new DeckModel { Card = "AC", Value = (int)CardValue.A,Category = (int)TypeValue.C  },
                new DeckModel { Card = "AH", Value = (int)CardValue.A,Category = (int)TypeValue.H },
                new DeckModel { Card = "TH", Value = (int)CardValue.T,Category = (int)TypeValue.H    },
                new DeckModel { Card = "JS", Value = (int)CardValue.J,Category = (int)TypeValue.S   },
                new DeckModel { Card = "QC", Value = (int)CardValue.Q,Category = (int)TypeValue.C   },
                new DeckModel { Card = "KD", Value = (int)CardValue.K,Category = (int)TypeValue.D },
                new DeckModel { Card = "9D", Value = (int)CardValue.N,Category = (int)TypeValue.D   },
                new DeckModel { Card = "9S", Value = (int)CardValue.N,Category = (int)TypeValue.S     },

            };
            return list;
        }
        public static List<DeckModel> DataMockup21()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "KC", Value = (int)CardValue.K,Category = (int)TypeValue.C },
                new DeckModel { Card = "AD", Value = (int)CardValue.A, Category = (int)TypeValue.D },
                    new DeckModel { Card = "JH", Value = (int)CardValue.J,Category = (int)TypeValue.H },
                        new DeckModel { Card = "AS", Value = (int)CardValue.A,Category = (int)TypeValue.S  },
            };
            return list;
        }
        public static List<DeckModel> DataMockup22()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "TC", Value = (int)CardValue.T,Category = (int)TypeValue.C },
                new DeckModel { Card = "JD", Value = (int)CardValue.J, Category = (int)TypeValue.D },
                    new DeckModel { Card = "QH", Value = (int)CardValue.Q,Category = (int)TypeValue.H },
                        new DeckModel { Card = "KS", Value = (int)CardValue.K,Category = (int)TypeValue.S  },
            };
            return list;
        }
        public static List<DeckModel> DataMockup31()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "9C", Value = (int)CardValue.N,Category = (int)TypeValue.C },
                new DeckModel { Card = "TD", Value = (int)CardValue.T, Category = (int)TypeValue.D },
                new DeckModel { Card = "JH", Value = (int)CardValue.J,Category = (int)TypeValue.H },
                new DeckModel { Card = "QS", Value = (int)CardValue.Q,Category = (int)TypeValue.S  },
                new DeckModel { Card = "KC", Value = (int)CardValue.K,Category = (int)TypeValue.C },
                new DeckModel { Card = "AD", Value = (int)CardValue.A, Category = (int)TypeValue.D },
                new DeckModel { Card = "9H", Value = (int)CardValue.N,Category = (int)TypeValue.H },
                new DeckModel { Card = "TS", Value = (int)CardValue.T,Category = (int)TypeValue.S },
                  new DeckModel { Card = "JC", Value = (int)CardValue.J,Category = (int)TypeValue.C },
                    new DeckModel { Card = "QD", Value = (int)CardValue.Q,Category = (int)TypeValue.D  },
                     new DeckModel { Card = "KH", Value = (int)CardValue.K,Category = (int)TypeValue.H },
                            new DeckModel { Card = "AS", Value = (int)CardValue.A,Category = (int)TypeValue.S  },
            };
            return list;
        }
        public static List<DeckModel> DataMockup32()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "TC", Value = (int)CardValue.T,Category = (int)TypeValue.C   },
                new DeckModel { Card = "JD", Value = (int)CardValue.J,Category = (int)TypeValue.D  },
                new DeckModel { Card = "QH", Value = (int)CardValue.Q,Category = (int)TypeValue.H  },
                new DeckModel { Card = "KS", Value = (int)CardValue.K,Category = (int)TypeValue.S  },
                new DeckModel { Card = "AC", Value = (int)CardValue.A,Category = (int)TypeValue.C  },
                new DeckModel { Card = "AH", Value = (int)CardValue.A,Category = (int)TypeValue.H },
                new DeckModel { Card = "TH", Value = (int)CardValue.T,Category = (int)TypeValue.H    },
                new DeckModel { Card = "JS", Value = (int)CardValue.J,Category = (int)TypeValue.S   },
                new DeckModel { Card = "QC", Value = (int)CardValue.Q,Category = (int)TypeValue.C   },
                new DeckModel { Card = "KD", Value = (int)CardValue.K,Category = (int)TypeValue.D },
                new DeckModel { Card = "9D", Value = (int)CardValue.N,Category = (int)TypeValue.D   },
                new DeckModel { Card = "9S", Value = (int)CardValue.N,Category = (int)TypeValue.S     },

            };
            return list;
        }


        public static List<DeckModel> DataMockup41()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "9C", Value = (int)CardValue.N,Category = (int)TypeValue.C },
                new DeckModel { Card = "TD", Value = (int)CardValue.T, Category = (int)TypeValue.D },

            };
            return list;
        }
        public static List<DeckModel> DataMockup42()
        {
            var list = new List<DeckModel> {
                new DeckModel { Card = "TC", Value = (int)CardValue.T,Category = (int)TypeValue.C },
                new DeckModel { Card = "9D", Value = (int)CardValue.N, Category = (int)TypeValue.D },
            };
            return list;
        }

    }
}
