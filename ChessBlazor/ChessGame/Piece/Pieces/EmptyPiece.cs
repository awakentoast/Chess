namespace Chess.ChessGame.Pieces.Pieces;

public class EmptyPiece() : Piece(PieceColour.None, PieceType.Empty)
{
    public override List<Move> GetValidMoves(GameState gameState, Point from)
    {
        return [];
    }
}