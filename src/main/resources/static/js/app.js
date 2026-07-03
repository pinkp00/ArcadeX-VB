document.addEventListener("DOMContentLoaded", () => {
    updateScoreboard();
});

function updateScoreboard() {
    fetch('/api/game/scores')
        .then(response => response.json())
        .then(data => {
            document.getElementById('rps-w').innerText = data.rpsWins;
            document.getElementById('rps-l').innerText = data.rpsLosses;
            document.getElementById('rps-t').innerText = data.rpsTies;
            document.getElementById('bs-w').innerText = data.bsWins;
            document.getElementById('bs-l').innerText = data.bsLosses;
        })
        .catch(err => console.error("Database sync error:", err));
}

function startRPS() {
    let choice = prompt("Enter rock, paper, or scissors:").toLowerCase();
    if (choice !== "rock" && choice !== "paper" && choice !== "scissors") {
        alert("Invalid input logic validation triggered!");
        return;
    }

    fetch(`/api/game/rps?playerChoice=${choice}`, { method: 'POST' })
        .then(res => res.json())
        .then(data => {
            alert(`Computer Choice: ${data.computerChoice.toUpperCase()}\nResult: ${data.result}`);
            updateScoreboard();
        });
}

function startBattleship() {
    alert("Battleship Arena Engine Loaded! Ready to fire coordinates.");
}