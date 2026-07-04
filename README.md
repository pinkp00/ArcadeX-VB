# ArcadeX-VB

# Arcade-X Gaming Hub

A comprehensive, full-stack web application designed for interactive gaming and real-time score management. Developed as a high-performance solution for automated gaming experiences.This project leverages the robust architecture of Visual Basic 6.0 (VB6) combined with modern backend integration for legacy system modernization.

## 🚀 Key Features
* **Core Logic:** Visual Basic 6.0 (VB6)
* **Interactive Gaming:** Includes three distinct game modes (Rock, Paper, Scissors, Tic-Tac-Toe, and Battleship).
* **Full-Stack Architecture:** Built with a Spring Boot backend and a responsive web frontend.
* **Real-time Data:** Seamless integration with MySQL for persistent user data and score tracking.
* **Cloud-Ready:** Developed using GitHub Codespaces for a modern, scalable development environment.

## 🛠 Tech Stack

* **Backend:** Java, Spring Boot
* **Frontend:** HTML, CSS, JavaScript (app.js), VB6
* **Database:** MySQL
* **Environment:** GitHub Codespaces, Maven

## 💻 How to Run

Follow these commands to launch the application and verify the database:

### 1. Launch Backend Service


# Navigate to project directory


mvnw spring-boot:run


### 2. Database Management & Verification


Open a separate bash terminal in Codespaces and access your MySQL database:


# Login to MySQL


mysql -u [your_username] -p


# Switch to your project database


USE defaultdb;


# View all stored player scores


SELECT * FROM scores;


# Inspect database schema


DESCRIBE scores;


# Retrieve specific player data


SELECT * FROM scores WHERE player_name = 'YourPlayerName';


