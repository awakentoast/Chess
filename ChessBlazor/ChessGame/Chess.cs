namespace Chess.ChessGame;

public class Chess
{
    public static bool IsValidMove(Board board, Piece piece, Point from, Point to)
    {
        return piece.GetValidMoves(board, piece, from).Count(moveTo => moveTo == to) == 1;
    }

    public static bool IsInBounds(Point point)
    {
        return ((point.X < 0 || point.X > 7)|| (point.Y < 0 || point.Y > 7));
    }
}