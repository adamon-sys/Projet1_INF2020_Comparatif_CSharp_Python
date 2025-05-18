import pandas as pd
import time

start = time.time()  # Début du chronomètre

# Charger le fichier CSV
df = pd.read_csv("notes_etudiants.csv")

# Afficher les premières lignes pour vérification
print("Données chargées :\n")
print(df.head())

# Calcul des statistiques
print("\nStatistiques par cours :\n")
cours = df.columns[1:]  # Supposer que la 1re colonne est le nom des étudiants

for matiere in cours:
    print(f"--- {matiere} ---")
    print(f"  Moyenne : {df[matiere].mean():.2f}")
    print(f"  Maximum : {df[matiere].max()}")
    print(f"  Minimum : {df[matiere].min()}")
    print(f"  Somme   : {df[matiere].sum()}\n")

end = time.time()  # Fin du chronomètre
print(f"\n⏱ Temps d'exécution : {(end - start) * 1000:.3f} millisecondes")
