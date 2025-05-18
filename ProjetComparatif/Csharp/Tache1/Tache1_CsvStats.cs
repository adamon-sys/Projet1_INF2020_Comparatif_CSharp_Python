using System.Diagnostics;           // Pour mesurer le temps d'exécution
using System;                       // Fonctions de base (Console, etc.)
using System.IO;                    // Pour lire le fichier
using System.Collections.Generic;   // Pour utiliser les listes et dictionnaires
using System.Linq;                  // Pour les fonctions statistiques comme Average(), Max(), etc.

class Tache1_CsvStats
{
    static void Main()
    {
        // Initialisation du chronomètre pour mesurer le temps d'exécution
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Chemin vers le fichier CSV
        string filePath = "notes_etudiants.csv";

        // Vérifier que le fichier existe
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Fichier introuvable : {filePath}");
            return;
        }

        // Lire toutes les lignes du fichier
        var lignes = File.ReadAllLines(filePath);

        // Extraire l'en-tête (noms des colonnes) à partir de la première ligne
        var enTete = lignes[0].Split(',');

        // Créer un dictionnaire pour stocker les notes par matière
        var matieres = new Dictionary<string, List<int>>();
        for (int i = 1; i < enTete.Length; i++)
        {
            matieres[enTete[i]] = new List<int>();
        }

        // Remplir le dictionnaire avec les notes à partir des lignes suivantes
        for (int i = 1; i < lignes.Length; i++)
        {
            var valeurs = lignes[i].Split(',');

            // On commence à j = 1 pour ignorer le nom de l'étudiant
            for (int j = 1; j < valeurs.Length; j++)
            {
                // Convertir la note en entier si possible
                if (int.TryParse(valeurs[j], out int note))
                {
                    // Ajouter la note à la liste de la matière correspondante
                    matieres[enTete[j]].Add(note);
                }
            }
        }

        // Afficher les données chargées (jusqu'à 5 lignes)
        Console.WriteLine("Données chargées :\n");
        int nbLignesAAfficher = Math.Min(5, lignes.Length - 1);
        Console.WriteLine(string.Join(" | ", enTete));
        for (int i = 1; i <= nbLignesAAfficher; i++)
        {
            var valeurs = lignes[i].Split(',');
            Console.WriteLine(string.Join(" | ", valeurs));
        }

        // Calcul et affichage des statistiques par matière
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

        // Arrêt du chronomètre et affichage du temps d'exécution
        stopwatch.Stop();
        Console.WriteLine($"\n⏱ Temps d'exécution : {stopwatch.Elapsed.TotalMilliseconds:F3} millisecondes");

    }
}
