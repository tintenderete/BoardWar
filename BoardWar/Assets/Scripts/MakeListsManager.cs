using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class MakeListsManager : MonoBehaviour 
{
	private static Object resource;
	private static GameObject go;
	private static Cell cell;
	private static GameObject piecesAndCells = GameObject.Find("Piece&Cells");

	public static void MakeLists(Game game)
	{
		for(int v = 0; v < game.GetBoard().GetSize().vertical; v++)
		{
			for(int h = 0; h < game.GetBoard().GetSize().horizontal; h++)
			{
				cell = game.GetBoard ().GetCell (h, v);

				resource = Resources.Load ("Cell");

				go = Instantiate(resource) as GameObject;

				go.transform.GetChild(0).gameObject.AddComponent<go_Cell> ().SetScript(cell);

				go.transform.position = new Vector3 (
					h,
					go.transform.position.y, 
					v);
				
				go.transform.SetParent (piecesAndCells.transform);

				CellManager cellManager = new CellManager (go);
				cellManager.markedCell = go.transform.Find ("Marked").gameObject;

				ListCellManager.listCell.Add (cellManager);

				if (!cell.IsEmpty ()) 
				{
					resource = Resources.Load (cell.GetPiece().GetName());

					go = Instantiate (resource) as GameObject;

					go.transform.GetChild(0).gameObject.AddComponent<go_Piece> ().SetScript(
						game, 
						cell.GetPiece());

					go.transform.position = new Vector3 (
						h,
						go.transform.position.y, 
						v);
					
					if (cell.GetPiece ().GetColor () == (int)Piece.colors.Red) 
					{
						go.transform.Rotate (new Vector3(0, 180, 0));
					}

					go.transform.SetParent (piecesAndCells.transform);

					PieceManager pieceManager = new PieceManager (go);
					pieceManager.id = cell.GetPiece ().GetId ();
					pieceManager.SetStateBar (go.transform.GetChild(1).GetComponent<go_StateBar>());

					ListPieceManager.listPiece.Add (pieceManager);

				}

			}
		}
	}

}
