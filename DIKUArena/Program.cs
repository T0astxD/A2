namespace DIKUArena;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Gladiator samnite = new Samnite("Boris");
        Gladiator traex = new Traex("Oleks");
        Gladiator retiarii = new Retiarii("Professor Boss");
        Gladiator retiarii2 = new Retiarii("Alexus");
        Arena storeKnirke = new Arena();
        
        List<Gladiator> Competitors = new List<Gladiator>();
        Gladiator[] newCompetitors = { samnite, retiarii, traex, retiarii2 };
        Competitors.AddRange(newCompetitors);

        storeKnirke.RunTournament(Competitors);
    }
}
