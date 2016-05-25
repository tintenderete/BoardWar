using System;
using System.Collections.Generic;


namespace BoardGameApi
{
	class Tools_PlayerPlay 
	{
		
		static public Cell TakeActorAsCell(Actor actor, Board board)
		{
			
			if (actor.IsActorPiece())
			{

				Piece piece = (Piece)actor;
				return board.GetCell(piece);

			}
			else
			{
				return (Cell)actor;
			}
		}

	}
}
