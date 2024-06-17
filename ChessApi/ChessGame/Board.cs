using Chess.ChessGame;
using Chess.ChessGame.Pieces;
using Chess.ChessGame.Pieces.Pieces;

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

    

    public List<Field> GetAllFieldsWithPiece(PieceColour pieceColour)
    {
        return (from fieldLine in _boardState
            from field in fieldLine
            where field.Piece.PieceType != PieceType.Empty
                  && field.Piece.PieceColour == pieceColour
            select field).ToList();
    }

    public Board BoardFromFen(string fen)
    {
        BoardStateFromFen(fen);
        return this;
    }

    public void PlacePiece(Field from, Field to)
    {
        _boardState[to.Point.Y][to.Point.X].Piece = from.Piece;
        _boardState[to.Point.Y][to.Point.X].Piece = new EmptyPiece();
    }

    public Field GetField(Point from)
    {
        return _boardState[from.Y][from.X];
    }
}