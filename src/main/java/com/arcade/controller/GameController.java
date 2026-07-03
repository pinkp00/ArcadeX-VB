package com.arcade.controller;

import org.springframework.web.bind.annotation.*;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;

@RestController
@RequestMapping("/api/game")
@CrossOrigin(origins = "*")
public class GameController {

    // Runtime database memory caching
    private int rpsWins = 0, rpsLosses = 0, rpsTies = 0;
    private int bsWins = 0, bsLosses = 0;

    @GetMapping("/scores")
    public Map<String, Object> getScoreboard() {
        Map<String, Object> scores = new HashMap<>();
        scores.put("rpsWins", rpsWins);
        scores.put("rpsLosses", rpsLosses);
        scores.put("rpsTies", rpsTies);
        scores.put("bsWins", bsWins);
        scores.put("bsLosses", bsLosses);
        return scores;
    }

    @PostMapping("/rps")
    public Map<String, String> playRPS(@RequestParam String playerChoice) {
        String[] choices = {"rock", "paper", "scissors"};
        String computerChoice = choices[new Random().nextInt(3)];
        String result = "";

        if (playerChoice.equalsIgnoreCase(computerChoice)) {
            result = "TIE";
            rpsTies++;
        } else if ((playerChoice.equalsIgnoreCase("rock") && computerChoice.equals("scissors")) ||
                   (playerChoice.equalsIgnoreCase("paper") && computerChoice.equals("rock")) ||
                   (playerChoice.equalsIgnoreCase("scissors") && computerChoice.equals("paper"))) {
            result = "WIN";
            rpsWins++;
        } else {
            result = "LOSS";
            rpsLosses++;
        }

        Map<String, String> response = new HashMap<>();
        response.put("computerChoice", computerChoice);
        response.put("result", result);
        return response;
    }
}