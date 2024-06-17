namespace Chess.ChessGame.Pieces;

public class Field
{
    public Field(Piece piece, Point point)
    {
        this.piece = piece;
        this.point = point;
    }

    public Piece piece { get; set; }
    public Point point { get; set; }
}