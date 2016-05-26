using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
	public abstract class Action
    {
		public Cell originCell;
		public List<Cell> destinyCells;
		public string name;
		public int manaCost;
		public int range;
		public float power;

        public static bool IsCellInAnyOrigin(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                if (cell == actionList[i].originCell)
                {
                    return true;
                }
            }

            return false;
        }

        public static Action FindActionByDestinyCell(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                for (int j = 0; j < actionList[i].destinyCells.Count; j++)
                {
                    if (actionList[i].destinyCells[j] == cell)
                    {
                        return actionList[i];
                    }
                }
            }

            return null;
        }

        public static Action FindActionByOriginCell(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                if (cell == actionList[i].originCell)
                {
                    return actionList[i];
                }
            }

            return null;
        }
			
        public Action(Cell currentCell)
        {
            this.originCell = currentCell;
            this.destinyCells = new List<Cell>();

        }
		public Action(Cell currentCell, List<Cell> nextCells)
		{
			this.originCell = currentCell;
			this.destinyCells = nextCells;
		}
		public Action(string name, Cell currentCell)
		{
			this.originCell = currentCell;
			this.destinyCells = new List<Cell>();
			this.name = name;
			SetStats ();
		}
		public Action(string name ,Cell currentCell, List<Cell> nextCells)
        {
            this.originCell = currentCell;
            this.destinyCells = nextCells;
			this.name = name;
			SetStats ();
        }

		public abstract void LookForMovements (Player currentPlayer, Board board);
		public abstract void Execute (Cell destinyCell, Board board);

        public bool IsCellInOrigin(Cell cell)
        { 
            if (originCell == cell)
            {
                return true;
            }
            return false;
        }

        public bool IsCellInDestiny(Cell cell)
        {
            foreach (Cell destinycell in destinyCells)
            {
                if (destinycell == cell)
                {
                    return true;
                }
            }
            return false;
        }


        public void NoPlayerCellsInDestiny(Player player)
        {
            int playerColor = player.GetColor();
            int pieceColor;

            List<Cell> cellsToRemove = new List<Cell>();

            for (int i = 0; i < destinyCells.Count; i++)
            {
                pieceColor = destinyCells[i].GetPiece().GetColor();

                if (pieceColor == playerColor)
                {
                    cellsToRemove.Add(destinyCells[i]);
                }
            }

            for (int i = 0; i < cellsToRemove.Count; i++)
            {
                destinyCells.Remove(cellsToRemove[i]);
            }
        }

		public Cell FindCellInDestiny(Cell cell)
		{
			foreach (Cell i_cell in destinyCells) 
			{
				if (cell == i_cell) 
				{
					return i_cell;
				}
			}

			return null;
		}

		private void SetStats()
		{
			power = GetPower ();
			range = GetRange ();
			manaCost = GetCost ();
		}

		private int GetRange()
		{
			List<SkillStats> skills = originCell.GetPiece ().GetSkills ();

			foreach (SkillStats skill in skills) 
			{
				if (skill.name == name) 
				{
					return skill.range;
				}
			}

			return 0;
		}

		private float GetPower()
		{
			List<SkillStats> skills = originCell.GetPiece ().GetSkills ();

			foreach (SkillStats skill in skills) 
			{
				if (skill.name == name) 
				{
					return skill.power;
				}
			}

			return 0f;
		}

		private int GetCost()
		{
			List<SkillStats> skills = originCell.GetPiece ().GetSkills ();

			foreach (SkillStats skill in skills) 
			{
				if (skill.name == name) 
				{
					return skill.cost;
				}
			}

			return 0;
		}

    }
}
