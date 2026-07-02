# ArcadeX-VB

# Title: ARCADE-X: **The Ultimate Terminal Gaming Hub**

# Overview
Welcome to **ARCADE-X**, a lightweight, high-performance console gaming ecosystem built entirely using **Visual Basic ****.NET (VB.NET)**. Designed to run seamlessly in cloud environments like **GitHub Codespaces** and local terminals, this hub brings back the nostalgic retro arcade vibe with zero dependencies and crash-proof input validation.Whether you want to test your luck, outsmart a customized AI, or deploy strategic military tactics, ARCADE-X delivers a premium CLI (Command Line Interface) gaming experience.

# 🎮 Featured Games & Core Modules

# ⚓ Battleship Commander (Tactical Naval Combat):
Step into the shoes of a fleet admiral. The system secretly deploys enemy warships on a $4 \times 4$ multi-dimensional matrix grid. You have exactly 7 torpedoes to map the coordinates, calculate your trajectory, and destroy the enemy fleet before running out of ammo. Features real-time recon mapping tracking hits [💥] and misses [M].

# ⭕ Tic-Tac-Toe Arena (Smart AI vs. Local Guest):
No friends online? No problem. Play against a smart automated computer engine that dynamically takes up open spots. Want to challenge a friend? Switch seamlessly to the local 2-Player Guest Mode with personalized profile name tracking.

# ✊ Rock, Paper, Scissors (Instant Arena Match):
A fast-paced arena combat module against the computer with automated win/loss logic to settle any score instantly.

# 📊 Live Performance Scoreboard:
A dedicated session tracker that monitors active data, recording win percentages, losses, draws, and total ammunition stats for all modules in real-time.

# ⚡ Key Engineering Features100% Crash-Proof Architecture: 
Built with rigorous integer parsing (Integer.TryParse) and Regular Expression (Regex) input sanitation. The system refuses to crash on empty inputs, letters, or invalid out-of-bounds coordinates.

# Cloud-Optimized Workflow:
Fully tailored to run inside GitHub Codespaces using the modern .NET Core SDK console environment.

# Clean Text Layouts:
Completely stripped of messy encoding characters to guarantee a flawless vertical alignment across all standard terminal screens.
# 🛠️ Quick Start (Inside GitHub Codespaces)Simply open your Codespace terminal and type:
Bashdotnet new console -lang "VB" -o ArcadeX
# Swap the code inside Program.vb with the script, then run:
cd ArcadeX
dotnet run
