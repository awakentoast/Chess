using Chess.ChessGame.Pieces;

namespace Chess.ChessGame;

public class Chess
{
    public static bool DoTurn(GameState gameState, Field from, Field to)
    {
        if (!IsValidTurn(gameState, from, to))
        {
            return false;
        }
        
        gameState.Board.PlacePiece(from, to);
        gameState.OtherPlayersTurn();
        return true;
    }
    
    public static bool IsValidTurn(GameState gameState, Field from, Field to)
    {
        if (!IsValidMove(gameState, from, to))
        {
            return false;
        }

        if (!IsCheck(gameState))
        {
            return true;
        }
        
        return TurnPreventsCheck(gameState, from, to);
    }

    private static bool TurnPreventsCheck(GameState gameState, Field from, Field to)
    {
        gameState.Board.PlacePiece(from, to);

        var preventsCheck = !IsCheck(gameState);
        
        gameState.Board.PlacePiece(to, from);

        return preventsCheck;
    }
    
    public static bool IsInBounds(Point point)
    {
        return ((point.X < 0 || point.X > 7) || (point.Y < 0 || point.Y > 7));
    }
    
    private static bool IsValidMove(GameState gameState, Field from, Field to)
    {
        return from.Piece.GetValidMoves(gameState, from.Point).Count(move => move.To == to.Point) == 1;
    }

    private static bool IsCheck(GameState gameState)
    {
        var pieceColour = gameState.IsWhitesTurn ? PieceColour.White : PieceColour.Black;
        return gameState.Board.GetAllFieldsWithPiece(pieceColour)
            .SelectMany(field => field.Piece.GetValidMoves(gameState, field.Point))
            .Any(move => move.TargetPiece.PieceType == PieceType.King);
    }
}