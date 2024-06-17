namespace Chess.ChessGame.Pieces;

public class Field(Piece piece, Point point)
{
    public Piece Piece { get; set; } = piece;
    public Point Point { get; set; } = point;
}