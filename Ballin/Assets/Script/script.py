import os

folder_path = r"C:\Users\admin\Documents\Data\Schule\4.Klasse\PRE\pols\Ballin\Assets\Script"  # ersetze "Assets/Script" durch den tatsächlichen Pfad zu deinem Ordner

# Schleife durch alle Dateien im Ordner und seinen Unterordnern
for root, dirs, files in os.walk(folder_path):
    for filename in files:
        if filename.endswith(".cs"):
            file_path = os.path.join(root, filename)
            rel_path = os.path.relpath(file_path, folder_path)
            num_lines = sum(1 for line in open(file_path, 'r', encoding="cp1252"))  # Zähle die Anzahl der Zeilen in der Datei
            print(f"{rel_path}\n  - {filename}\n    - {num_lines} Zeilen")  # Gib die Ergebnisse aus
