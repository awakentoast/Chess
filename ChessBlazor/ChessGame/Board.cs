using Chess.ChessGame;
using Chess.ChessGame.Pieces;

public class Board(string fen)
{
    public const string InitialBoardStateFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

    private readonly List<List<Field>> _boardState = BoardStateFromFen(fen);

    private static List<List<Field>> BoardStateFromFen(string boardFen)
    {
        var board = new List<List<Field>>(8);
        var rank = 8;
        foreach (var rankString in boardFen.Split("/"))
        {
            var file = 1;
            var line = new List<Field>(8);
            foreach (var field in rankString.Split(""))
            {
                var isNumber = int.TryParse(field, out var number);
                if (isNumber)
                {
                    for (var i = 0; i < number; i++)
                    {
                        file++;
                        line.Add(new Field(Piece.Empty(), new Point(file, rank)));
                        
                    }
                }
                else
                {
                    file++;
                    var piece = Piece.FromFen(char.Parse(field));
                    line.Add(new Field(piece, new Point(file, rank)));
                }
            }

            board.Add(line);
            rank--;
        }

        return board;
    }

    public Board BoardFromFen(string fen)
    {
        BoardStateFromFen(fen);
        return this;
    }

    public void PlacePiece(Piece piece, Point point)
    {
        _boardState[point.Y][point.X].piece = piece;
    }

    public Field GetField(Point from)
    {
        return _boardState[from.Y][from.X];
    }
}