using System;
using System.Collections.Generic; 
using System.Diagnostics;         
using System.IO;                 
using System.Linq;                

class Tache2_TriRecherche
{
    static void Main()
    {
        // Démarrage du chronomètre
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Chemin du fichier contenant les noms d'étudiants
        string filePath = "notes_etudiants.csv";

        // Vérifie si le fichier existe
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Fichier introuvable : {filePath}");
            return;
        }

        // Lire toutes les lignes sauf l'en-tête (Skip(1))
        var lignes = File.ReadAllLines(filePath).Skip(1);

        // Liste pour stocker les noms des étudiants
        var noms = new List<string>();

        // Parcours des lignes pour extraire les noms (1re colonne)
        foreach (var ligne in lignes)
        {
            var colonnes = ligne.Split(',');
            if (colonnes.Length > 0)
                noms.Add(colonnes[0]); // Ajouter le nom à la liste
        }

        // Trier les noms par ordre alphabétique
        noms.Sort();

        // Filtrer les noms qui se terminent par la lettre "e"
        var nomsFinissantParE = noms.Where(n => n.EndsWith("e")).ToList();

        // Affichage des résultats
        Console.WriteLine("Étudiants dont le nom se termine par 'e' :\n");
        foreach (var nom in nomsFinissantParE)
        {
            Console.WriteLine(nom);
        }

        // Arrêt du chronomètre et affichage du temps d'exécution
        stopwatch.Stop();
        Console.WriteLine($"\n⏱ Temps d'exécution : {stopwatch.Elapsed.TotalMilliseconds:F3} millisecondes");

    }
}
