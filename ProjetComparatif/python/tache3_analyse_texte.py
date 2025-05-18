import time
from collections import Counter
import re

start = time.time()

# Lire le fichier texte
with open("texte.txt", "r", encoding="utf-8") as f:
    texte = f.read().lower()  # Minuscule pour éviter les doublons "Le" vs "le"

# Nettoyer le texte (enlever ponctuation, conserver les mots)
mots = re.findall(r'\b\w+\b', texte)

# Compter les mots
nb_total = len(mots)
frequence = Counter(mots)
top10 = frequence.most_common(10)

# Affichage des résultats
print(f"Nombre total de mots : {nb_total}\n")
print("10 mots les plus fréquents :\n")
for mot, count in top10:
    print(f"{mot} : {count}")

end = time.time()
print(f"\n⏱ Temps d'exécution : {(end - start) * 1000:.3f} millisecondes")


