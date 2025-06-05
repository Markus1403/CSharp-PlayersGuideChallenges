Sword BasicSword = new Sword(MaterialType.iron, GemstoneType.None, 0, 0);
var BasicGreatsword = BasicSword with { length = 100, crossguardWith = 30 };
var BasicSmallsword = BasicSword with { length = 80, crossguardWith = 15 };
Console.WriteLine($"Basic Greatsword: {BasicGreatsword}");
Console.WriteLine($"Basic Smallsword: {BasicSmallsword}");

public record Sword(MaterialType matetrial, GemstoneType Gemstone, int length, int crossguardWith);


public enum MaterialType { wood, bronze, iron, steel, binarium }


public enum GemstoneType { emerald, amber, sapphire, diamond, bitstone, None}