Pack pack = new Pack(10, 10.0f, 10.0f);
while (true) {
    
    Console.WriteLine($"Pack is currently at {pack.Size}/{pack.Size} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");
    Console.WriteLine("What would you like to add to you inventory");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("4 - Water");
    Console.WriteLine("5 - Food");
    Console.WriteLine("6 - Sword");
    int choice = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new FoodRations(),
        6 => new Sword()
    };
    if (!pack.Add(newItem))
        Console.WriteLine("Could not add this to the pack.");
}



public class InventoryItem {
    public float Weight { get; set; }
    public float Volume { get; set; }

    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }
}


public class Arrow : InventoryItem {
    public Arrow() : base(0.01f, 0.05f) { }
}


public class Bow : InventoryItem {
    public Bow() : base(1.0f, 4.0f) { }
}


public class Rope : InventoryItem {
    public Rope() : base(1.0f, 1.5f) { }
}

public class Water : InventoryItem {
    public Water() : base(2.0f, 3.0f) { }
}

public class FoodRations : InventoryItem {
    public FoodRations() : base(1.0f, 0.5f) { }
}

public class Sword : InventoryItem {
    public Sword() : base(5.0f, 3.0f) { }
}



public class Pack {
    public float MaxWeight {get; set;}
    public float MaxVolume {get; set;}
    public int Size; 



    private InventoryItem[] items;

    public Pack(int size, float maxWeight, float maxVolume) {
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        Size = size;

        items = new InventoryItem[size];
    }

    public float CurrentWeight {get; set;}
    public float CurrentVolume {get; set;}
    public bool Add(InventoryItem item) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                if (CurrentWeight + item.Weight <= MaxWeight && CurrentVolume + item.Volume <= MaxVolume) {
                    items[i] = item;
                    CurrentWeight += item.Weight;
                    CurrentVolume += item.Volume;

                    return true;
                }
                return false;
            }
        }
        return false;
    }
}
