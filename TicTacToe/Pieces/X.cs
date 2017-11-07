using System;
using System.Drawing;

namespace TicTacToe {
	class X : PieceTemplate {
		private int endX;
		private int endY;
		private int secondLineStartX;
		private int secondLineStartY;
		private int secondLineEndX;
		private int secondLineEndY;

		public X(int x, int y) : base(x, y) {
			endX = originX + Form1.CellSize;
			endY = originY + Form1.CellSize;
			secondLineStartX = endX;
			secondLineStartY = originY;
			secondLineEndX = originX;
			secondLineEndY = endY;
		}

		public override void DrawPiece(Graphics g) {
			Pen pen = new Pen(Color.Black, 3f);
			g.DrawLine(pen, originX, originY, endX, endY);
			g.DrawLine(pen, secondLineStartX, secondLineStartY, secondLineEndX, secondLineEndY);
		}
	}
}
