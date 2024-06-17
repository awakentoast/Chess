using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;

public class King(PieceColour pieceColour) : Piece(pieceColour, PieceType.King)
{
    public override List<Point> GetValidMoves(Board board, Piece piece, Point from)
    {
        var possibleMoves = Cardinal.GetAllFieldsInDirections(from, true);
        possibleMoves = possibleMoves.Concat(Diagonal.GetAllFieldsInDirections(from, true)).ToList();

        return (from possibleMoveDirection in possibleMoves 
            from move in possibleMoveDirection 
            let target = board.GetField(move).piece 
            where piece.GetOtherColour() == target.PieceColour || target.PieceColour == PieceColour.None 
            select move).ToList();
    }
}