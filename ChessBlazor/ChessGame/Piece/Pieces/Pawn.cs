using Chess.ChessGame;
using Chess.ChessGame.Pieces;
public class Pawn(PieceColour pieceColour) : Piece(pieceColour, PieceType.Pawn)
{
    public override List<Point> GetValidMoves(Board board, Piece piece, Point from)
    {
        var validMoves = new List<Point>();
        
        var count = HasMoved ? 1 : 2;
        var direction = pieceColour == PieceColour.White ? 1 : -1;
        
        for (var i = 0; i < count; i++)
        {
            var move = new Point(from.X, from.Y + direction);
            var target = board.GetField(move).piece;

            if (target.PieceColour == PieceColour.None)
            {
                validMoves.Add(move);
            }
        }
        
        var diagonalMoves = new List<Point>() {new Point(from.X - 1, from.Y + direction), new Point(from.X + 1, from.Y + direction)};

        validMoves.AddRange(
                from move in diagonalMoves 
                let target = board.GetField(move).piece 
                where target.PieceColour == piece.GetOtherColour() 
                select move);

        return validMoves;
    }
}