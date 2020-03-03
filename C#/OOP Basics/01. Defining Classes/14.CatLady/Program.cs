using System;
using System.Collections.Generic;

namespace _14.CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();
            string inputLine = "";
            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] catInfo = inputLine.Split();

                string catBreed = catInfo[0];
                string catName = catInfo[1];

                Cat currentCat = null;

                if (catBreed == "Siamese")
                {
                    int earSize = int.Parse(catInfo[2]);
                    currentCat = new Siamese(catName, earSize);
                }
                else if (catBreed == "Cymric")
                {
                    double furLength = double.Parse(catInfo[2]);
                    currentCat = new Cymric(catName, furLength);
                }
                else if (catBreed == "StreetExtraordinaire")
                {
                    int decibelsOfMeows = int.Parse(catInfo[2]);
                currentCat = new StreetExtraordinaire(catName, decibelsOfMeows);
                }

                cats.Add(currentCat);
            }

            string input = Console.ReadLine();
            Cat catToPrint = cats.Find(a => a.Name == input);
            Console.WriteLine(catToPrint);
        }
    }
}
