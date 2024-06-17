namespace Chess.ChessGame.Pieces.Pieces;

public class Empty() : Piece(PieceColour.None, PieceType.Empty)
{
    public override List<Point> GetValidMoves(Board board, Piece piece, Point from)
    {
        return [];
    }
}