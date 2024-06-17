namespace Chess.ChessGame.Pieces.PieceMovements;

public class Cardinal
{
    public static List<List<Point>> GetAllFieldsInDirections(Point from, bool isKing)
    {
        var possibleMoves = new List<List<Point>>();
        var xDirections = new List<int> { 0, 1, 0, -1 };
        var yDirections = new List<int> { -1, 0, 1, 0 };
        var range = isKing ? 1 : 8;
        for (var i = 0; i < 4; i++)
        {
            var possibleMovesLine = new List<Point>();
            var newPoint = new Point(from.X, from.Y);
            var xOffset = xDirections[i];
            var yOffset = yDirections[i];
            
            for (var j = 0; j < range; j++) 
            {
                newPoint = new Point(newPoint.X + xOffset, newPoint.Y + yOffset);
                if (!Chess.IsInBounds(newPoint)) 
                {
                    break;
                }
                
                possibleMovesLine.Add(newPoint);
            }
            possibleMoves.Add(possibleMovesLine);
        }

        return possibleMoves;
    }
}