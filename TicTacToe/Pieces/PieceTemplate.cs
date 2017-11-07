using System.Drawing;

namespace TicTacToe {
	public abstract class PieceTemplate {
		public enum Piece { empty, X, O };

		protected int originX, originY, width, height;

		public PieceTemplate(int x, int y) {
			originX = x * Form1.CellSize;
			originY = y * Form1.CellSize;
			width = Form1.CellSize;
			height = Form1.CellSize;
		}

		public abstract void DrawPiece(Graphics g);
	}
}
