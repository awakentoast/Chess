using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;


public class Knight(PieceColour pieceColour) : Piece(pieceColour, PieceType.Knight)
{
    public override List<Point> GetValidMoves(Board board, Piece piece, Point from)
    {
        var possibleMoves = LShape.GetAllFieldsInDirections(from);


        return (from move in possibleMoves 
            let target = board.GetField(@from).piece 
            where target.PieceColour == PieceColour.None || piece.GetOtherColour() == target.PieceColour 
            select move).ToList();
    }
}