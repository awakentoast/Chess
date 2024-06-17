using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;


public class Knight(PieceColour pieceColour) : Piece(pieceColour, PieceType.Knight)
{
    public override List<Move> GetValidMoves(GameState gameState, Point from)
    {
        var possibleMoves = LShape.GetAllFieldsInDirections(from);


        return (
            from to in possibleMoves 
            let target = gameState.Board.GetField(@from).Piece 
            where target.PieceColour == PieceColour.None || GetOtherColour() == target.PieceColour 
            select new Move(@from, to, target))
            .ToList();
    }
}