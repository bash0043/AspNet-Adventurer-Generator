using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Default : System.Web.UI.Page
    {
        List<string> AdventurerTypes = new List<string>()
        {
            "Mage",
            "Paladin",
        };

       
        private List<Adventurer> Adventurers
        {
            get
            {
                if (Session["adventurers"] == null)
                {
                    Session["adventurers"] = new List<Adventurer>();
                }
                return (List<Adventurer>)Session["adventurers"];
            }
            set
            {
                Session["adventurers"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string AdventurerType in AdventurerTypes)
                {
                    ddlType.Items.Add(new ListItem(AdventurerType));
                }
                Display_Adventurers(); 
            }
        }

        protected void Clear_Form()
        {
            txtName.Text = string.Empty;
            ddlType.SelectedIndex = 0;
        }

        protected void Display_Adventurers()
        {
            tblAdventurers.Rows.Clear();

            // header row
            TableRow headerRow = new TableRow();
            TableCell headerCell = new TableCell();
            headerCell.Text = "Adventurers";
            headerRow.Cells.Add(headerCell);
            tblAdventurers.Rows.Add(headerRow);

          
            for (int i = 0; i < Adventurers.Count; i++)
            {
                Adventurer adv = Adventurers[i];

                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                HyperLink advLink = new HyperLink();
                advLink.Text = $"{adv.Name} ({adv.Type})";
                advLink.NavigateUrl = $"Details.aspx?id={i}";

                cell.Controls.Add(advLink);
                row.Cells.Add(cell);
                tblAdventurers.Rows.Add(row);
            }
        }


        protected void btnCreateAdventurer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string name = txtName.Text;
                string type = ddlType.SelectedValue;

                Adventurer adventurer = null;

                switch (type)
                {
                    case "Mage":
                        adventurer = new Mage(name);
                        break;
                    case "Paladin":
                        adventurer = new Paladin(name);
                        break;
                }

                if (adventurer != null)
                {
                    Adventurers.Add(adventurer); 
                    Display_Adventurers();
                    Clear_Form();
                    
                }
            }
        }

    }
}
