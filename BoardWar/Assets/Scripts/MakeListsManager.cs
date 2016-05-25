using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class MakeListsManager : MonoBehaviour 
{
	private static Object resource;
	private static GameObject go;
	private static Cell cell;

	public static void MakeLists(Game game)
	{
		for(int h = 0; h < game.GetBoard().GetSize().horizontal; h++)
		{
			for(int v = 0; v < game.GetBoard().GetSize().vertical; v++)
			{
				cell = game.GetBoard ().GetCell (h, v);

				resource = Resources.Load ("Cell");

				go = Instantiate(resource) as GameObject;

				go.transform.GetChild(0).gameObject.AddComponent<go_Cell> ().SetScript(cell);

				go.transform.position = new Vector3 (
					v,
					go.transform.position.y, 
					h);

				CellManager cellManager = new CellManager (go);

				ListCellManager.listCell.Add (cellManager);

				if (!cell.IsEmpty ()) 
				{
					resource = Resources.Load (cell.GetPiece().GetName());

					go = Instantiate (resource) as GameObject;

					go.transform.GetChild(0).gameObject.AddComponent<go_Piece> ().SetScript(
						game, 
						cell.GetPiece());

					go.transform.position = new Vector3 (
						v,
						go.transform.position.y, 
						h);

					PieceManager pieceManager = new PieceManager (go);

					pieceManager.id = cell.GetPiece ().GetId ();

					ListPieceManager.listPiece.Add (pieceManager);

				}

			}
		}
	}

}
