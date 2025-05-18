using System.Diagnostics;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Tache1_CsvStats
{
    
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start(); // Démarrage du chrono

        string filePath = "notes_etudiants.csv";
        

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Fichier introuvable : {filePath}");
            return;
        }

        var lignes = File.ReadAllLines(filePath);
        var enTete = lignes[0].Split(',');

        var matieres = new Dictionary<string, List<int>>();
        for (int i = 1; i < enTete.Length; i++)
        {
            matieres[enTete[i]] = new List<int>();
        }

        for (int i = 1; i < lignes.Length; i++)
        {
            var valeurs = lignes[i].Split(',');
            for (int j = 1; j < valeurs.Length; j++)
            {
                if (int.TryParse(valeurs[j], out int note))
                {
                    matieres[enTete[j]].Add(note);
                }
            }
        }

        Console.WriteLine("Données chargées :\n");
        int nbLignesAAfficher = Math.Min(5, lignes.Length - 1);
        Console.WriteLine(string.Join(" | ", enTete));
        for (int i = 1; i <= nbLignesAAfficher; i++)
        {
            var valeurs = lignes[i].Split(',');
            Console.WriteLine(string.Join(" | ", valeurs));
        }

        Console.WriteLine("\nStatistiques par cours :\n");
        foreach (var matiere in matieres)
        {
            var notes = matiere.Value;
            Console.WriteLine($"--- {matiere.Key} ---");
            Console.WriteLine($"  Moyenne : {notes.Average():F2}");
            Console.WriteLine($"  Maximum : {notes.Max()}");
            Console.WriteLine($"  Minimum : {notes.Min()}");
            Console.WriteLine($"  Somme   : {notes.Sum()}\n");
        }

        stopwatch.Stop(); // Fin du chrono
        Console.WriteLine($"⏱ Temps d'exécution : {stopwatch.Elapsed.TotalSeconds:F6} secondes");
    }
    
}
