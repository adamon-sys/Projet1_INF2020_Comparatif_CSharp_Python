using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Tache3_AnalyseTexte
{
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string filePath = "texte.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Fichier introuvable : {filePath}");
            return;
        }

        string texte = File.ReadAllText(filePath).ToLower();

        // Extraire les mots avec une expression régulière
        var mots = Regex.Matches(texte, @"\b\w+\b")
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToList();

        int nbTotal = mots.Count;

        // Compter les fréquences
        var frequence = mots
            .GroupBy(m => m)
            .ToDictionary(g => g.Key, g => g.Count());

        // Extraire les 10 mots les plus fréquents
        var top10 = frequence
            .OrderByDescending(kvp => kvp.Value)
            .Take(10);

        // Affichage
        Console.WriteLine($"Nombre total de mots : {nbTotal}\n");
        Console.WriteLine("10 mots les plus fréquents :\n");
        foreach (var kvp in top10)
        {
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
        }
        // Arrêt du chronomètre et affichage du temps d'exécution
        stopwatch.Stop();
        Console.WriteLine($"\n⏱ Temps d'exécution : {stopwatch.Elapsed.TotalMilliseconds:F3} millisecondes");
    }
}
