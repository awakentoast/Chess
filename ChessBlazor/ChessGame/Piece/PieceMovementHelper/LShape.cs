namespace Chess.ChessGame.Pieces.PieceMovements;

public class LShape
{
    public static List<Point> GetAllFieldsInDirections(Point from)
    {
        var possibleMoves = new List<Point>();
        var xDirections = new List<int> { -1, 1, 2, 2, 1, -1, -2, -2 };
        var yDirections = new List<int> { -2, -2, -1, 1, 2, 2, 1, -1 };
        
        for (var i = 0; i < 8; i++)
        {
            var xOffset = xDirections[i];
            var yOffset = yDirections[i];
            while (true)
            {
                var point = new Point(from.X + xOffset, from.Y + yOffset);
                if (!Chess.IsInBounds(point)) 
                {
                    break;
                }
                
                possibleMoves.Add(point);
            }
        }

        return possibleMoves;
    }
}