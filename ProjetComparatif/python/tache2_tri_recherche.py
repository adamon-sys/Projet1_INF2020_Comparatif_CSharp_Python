import pandas as pd
import time

start = time.time()

# Charger les données
df = pd.read_csv("notes_etudiants.csv")

# Extraire et trier les noms par ordre alphabétique
noms_tries = sorted(df["Nom"])

# Rechercher les noms terminant par "e"
noms_finissant_par_e = [nom for nom in noms_tries if nom.endswith("e")]

# Affichage des résultats
print("Étudiants dont le nom se termine par 'e' :\n")
for nom in noms_finissant_par_e:
    print(nom)

# Temps d'exécution
end = time.time()
print(f"\n⏱ Temps d'exécution : {(end - start) * 1000:.3f} millisecondes")
