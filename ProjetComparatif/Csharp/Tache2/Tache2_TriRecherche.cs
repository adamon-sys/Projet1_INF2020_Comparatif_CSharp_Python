using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Tache2_TriRecherche
{
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string filePath = "notes_etudiants.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Fichier introuvable : {filePath}");
            return;
        }

        var lignes = File.ReadAllLines(filePath).Skip(1); // Sauter l'en-tête
        var noms = new List<string>();

        foreach (var ligne in lignes)
        {
            var colonnes = ligne.Split(',');
            if (colonnes.Length > 0)
                noms.Add(colonnes[0]); // Supposer que le nom est dans la première colonne
        }

        // Trier les noms
        noms.Sort();

        // Rechercher ceux qui se terminent par "e"
        var nomsFinissantParE = noms.Where(n => n.EndsWith("e")).ToList();

        // Affichage des résultats
        Console.WriteLine("Étudiants dont le nom se termine par 'e' :\n");
        foreach (var nom in nomsFinissantParE)
        {
            Console.WriteLine(nom);
        }

        stopwatch.Stop();
        Console.WriteLine($"\n⏱ Temps d'exécution : {stopwatch.Elapsed.TotalSeconds:F6} secondes");
    }
}
