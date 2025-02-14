namespace DIKUArena;
using System;
using System.Collections.Generic;

public class Arena {
    public Arena() {
    }


    public Gladiator Battle(Gladiator g1, Gladiator g2) {
        Console.WriteLine("Fight til death!");
        int round = 1;
        Gladiator current = g1;
        Gladiator inactive = g2;
        Gladiator winner = null;

        while (!g1.HasLost() && !g2.HasLost()) {
            Console.WriteLine("ROUND: {0}", round);
            current.Attack(inactive);
            Console.WriteLine($"Enemy health: {inactive.Health}");


            if (inactive.HasLost()) {
                winner = current;
            }
            Gladiator temp = current;
            current = inactive;
            inactive = temp;
            round++;

        }

        winner.GetExperience();
        Console.WriteLine("The winner is: {0}", winner.Name);

        return winner;
    }

    public Gladiator RunTournament(List<Gladiator> Competitors) {

        while (Competitors.Count > 1) {
            List<Gladiator> listOfWinners = new List<Gladiator>();

            for (int i = 0; i < Competitors.Count; i += 2) {
                if (i + 1 >= Competitors.Count) {
                    listOfWinners.Add(Competitors[i]);
                    break;
                } else {
                    Gladiator g1 = Competitors[i];
                    Gladiator g2 = Competitors[i + 1];
                    Gladiator winner = Battle(g1, g2);
                    listOfWinners.Add(winner);
                }

            }
            Competitors.Clear();
            Competitors.AddRange(listOfWinners);
        }
        return Competitors[0];
    }
}

