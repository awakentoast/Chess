using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;


public class Queen(PieceColour pieceColour) : Piece(pieceColour, PieceType.Queen)
{
    public override List<Move> GetValidMoves(GameState gameState, Point from)
    {
        var possibleMoves = Cardinal.GetAllFieldsInDirections(from, false);
        possibleMoves = possibleMoves.Concat(Diagonal.GetAllFieldsInDirections(from, false)).ToList();
        var validMoves = new List<Move>();
        
        foreach (var possibleMoveDirection in possibleMoves)
        {
            foreach (var to in possibleMoveDirection)
            {
                var target = gameState.Board.GetField(to).Piece;
                if (target.PieceColour != PieceColour.None)
                {
                    break;
                }
                
                if (GetOtherColour() == target.PieceColour )
                {
                   validMoves.Add(new Move(@from, to, target));
                   break;
                }

                validMoves.Add(new Move(@from, to, target));
            }
        }

        return validMoves;
    }
}