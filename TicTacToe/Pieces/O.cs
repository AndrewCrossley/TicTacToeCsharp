using System;
using System.Drawing;

namespace TicTacToe {
	class O : PieceTemplate {
		public O(int x, int y) : base(x, y) {

		}

		public override void DrawPiece(Graphics g) {
			Pen pen = new Pen(Color.Black, 5);
			g.DrawEllipse(pen, originX, originY, width, height);
		}
	}
}
