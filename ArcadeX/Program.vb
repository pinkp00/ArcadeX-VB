Imports System
Imports System.Text.RegularExpressions

Module VisualBasicGamingHub
    ' --- GLOBAL VARIABLES FOR SCORE TRACKING ---
    Dim playerName As String = "Player"
    Dim guestName As String = "Guest"
    Dim rpsWins As Integer = 0, rpsLosses As Integer = 0, rpsTies As Integer = 0
    Dim tttWins As Integer = 0, tttLosses As Integer = 0, tttDraws As Integer = 0
    Dim bshipWins As Integer = 0, bshipLosses As Integer = 0

    Sub Main()
        Dim choice As Integer = 0
        Dim running As Boolean = True

        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("                INITIALIZING ARCADE-X SYSTEM              ")
        Console.WriteLine("==========================================================")
        
        ' --- CRASHLESS NAME VALIDATION ---
        Dim validName As Boolean = False
        While Not validName
            Console.Write(" >> PLEASE ENTER YOUR PLAYER NAME: ")
            Dim inputName As String = Console.ReadLine()
            
            If String.IsNullOrWhiteSpace(inputName) Then
                Console.WriteLine(" [!] Name cannot be empty! Please enter a valid name." & Environment.NewLine)
            ElseIf Not Regex.IsMatch(inputName, "^[a-zA-Z ]+$") Then
                Console.WriteLine(" [!] Numbers/Symbols are not allowed! Please enter alphabets only." & Environment.NewLine)
            Else
                playerName = inputName.Trim()
                validName = True
            End If
        End While

        While running
            Console.Clear()
            ' --- RETRO MENU DESIGN ---
            Console.WriteLine("==========================================================")
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * *")
            Console.WriteLine("   ____  _____ _____ ____   ___     _   _ _   _ ____      ")
            Console.WriteLine("  |  _ \| ____|_   _|  _ \ / _ \   | | | | | | | __ )     ")
            Console.WriteLine("  | |_) |  _|   | | | |_) | | | |  | |_| | | | |  _ \     ")
            Console.WriteLine("  |  _ <| |___  | | |  _ <| |_| |  |  _  | |_| | |_) |    ")
            Console.WriteLine("  |_| \_\_____| |_| |_| \_\\___/   |_| |_|\___/|____/     ")
            Console.WriteLine("                                                            ")
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * * * *")
            Console.WriteLine("==========================================================")
            Console.WriteLine(" CURRENT ACTIVE PILOT: " & playerName.ToUpper())
            Console.WriteLine("----------------------------------------------------------")
            Console.WriteLine("  [1] Rock, Paper, Scissors (Instant Arena Match)")
            Console.WriteLine("  [2] Tic-Tac-Toe Arena (Vs Computer OR Vs Guest)")
            Console.WriteLine("  [3] Battleship Commander (Tactical Naval Combat 🚀)")
            Console.WriteLine("  [4] View Current Session Scoreboard/Stats")
            Console.WriteLine("  [5] Exit Arcade System")
            Console.WriteLine("----------------------------------------------------------")
            Console.WriteLine("==========================================================")
            Console.Write(" >> ENTER YOUR CHOICE (1-5): ")

            Dim rawInput As String = Console.ReadLine()
            
            If Integer.TryParse(rawInput, choice) Then
                Select Case choice
                    Case 1
                        PlayRockPaperScissors()
                    Case 2
                        PlayTicTacToe()
                    Case 3
                        PlayBattleship()
                    Case 4
                        ShowScoreboard()
                    Case 5
                        running = False
                        Console.Clear()
                        Console.WriteLine("==========================================================")
                        Console.WriteLine("   THANK YOU FOR VISITING THE RETRO ARCADE HUB! 👋")
                        Console.WriteLine("        Hope you had fun! Goodbye & Good Luck! 👍")
                        Console.WriteLine("==========================================================")
                    Case Else
                        Console.WriteLine(Environment.NewLine & " [!] Invalid choice! Please select a number between 1 and 5.")
                        Console.WriteLine(" Press Enter to try again...")
                        Console.ReadLine()
                End Select
            Else
                Console.WriteLine(Environment.NewLine & " [!] Invalid! Please enter choices in integers(numbers).")
                Console.WriteLine(" Press Enter to try again...")
                Console.ReadLine()
            End If
        End While
    End Sub

    ' --- 1. ROCK PAPER SCISSORS ---
    Sub PlayRockPaperScissors()
        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("              ROCK, PAPER, SCISSORS ARENA                 ")
        Console.WriteLine("==========================================================")
        Console.WriteLine("  [1] Rock  |  [2] Paper  |  [3] Scissors")
        
        Dim playerMove As Integer = 0
        Dim validMove As Boolean = False
        Dim rand As New Random()
        Dim moves() As String = {"", "ROCK", "PAPER", "SCISSORS"}
        
        While Not validMove
            Console.Write(" >> Choose your move (1-3): ")
            Dim moveInput As String = Console.ReadLine()
            
            If Integer.TryParse(moveInput, playerMove) Then
                If playerMove >= 1 AndAlso playerMove <= 3 Then
                    validMove = True
                Else
                    Console.WriteLine(" [!] Invalid choice! Please select between 1, 2, or 3.")
                End If
            Else
                Console.WriteLine(" [!] Please enter a valid option in numbers(integers).")
            End If
        End While

        Dim computerMove As Integer = rand.Next(1, 4)
        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("                      MATCH RESULT                        ")
        Console.WriteLine("==========================================================")
        Console.WriteLine("  👉 " & playerName.ToUpper() & " CHOSE: " & moves(playerMove))
        Console.WriteLine("  🤖 COMPUTER CHOSE: " & moves(computerMove))
        Console.WriteLine("----------------------------------------------------------")

        If playerMove = computerMove Then
            Console.WriteLine(" >> RESULT: IT'S A TIE! 🤝")
            rpsTies += 1
        ElseIf (playerMove = 1 AndAlso computerMove = 3) OrElse 
               (playerMove = 2 AndAlso computerMove = 1) OrElse 
               (playerMove = 3 AndAlso computerMove = 2) Then
            Console.WriteLine(" >> RESULT: YOU WIN! 🎉")
            rpsWins += 1
        Else
            Console.WriteLine(" >> RESULT: COMPUTER WINS! 😢")
            rpsLosses += 1
        End If

        Console.WriteLine("==========================================================")
        Console.WriteLine(" Press Enter to return to Arcade Main Menu...")
        Console.ReadLine()
    End Sub

    ' --- 2. TIC-TAC-TOE ---
    Sub PlayTicTacToe()
        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("                   TIC-TAC-TOE MODE                       ")
        Console.WriteLine("==========================================================")
        Console.WriteLine("  [1] Play with a Guest Friend (2-Player Local)")
        Console.WriteLine("  [2] Play against Smart AI Computer")
        Console.WriteLine("----------------------------------------------------------")
        
        Dim modeChoice As Integer = 0
        Dim validMode As Boolean = False
        While Not validMode
            Console.Write(" >> Select your arena mode (1-2): ")
            Dim modeInput As String = Console.ReadLine()
            If Integer.TryParse(modeInput, modeChoice) AndAlso (modeChoice = 1 OrElse modeChoice = 2) Then
                validMode = True
            Else
                Console.WriteLine(" [!] Invalid! Enter 1 for Guest or 2 for Computer.")
            End If
        End While

        If modeChoice = 1 Then
            Dim validGuest As Boolean = False
            While Not validGuest
                Console.Write(" >> Enter Guest Player Name: ")
                Dim gInput As String = Console.ReadLine()
                If Not String.IsNullOrWhiteSpace(gInput) AndAlso Regex.IsMatch(gInput, "^[a-zA-Z ]+$") Then
                    guestName = gInput.Trim()
                    validGuest = True
                Else
                    Console.WriteLine(" [!] Invalid name! Please use alphabets only.")
                End If
            End While
        Else
            guestName = "AI-Computer"
        End If

        Dim board() As Char = {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c}
        Dim turnCounter As Integer = 1
        Dim choice As Integer
        Dim flag As Integer = 0 
        Dim rand As New Random()

        Do
            Console.Clear()
            Console.WriteLine("==========================================================")
            Console.WriteLine("                   TIC-TAC-TOE ARENA                      ")
            Console.WriteLine("==========================================================")
            Console.WriteLine("      Player 1 [" & playerName & " - X]  VS  Player 2 [" & guestName & " - O]")
            Console.WriteLine("----------------------------------------------------------")
            
            Console.WriteLine("                     │     │     ")
            Console.WriteLine("                  " & board(1) & "  │  " & board(2) & "  │  " & board(3))
            Console.WriteLine("                ─────┼─────┼─────")
            Console.WriteLine("                     │     │     ")
            Console.WriteLine("                  " & board(4) & "  │  " & board(5) & "  │  " & board(6))
            Console.WriteLine("                ─────┼─────┼─────")
            Console.WriteLine("                     │     │     ")
            Console.WriteLine("                  " & board(7) & "  │  " & board(8) & "  │  " & board(9))
            Console.WriteLine("                     │     │     ")
            Console.WriteLine("----------------------------------------------------------")

            Dim isPlayerTurn As Boolean = (turnCounter Mod 2 <> 0)

            If isPlayerTurn Then
                Dim validSpot As Boolean = False
                While Not validSpot
                    Console.Write(" >> " & playerName.ToUpper() & " (X), enter spot (1-9): ")
                    Dim spotInput As String = Console.ReadLine()
                    
                    If Integer.TryParse(spotInput, choice) AndAlso choice >= 1 AndAlso choice <= 9 Then
                        If board(choice) <> "X"c AndAlso board(choice) <> "O"c Then
                            board(choice) = "X"c
                            turnCounter += 1
                            validSpot = True
                        Else
                            Console.WriteLine(" [!] Spot already taken!")
                        End If
                    Else
                        Console.WriteLine(" [!] Invalid choice! Enter a number between 1 and 9.")
                    End If
                End While
            Else
                If modeChoice = 1 Then
                    Dim validSpot As Boolean = False
                    While Not validSpot
                        Console.Write(" >> " & guestName.ToUpper() & " (O), enter spot (1-9): ")
                        Dim spotInput As String = Console.ReadLine()
                        
                        If Integer.TryParse(spotInput, choice) AndAlso choice >= 1 AndAlso choice <= 9 Then
                            If board(choice) <> "X"c AndAlso board(choice) <> "O"c Then
                                board(choice) = "O"c
                                turnCounter += 1
                                validSpot = True
                            Else
                                Console.WriteLine(" [!] Spot already taken!")
                            End If
                        Else
                            Console.WriteLine(" [!] Invalid choice! Enter a number between 1 and 9.")
                        End If
                    End While
                Else
                    Dim aiMadeMove As Boolean = False
                    Console.WriteLine(" 🤖 Computer is thinking...")
                    Threading.Thread.Sleep(600)
                    
                    While Not aiMadeMove
                        Dim aiChoice As Integer = rand.Next(1, 10)
                        If board(aiChoice) <> "X"c AndAlso board(aiChoice) <> "O"c Then
                            board(aiChoice) = "O"c
                            turnCounter += 1
                            aiMadeMove = True
                        End If
                    End While
                End If
            End If

            flag = CheckWin(board)
        Loop While flag = 0

        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("                    MATCH COMPLETED!                      ")
        Console.WriteLine("==========================================================")
        Console.WriteLine("                  " & board(1) & "  │  " & board(2) & "  │  " & board(3))
        Console.WriteLine("                ─────┼─────┼─────")
        Console.WriteLine("                  " & board(4) & "  │  " & board(5) & "  │  " & board(6))
        Console.WriteLine("                ─────┼─────┼─────")
        Console.WriteLine("                  " & board(7) & "  │  " & board(8) & "  │  " & board(9))
        Console.WriteLine("----------------------------------------------------------")

        If flag = 1 Then
            Dim winnerIndex As Integer = If(turnCounter Mod 2 = 0, 1, 2)
            If winnerIndex = 1 Then
                Console.WriteLine("      🎉 MATCH OVER: " & playerName.ToUpper() & " Wins! 🎉")
                tttWins += 1
            Else
                Console.WriteLine("      🎉 MATCH OVER: " & guestName.ToUpper() & " Wins! 🎉")
                tttLosses += 1
            End If
        Else
            Console.WriteLine("      🤝 MATCH OVER: It's a tough DRAW! 🤝")
            tttDraws += 1
        End If
        Console.WriteLine("==========================================================")
        Console.WriteLine(" Press Enter to return to Arcade Main Menu...")
        Console.ReadLine()
    End Sub

    Function CheckWin(b() As Char) As Integer
        If b(1) = b(2) AndAlso b(2) = b(3) Then Return 1
        If b(4) = b(5) AndAlso b(5) = b(6) Then Return 1
        If b(7) = b(8) AndAlso b(8) = b(9) Then Return 1
        If b(1) = b(4) AndAlso b(4) = b(7) Then Return 1
        If b(2) = b(5) AndAlso b(5) = b(8) Then Return 1
        If b(3) = b(6) AndAlso b(6) = b(9) Then Return 1
        If b(1) = b(5) AndAlso b(5) = b(9) Then Return 1
        If b(3) = b(5) AndAlso b(5) = b(7) Then Return 1
        
        If b(1) <> "1"c AndAlso b(2) <> "2"c AndAlso b(3) <> "3"c AndAlso
           b(4) <> "4"c AndAlso b(5) <> "5"c AndAlso b(6) <> "6"c AndAlso
           b(7) <> "7"c AndAlso b(8) <> "8"c AndAlso b(9) <> "9"c Then
            Return -1
        End If
        Return 0
    End Function

    ' --- 3. HARDCORE GAME: BATTLESHIP COMMANDER (4x4 GRID) ---
    Sub PlayBattleship()
        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("             ⚓ BATTLESHIP COMMANDER ⚓                   ")
        Console.WriteLine("==========================================================")
        Console.WriteLine(" Enemy has deployed 3 hidden warships on a 4x4 ocean grid.")
        Console.WriteLine(" Tactical Objective: Destroy all 3 ships using 7 missiles!")
        Console.WriteLine("==========================================================")

        ' 0 = Empty Ocean (~), 1 = Hidden Ship, 2 = Missed Shot (M), 3 = Hit Ship (H)
        Dim grid(3, 3) As Integer
        Dim rand As New Random()
        Dim shipsPlaced As Integer = 0

        ' Place 3 random ships secretly
        While shipsPlaced < 3
            Dim r As Integer = rand.Next(0, 4)
            Dim c As Integer = rand.Next(0, 4)
            If grid(r, c) = 0 Then
                grid(r, c) = 1
                shipsPlaced += 1
            End If
        End While

        Dim missilesLeft As Integer = 7
        Dim shipsDestroyed As Integer = 0
        Dim gameWon As Boolean = False

        While missilesLeft > 0 AndAlso shipsDestroyed < 3
            ' Render Ocean Map Matrix
            Console.WriteLine(Environment.NewLine & "    COL:  1   2   3   4")
            Console.WriteLine("         ---------------")
            For i As Integer = 0 To 3
                Console.Write(" ROW " & (i + 1) & ": ")
                For j As Integer = 0 To 3
                    If grid(i, j) = 2 Then
                        Console.Write("[M] ") ' Miss
                    ElseIf grid(i, j) = 3 Then
                        Console.Write("[💥] ") ' Hit
                    Else
                        Console.Write("[~] ") ' Hidden/Water
                    End If
                End For
                Console.WriteLine()
            Next
            Console.WriteLine("         ---------------")
            Console.WriteLine(" 🎯 Target Progress: " & shipsDestroyed & "/3 Ships Sunk | 🚀 Torpedoes Left: " & missilesLeft)

            ' Input Coordinates
            Dim targetRow As Integer = -1
            Dim targetCol As Integer = -1
            Dim validInput As Boolean = False

            While Not validInput
                Console.Write(" >> Target ROW (1-4): ")
                Dim rIn As String = Console.ReadLine()
                Console.Write(" >> Target COLUMN (1-4): ")
                Dim cIn As String = Console.ReadLine()

                If Integer.TryParse(rIn, targetRow) AndAlso Integer.TryParse(cIn, targetCol) Then
                    If targetRow >= 1 AndAlso targetRow <= 4 AndAlso targetCol >= 1 AndAlso targetCol <= 4 Then
                        targetRow -= 1 ' Convert to 0-index
                        targetCol -= 1
                        
                        If grid(targetRow, targetCol) = 2 OrElse grid(targetRow, targetCol) = 3 Then
                            Console.WriteLine(" [!] Coordinates already attacked! Pick another target.")
                        Else
                            validInput = True
                        End If
                    Else
                        Console.WriteLine(" [!] Invalid coordinates! Grid size is strictly 1 to 4.")
                    End If
                Else
                    Console.WriteLine(" [!] Please enter integer index numbers only.")
                End If
            End While

            ' Fire Missile Logic
            Console.Clear()
            Console.WriteLine("==========================================================")
            Console.WriteLine("                  TACTICAL COMBAT REPORT                  ")
            Console.WriteLine("==========================================================")
            Console.WriteLine(" >> Launching missile at Row " & (targetRow + 1) & ", Column " & (targetCol + 1) & "...")
            Threading.Thread.Sleep(500)

            If grid(targetRow, targetCol) = 1 Then
                Console.WriteLine(" >> 🔥 DIRECT HIT! You successfully blew up an enemy vessel! 🔥")
                grid(targetRow, targetCol) = 3
                shipsDestroyed += 1
            Else
                Console.WriteLine(" >> 🌊 SPLASH! Missile hit open water. Target missed.")
                grid(targetRow, targetCol) = 2
            End If
            missilesLeft -= 1
            Console.WriteLine("==========================================================")
        End While

        ' Match Finalization
        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("                 OPERATION TERMINATED                     ")
        Console.WriteLine("==========================================================")
        
        If shipsDestroyed = 3 Then
            Console.WriteLine(" 🎉 VICTORY! Tactical brilliance. You cleared the sector! 🎉")
            bshipWins += 1
        Else
            Console.WriteLine(" 😢 DEFEAT! Ammo depleted. Enemy fleet escaped.")
            bshipLosses += 1
        End If

        ' Show final true locations of remaining enemy ships
        Console.WriteLine(Environment.NewLine & " FINAL RECONNAISSANCE MAP (Actual Ship Locations):")
        Console.WriteLine("    COL:  1   2   3   4")
        For i As Integer = 0 To 3
            Console.Write(" ROW " & (i + 1) & ": ")
            For j As Integer = 0 To 3
                If grid(i, j) = 1 Then
                    Console.Write("[⛵] ") ' Survived Ship
                ElseIf grid(i, j) = 3 Then
                    Console.Write("[💥] ") ' Sunk Ship
                Else
                    Console.Write("[~] ")
                End If
            End For
            Console.WriteLine()
        Next
        
        Console.WriteLine("==========================================================")
        Console.WriteLine(" Press Enter to return to Arcade Main Menu...")
        Console.ReadLine()
    End Sub

    ' --- 4. SCOREBOARD ---
    Sub ShowScoreboard()
        Console.Clear()
        Console.WriteLine("==========================================================")
        Console.WriteLine("             SYSTEM PERFORMANCE SCOREBOARD                ")
        Console.WriteLine("==========================================================")
        Console.WriteLine(" OPERATOR PILOT: " & playerName.ToUpper())
        Console.WriteLine("----------------------------------------------------------")
        Console.WriteLine(" 1. ROCK, PAPER, SCISSORS STATUS:")
        Console.WriteLine("    • Total Rounds Won:  " & rpsWins)
        Console.WriteLine("    • Total Rounds Lost: " & rpsLosses)
        Console.WriteLine("    • Total Tied Rounds: " & rpsTies)
        Console.WriteLine("----------------------------------------------------------")
        Console.WriteLine(" 2. TIC-TAC-TOE ARENA STATS (Vs AI / Guest):")
        Console.WriteLine("    • Wins:   " & tttWins)
        Console.WriteLine("    • Losses: " & tttLosses)
        Console.WriteLine("    • Draws:  " & tttDraws)
        Console.WriteLine("----------------------------------------------------------")
        Console.WriteLine(" 3. BATTLESHIP NAVAL COMBAT STATS:")
        Console.WriteLine("    • Fleets Destroyed (Wins): " & bshipWins)
        Console.WriteLine("    • Fleet Escapes (Losses):  " & bshipLosses)
        Console.WriteLine("==========================================================")
        Console.WriteLine(" Press Enter to return to Arcade Main Menu...")
        Console.ReadLine()
    End Sub
End Module