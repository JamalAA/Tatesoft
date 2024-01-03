namespace Tatesoft.WebAPI.Entities;

public class Block
{
    public int Id { get; set; }
    public List<Paragraph> Paragraphs { get; set; }
    public List<Line> Lines { get; set; }
    public List<Word> Words { get; set; }
    public List<Character> Characters { get; set; }
    public int BlockNumber { get; set; }
    public string BlockType { get; set; }
    public int TextDirection { get; set; }
    public string Text { get; set; }
    public double Confidence { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Location Location { get; set; }
}

public class Character
{
    public int Id { get; set; }
    public string Font { get; set; }
    public int CharacterNumber { get; set; }
    public List<Choice> Choices { get; set; }
    public int TextDirection { get; set; }
    public string Text { get; set; }
    public double Confidence { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Location Location { get; set; }
}

public class Choice
{
    public int Id { get; set; }
}

public class ContentArea
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Units { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
}

public class Line
{
    public int Id { get; set; }
    public List<Word> Words { get; set; }
    public List<Character> Characters { get; set; }
    public int LineNumber { get; set; }
    public int TextDirection { get; set; }
    public string Text { get; set; }
    public double Confidence { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Location Location { get; set; }
}

public class Location
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Units { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
}

public class Paragraph
{
    public int Id { get; set; }
    public List<Line> Lines { get; set; }
    public List<Word> Words { get; set; }
    public List<Character> Characters { get; set; }
    public int ParagraphNumber { get; set; }
    public int TextDirection { get; set; }
    public string Text { get; set; }
    public double Confidence { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Location Location { get; set; }
}

public class Page
{
    public int Id { get; set; }
    public int Rotation { get; set; }
    public string Barcodes { get; set; }
    public string Tables { get; set; }
    public int WordCount { get; set; }
    public int PageNumber { get; set; }
    public double Confidence { get; set; }
    public List<Block> Blocks { get; set; }
    public List<Paragraph> Paragraphs { get; set; }
    public List<Line> Lines { get; set; }
    public List<Word> Words { get; set; }
    public List<Character> Characters { get; set; }
    public ContentArea ContentArea { get; set; }
    public int TextDirection { get; set; }
    public string Text { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Location Location { get; set; }
    public int CustomerId { get; set; } 

}

public class Word
{
    public int Id { get; set; }
    public List<Character> Characters { get; set; }
    public int WordNumber { get; set; }
    public string Font { get; set; }
    public int TextDirection { get; set; }
    public string Text { get; set; }
    public double Confidence { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Location Location { get; set; }
}
