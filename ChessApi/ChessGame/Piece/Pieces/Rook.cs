using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.PieceMovements;


public class Rook(PieceColour pieceColour) : Piece(pieceColour, PieceType.Rook)
{
    public override List<Move> GetValidMoves(GameState gameState, Point from)
    {
        var possibleMoves = Cardinal.GetAllFieldsInDirections(from, false);
        var validMoves = new List<Move>();
            
        foreach (var possibleMovesDirection in possibleMoves)
        {
            foreach (var to in possibleMovesDirection)
            {
                var target = gameState.Board.GetField(from).Piece;
                if (target.PieceColour != PieceColour.None)
                {
                    break;
                }

                if (GetOtherColour() == PieceColour)
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