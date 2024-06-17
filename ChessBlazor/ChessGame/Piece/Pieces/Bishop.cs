using Chess.ChessGame;
using Chess.ChessGame.Pieces;using Chess.ChessGame.Pieces.PieceMovements;

public class Bishop(PieceColour pieceColour) : Piece(pieceColour, PieceType.King)
{
    public override List<Point> GetValidMoves(Board board, Piece piece, Point from)
    {
        var possibleMoves = Diagonal.GetAllFieldsInDirections(from, false);
        var validMoves = new List<Point>();
        
        foreach (var possibleMovesDirection in possibleMoves)
        {
            foreach (var move in possibleMovesDirection)
            {
                var target = board.GetField(from).piece;
                if (target.PieceColour != PieceColour.None)
                {
                    break;
                }

                if (piece.GetOtherColour() == piece.PieceColour)
                {
                    validMoves.Add(move);
                    break;
                }
                
                validMoves.Add(move);
            }
        }

        return validMoves;
    }
}