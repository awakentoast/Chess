using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;


public class Queen(PieceColour pieceColour) : Piece(pieceColour, PieceType.Queen)
{
    public override List<Point> GetValidMoves(Board board, Piece piece, Point from)
    {
        var possibleMoves = Cardinal.GetAllFieldsInDirections(from, false);
        possibleMoves = possibleMoves.Concat(Diagonal.GetAllFieldsInDirections(from, false)).ToList();
        var validMoves = new List<Point>();
        
        foreach (var possibleMoveDirection in possibleMoves)
        {
            foreach (var move in possibleMoveDirection)
            {
                var target = board.GetField(move).piece;
                if (target.PieceColour != PieceColour.None)
                {
                    break;
                }
                
                if (piece.GetOtherColour() == target.PieceColour )
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