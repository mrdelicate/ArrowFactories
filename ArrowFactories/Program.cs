while (true)
{
    Console.WriteLine("---------------------------------------------------------------------------------------");
    Console.WriteLine("                          Vin Fletcher's Arrow Factory");
    Console.WriteLine("---------------------------------------------------------------------------------------");
    Console.WriteLine("\nVin smiles and asks, \"Welcome!  Lot's of great arrows here, I even do custom");
    Console.WriteLine("jobs!  Here is the catalogue, when you are ready to order just tell me the");
    Console.WriteLine("number of the item you'd like to order.\"\n");
    Console.WriteLine("-----------------");
    Console.WriteLine("1. Elite Arrow\n2. Beginner Errow\n3. Marksman Arrow\n4. Custom Arrow");
    Console.WriteLine("-----------------");
    Console.Write("Selection: ");
    string input = Console.ReadLine();
    bool valid = int.TryParse(input, out int selection);
    Arrow arrow = new(ArrowHead.Steel, 60, FletchingType.Plastic);
    while (true)
    {
        if (valid && (selection == 1 || selection == 2 || selection == 3 || selection == 4))
        {
            if (selection == 1)
            {
                arrow = Arrow.CreateEliteArrow();
                break;
            }
            if (selection == 2)
            {
                arrow = Arrow.CreateBeginnerArrow();
                break;
            }
            if (selection == 3)
            {
                arrow = Arrow.CreateMarksmanArrow();
                break;
            }
            if (selection == 4)
            {
                arrow = Arrow.CreateCustomArrow();
                break;
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
            continue;
        }
    }
    Console.WriteLine($"Alright, here you go, {arrow.Description}.\nThat will be {arrow.Cost} gold, please!");
    Console.ReadKey();
    Console.Clear();
}

class Arrow
{
    private ArrowHead ArrowHead { get; init; }
    private string ArrowHeadString { get; }
    private int ShaftLength { get; init; }
    private FletchingType FletchingType { get; init; }
    private string FletchingTypeString { get; }
    public string Description { get; }
    public float Cost { get; }

    public Arrow()
    {
        ArrowHead = PromptForArrowHead();
        ArrowHeadString = GetArrowHeadString(ArrowHead);
        ShaftLength = PromptForShaftLength(60, 100);
        FletchingType = PromptForFletchingType();
        FletchingTypeString = GetFletchingTypeString(FletchingType);
        Description = GetArrowDescription();
        Cost = CalculateCost();
    }

    public Arrow(ArrowHead arrowHead, int shaftLength, FletchingType fletchingType)
    {
        ArrowHead = arrowHead;
        ArrowHeadString = GetArrowHeadString(ArrowHead);
        ShaftLength = shaftLength;
        FletchingType = fletchingType;
        FletchingTypeString = GetFletchingTypeString(FletchingType);
        Description = GetArrowDescription();
        Cost = CalculateCost();
    }

    public static Arrow CreateCustomArrow() => new Arrow();

    public static Arrow CreateEliteArrow() => new(ArrowHead.Steel, 95, FletchingType.Plastic);

    public static Arrow CreateBeginnerArrow() => new(ArrowHead.Wood, 75, FletchingType.GooseFeathers);

    public static Arrow CreateMarksmanArrow() => new(ArrowHead.Steel, 65, FletchingType.GooseFeathers);

    static ArrowHead PromptForArrowHead()
    {
        while (true)
        {
            Console.Write("Select the number of the Arrowhead you want: 1)Steel 2)Wood 3)Obsidian. ");
            string input = Console.ReadLine();
            bool valid = int.TryParse(input, out int selection);
            if (valid && (selection == 1 || selection == 2 || selection == 3))
            {
                if (selection == 1)
                    return ArrowHead.Steel;
                else if (selection == 2)
                    return ArrowHead.Wood;
                else if (selection == 3)
                    return ArrowHead.Obsidian;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }
        }
    }

    static string GetArrowHeadString(ArrowHead arrowHead)
    {
        if (arrowHead == ArrowHead.Steel)
            return "a steel arrowhead";
        else if (arrowHead == ArrowHead.Wood)
            return "a wooden arrowhead";
        else if (arrowHead == ArrowHead.Obsidian)
            return "an obsidian arrowhead";
        else
            return "an unknown arrowhead";
    }

    static int PromptForShaftLength(int min, int max)
    {
        while (true)
        {
            Console.Write($"Select the shaft length in cm you want between {min} and {max}: ");
            string input = Console.ReadLine();
            bool valid = int.TryParse(input, out int selection);
            if (valid && selection >= min && selection <= max)
            {
                return selection;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }
        }
    }

    static FletchingType PromptForFletchingType()
    {
        while (true)
        {
            Console.Write("Select the number of the fletching you want: 1)Plastic 2)Turkey Feathers 3)Goose Feathers. ");
            string input = Console.ReadLine();
            bool valid = int.TryParse(input, out int selection);
            if (valid && (selection == 1 || selection == 2 || selection == 3))
            {
                if (selection == 1)
                    return FletchingType.Plastic;
                else if (selection == 2)
                    return FletchingType.TurkeyFeathers;
                else if (selection == 3)
                    return FletchingType.GooseFeathers;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }
        }
    }

    static string GetFletchingTypeString(FletchingType fletchingType)
    {
        if (fletchingType == FletchingType.GooseFeathers)
            return "goose feather fletching";
        else if (fletchingType == FletchingType.TurkeyFeathers)
            return "turkey feather fletching";
        else if (fletchingType == FletchingType.Plastic)
            return "plastic fletching";
        else
            return "unknown fletching";
    }

    string GetArrowDescription()
    {
        if (ArrowHead == ArrowHead.Steel && ShaftLength == 95 && FletchingType == FletchingType.Plastic)
            return $"an Elite Arrow, {ShaftLength} cm, with {ArrowHeadString}, and {FletchingTypeString}";
        else if (ArrowHead == ArrowHead.Wood && ShaftLength == 75 && FletchingType == FletchingType.GooseFeathers)
            return $"a Beginner Arrow, {ShaftLength} cm, with {ArrowHeadString}, and {FletchingTypeString}";
        else if (ArrowHead == ArrowHead.Steel && ShaftLength == 65 && FletchingType == FletchingType.GooseFeathers)
            return $"a Marksman Arrow, {ShaftLength} cm, with {ArrowHeadString}, and {FletchingTypeString}";
        else
            return $"a Custom Arrow, {ShaftLength} cm, with {ArrowHeadString}, and {FletchingTypeString}";
    }

    float CalculateCost()
    {
        float cost = 0;
        if (ArrowHead == ArrowHead.Steel)
            cost += 10;
        else if (ArrowHead == ArrowHead.Wood)
            cost += 3;
        else if (ArrowHead == ArrowHead.Obsidian)
            cost += 5;
        cost += .05f * ShaftLength;
        if (FletchingType == FletchingType.Plastic)
            cost += 10;
        else if (FletchingType == FletchingType.TurkeyFeathers)
            cost += 5;
        else if (FletchingType == FletchingType.GooseFeathers)
            cost += 3;
        return cost;
    }
}

enum ArrowHead
{
    Wood,
    Steel,
    Obsidian
}

enum FletchingType
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}