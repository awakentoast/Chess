using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.Pieces;

public abstract class Piece(PieceColour pieceColour, PieceType pieceType)
{
    public PieceColour PieceColour { get; } = pieceColour;
    public PieceType PieceType { get; set; } = pieceType;
    public int PieceValue { get; set; } = CalculatePieceValue(pieceType);
    protected bool HasMoved { get; set; } = false;

    public abstract List<Point> GetValidMoves(Board board, Piece piece, Point from);

    public PieceColour GetOtherColour()
    {
        return PieceColour == PieceColour.White ? PieceColour.White : PieceColour.Black;
    }
    
    private static int CalculatePieceValue(PieceType pieceType)
    {
        return pieceType switch
        {
            PieceType.Empty => 0,
            PieceType.Pawn => 1,
            PieceType.Knight => 3,
            PieceType.Bishop => 3,
            PieceType.Rook => 5,
            PieceType.Queen => 9,
            PieceType.King => 0, // Typically, the King does not have a value in terms of points.
            _ => throw new ArgumentOutOfRangeException(nameof(pieceType), pieceType, null)
        };
    }

    public static Piece FromFen(char fenCharacter)
    {
        var pieceColour = char.IsUpper(fenCharacter) ? PieceColour.White : PieceColour.Black;

        return (char.ToLower(fenCharacter)) switch
        {
            'p' => new Pawn(pieceColour),
            'n' => new Knight(pieceColour),
            'b' => new Bishop(pieceColour),
            'r' => new Rook(pieceColour),
            'q' => new Queen(pieceColour),
            'k' => new King(pieceColour),
            _ => throw new ArgumentException($"{fenCharacter} is not supported")
        };
    }
    
    public static Piece Empty()
    {
        return new Empty();
    }
}