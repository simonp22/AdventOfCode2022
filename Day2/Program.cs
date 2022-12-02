// Read file
string[] rounds = File.ReadAllLines("input.txt");
int totalScore = 0;
int puzzle2totalScore = 0;

Dictionary<string, RockPaperScissors> enumMap = new Dictionary<string, RockPaperScissors>() {
    { "A", RockPaperScissors.Rock },
    { "B", RockPaperScissors.Paper },
    { "C", RockPaperScissors.Scissors },
    { "X", RockPaperScissors.Rock },
    { "Y", RockPaperScissors.Paper },
    { "Z", RockPaperScissors.Scissors },
};

Dictionary<RockPaperScissors, RockPaperScissors> winningPairs = new Dictionary<RockPaperScissors, RockPaperScissors>() {
    { RockPaperScissors.Rock, RockPaperScissors.Scissors },
    { RockPaperScissors.Paper, RockPaperScissors.Rock },
    { RockPaperScissors.Scissors, RockPaperScissors.Paper },
};

foreach (string round in rounds) {
    string[] roundParts = round.Split(" ");
    RockPaperScissors opponent = enumMap[roundParts[0]];
    RockPaperScissors player = enumMap[roundParts[1]];
    int outcomeScore = 0;
    if (opponent == player) outcomeScore = 3;
    if (opponent == winningPairs[player]) {
        outcomeScore = 6;
    }
    totalScore += outcomeScore + (int)player;


    // Puzzle 2
    int puzzle2OutcomeScore = 0;
    if (roundParts[1] == "Y") puzzle2OutcomeScore = 3;
    if (roundParts[1] == "Z") puzzle2OutcomeScore = 6;

    puzzle2totalScore += puzzle2OutcomeScore + CalculatePlayerScore(opponent, roundParts[1]);


}

Console.WriteLine("Puzzle 1: Total score, following strategy guide: " + totalScore);
Console.WriteLine("Puzzle 2: Total score, following strategy guide: " + puzzle2totalScore);


int CalculatePlayerScore(RockPaperScissors opponentPlay, string requiredOutcome) {
    if (requiredOutcome == "Y") return (int)opponentPlay;
    if (requiredOutcome == "X") {
        // Lose
        return (int)winningPairs[opponentPlay];
    } else {
        // Win 
        return (int)winningPairs.ToDictionary(x => x.Value, x => x.Key)[opponentPlay];
    }
}

enum RockPaperScissors {
    Rock = 1,
    Paper = 2,
    Scissors = 3
}