namespace Chess.ChessGame;

public class GameState
{
    private Board _board;
    private bool _isWhitesTurn;
    private bool whiteCanCastleKingSide;
    private bool whiteCanCastleQueenSide;
    private bool blackCanCastleKingSide;
    private bool blackCanCastleQueenSide;
    private bool isEnPassante;
    private Point enPassantePoint;
    private int halfMoves;
    private int fullMoves;
    
    public GameState()
    {
        _board = new Board(Board.InitialBoardStateFen);
        _isWhitesTurn = true;
    }
    
    public GameState FromFen(string fen)
    {
        var strings = fen.Split(" ");
        _board = _board.BoardFromFen(strings[0]);
        _isWhitesTurn = strings[1] == "w";
        
        return this;
    }
}