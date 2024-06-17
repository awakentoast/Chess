using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;

public class King(PieceColour pieceColour) : Piece(pieceColour, PieceType.King)
{
    public override List<Move> GetValidMoves(GameState gameState,Point from)
    {
        var possibleMoves = Cardinal.GetAllFieldsInDirections(from, true);
        possibleMoves = possibleMoves.Concat(Diagonal.GetAllFieldsInDirections(from, true)).ToList();

        return (
            from possibleMoveDirection in possibleMoves 
            from to in possibleMoveDirection 
            let target = gameState.Board.GetField(to).Piece 
            where GetOtherColour() == target.PieceColour || target.PieceColour == PieceColour.None 
            select new Move(@from, to, target))
            .ToList();
    }
}