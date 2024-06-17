namespace Chess.ChessGame;

public class GameState
{
    public Board Board;
    public bool IsWhitesTurn;
    public bool WhiteCanCastleKingSide;
    public bool WhiteCanCastleQueenSide;
    public bool BlackCanCastleKingSide;
    public bool BlackCanCastleQueenSide;
    public bool IsEnPassante = false;
    public Point EnPassantePoint;
    public int HalfMoves;
    public int FullMoves;
    public int IsCheck;
    
    public GameState()
    {
        Board = new Board(Board.InitialBoardStateFen);
        IsWhitesTurn = true;
    }

    public void OtherPlayersTurn()
    {
        IsWhitesTurn = !IsWhitesTurn;
    }
    
    public GameState FromFen(string fen)
    {
        var strings = fen.Split(" ");
        Board = Board.BoardFromFen(strings[0]);
        IsWhitesTurn = strings[1] == "w";
        
        return this;
    }
}