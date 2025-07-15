CharberryTree tree = new CharberryTree();

Notifier announcer = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true) {
    tree.MaybeGrow();
}

public class CharberryTree {
    private Random random = new Random();
    public bool Ripe { get; set;}

    public event Action? Ripened;

    public void MaybeGrow() {
        // only a tiny chance of ripening each time, but we try a lot!
        if (random.NextDouble() < 0.00000001 && !Ripe) {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

public class Notifier {
    public Notifier(CharberryTree charberryTree) {
        charberryTree.Ripened += OnRipened;
    }

    public void OnRipened() {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester {
    private int harvestCount;
    private CharberryTree charberryTree; 
    public Harvester(CharberryTree charberryTree)
    {
        this.charberryTree = charberryTree;
        charberryTree.Ripened += OnHarvested;
    }

    private void OnHarvested()
    {
        harvestCount++;
        charberryTree.Ripe = false;
        Console.WriteLine($"The tree has been harvested {harvestCount} times.");
    }
}