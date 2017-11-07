using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe {
	public partial class Form1 : Form {
		private const int rows = 3;
		private const int columns = 3;
		private const int cellSize = 100;
		private const int boardHeight = cellSize * rows;
		private const int boardLength = cellSize * columns;

		public static int Rows { get { return rows;	} }
		public static int Columns { get { return columns; } }
		public static int CellSize { get { return cellSize; } }

		private PieceTemplate.Piece piece = PieceTemplate.Piece.X;
		private PieceTemplate.Piece[,] cell = new PieceTemplate.Piece[rows, columns];
		private PieceTemplate pieceTemplate;
		private int cellX, cellY;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Pen pen = new Pen(Color.Black, 5);
			for(int x = CellSize; x < boardLength; x += CellSize) {
				e.Graphics.DrawLine(pen, x, 0, x, boardLength);
			}
			for(int y = CellSize; y < boardHeight; y += CellSize) {
				e.Graphics.DrawLine(pen, 0, y, boardHeight, y);
			}

			for(int x = 0; x < rows; x++) {
				for(int y = 0; y < columns; y++) {
					if(cell[x, y] == PieceTemplate.Piece.X) {
						pieceTemplate = new X(x, y);
						pieceTemplate.DrawPiece(e.Graphics);
					}
					if(cell[x, y] == PieceTemplate.Piece.O) {
						pieceTemplate = new O(x, y);
						pieceTemplate.DrawPiece(e.Graphics);
					}
				}
			}
		}

		public void CheckForWinner(int x, int y, PieceTemplate.Piece p) {
			int row = 0, column = 0, diagnal = 0, antiDiagnal = 0;
			for(int i = 0; i < Rows; i++) {
				if(cell[x, i] == p) row++;
				if(cell[i, y] == p) column++;
				if(cell[i, i] == p) diagnal++;
				if(cell[i, Rows - i - 1] == p) antiDiagnal++;
			}
			if(row == 3 || column == 3 || diagnal == 3 || antiDiagnal == 3) {
				Console.WriteLine(p + " is winner");
			}
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e) {
			getMousePosition(e);
		}

		private void getMousePosition(MouseEventArgs e) {
			cellX = e.X;
			cellY = e.Y;
			cellX /= CellSize;
			cellY /= CellSize;

			Console.WriteLine(e.X + "," + e.Y);
			Console.WriteLine(cellX + "," + cellY);

			SetCell(cellX, cellY, piece);
		}

		private void SetCell(int x, int y, PieceTemplate.Piece p) {
			if(cell[x, y] == PieceTemplate.Piece.empty) {
				cell[x, y] = piece;
				Console.WriteLine("cell set");
				CheckForWinner(x, y, p);
				Invalidate(); // Causes graphics to update
				if(p == PieceTemplate.Piece.X) {
					piece = PieceTemplate.Piece.O;
				}
				if(p == PieceTemplate.Piece.O) {
					piece = PieceTemplate.Piece.X;
				}
			}
		}
	}
}
