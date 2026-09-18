public abstract class BoardGenerator
{
    protected string? seed;
    protected Board board;

    public abstract string GenerateSeed();
    public abstract Board Generate();
    public abstract Board Generate(string seed);

}