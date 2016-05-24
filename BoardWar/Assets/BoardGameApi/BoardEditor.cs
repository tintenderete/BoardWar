﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class BoardTableEditor
    {
        Board board;
        int pointer;
        IPieceFactory pieceFactory;
        int[] pushCount; 
		Piece newPiece;

        public BoardTableEditor()
        {
            board = new Board(); 
        }

        public BoardTableEditor(int HorizontalSize, int VerticalSize, IPieceFactory newPieceFactory)
        {
            NewBoard(HorizontalSize, VerticalSize);

            pushCount = new int[VerticalSize];
            for (int i = 0; i < VerticalSize; i++)
            {
                pushCount[i] = 0;
            }

            this.pieceFactory = newPieceFactory; 
        }

        public void NewBoard(int HorizontalSize, int VerticalSize)
        {
            Cell[,] boardTable = new Cell[HorizontalSize, VerticalSize];
            board = new Board(boardTable, HorizontalSize, VerticalSize);
            PushAllNoPieces(board);
        }

        public Board GetBoard()
        {
            return board;
        }
        public int GetPointer()
        {
            return pointer;
        }

        public void SetPointerInLine(int line)
        {
            pointer = line;
        }

		public void PushPiece(int numOfPieces, string pieceName, int color)
        {
            Cell[,] board;

			newPiece = pieceFactory.MakePiece (pieceName, color);

            for (int i = 0; i < numOfPieces; i++)
            {
                board =  this.board.GetBoard();
				board[PushCount(), pointer].SetPiece(newPiece);
            }
        }

        private int FirstEmptyCell()
        {
            Cell[,] board = this.board.GetBoard();
            int horizontalSize = this.board.GetSize().horizontal;
            int posFirstCellEmpty = 0;

            for (int i = 0; i < horizontalSize; i++)
            {
                int color = board[i, pointer].GetPiece().GetColor();
                if (IsCellEmpty(color))
                {
                    posFirstCellEmpty = i;
                    return posFirstCellEmpty;
                }
            }

            return posFirstCellEmpty;
        }

        private bool IsCellEmpty(int color)
        {
            if (color == (int)Piece.colors.NoPiece)
            {
                return true;
            }
            return false;
        }

        private void PushAllNoPieces(Board board)
        {
            Cell[,] boardTable = board.GetBoard();
            Position size = board.GetSize();
            
            for (int v = 0; v < size.vertical; v++)
            {
                for (int h = 0; h < size.horizontal; h++)
                {
					boardTable[h, v] = new Cell(new Position(h, v), new NoPiece());
                }
            }
        }

        private int PushCount()
        {
            int pointer;

            pointer = pushCount[this.pointer];

            this.pushCount[this.pointer]++;

            return pointer;

        }


    }
}
