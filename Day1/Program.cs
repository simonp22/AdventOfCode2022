// Read file
string input = File.ReadAllText("input.txt");

var elves = input.Split("\n\n");

List<int> elvesCalories = new List<int>();
foreach (string elf in elves) {
    int elfCalories = elf.Split("\n").Select(x => Convert.ToInt32(x)).Sum();
    elvesCalories.Add(elfCalories);
}
Console.WriteLine("Elf with the most calories has: " + elvesCalories.Max());
Console.WriteLine("Top 3 elves have: " + elvesCalories.OrderByDescending(x => x).Take(3).Sum());

Console.ReadKey();

