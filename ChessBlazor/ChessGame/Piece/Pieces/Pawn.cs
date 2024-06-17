using Chess.ChessGame;
using Chess.ChessGame.Pieces;
public class Pawn(PieceColour pieceColour) : Piece(pieceColour, PieceType.Pawn)
{
    public override List<Move> GetValidMoves(GameState gameState, Point from)
    {
        var validMoves = new List<Move>();

        var count = HasMoved ? 1 : 2;
        var direction = pieceColour == PieceColour.White ? 1 : -1;
        var moves = new List<Point>(count);

        for (var i = 0; i < count; i++)
        {
            moves.Add(new Point(from.X, from.Y + direction));
        }

        validMoves.AddRange(
            from to in moves
            let target = gameState.Board.GetField(to).Piece
            where target.PieceColour != GetOtherColour()
            select new Move(@from, to, target));
        
        var diagonalMoves = new List<Point>() {new Point(from.X - 1, from.Y + direction), new Point(from.X + 1, from.Y + direction)};

        validMoves.AddRange(
                from to in diagonalMoves 
                let target = gameState.Board.GetField(to).Piece 
                where target.PieceColour == GetOtherColour() ||
                      (gameState.IsEnPassante && gameState.EnPassantePoint == to)
                select new Move(@from, to, target));

        return validMoves;
    }
}