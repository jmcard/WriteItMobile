using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class TagModel
    {

        private int idTag;

        public int IdTag
        {
            get { return idTag; }
            set { idTag = value; }
        }

        private string nomeTag;

        public string NomeTag
        {
            get { return nomeTag; }
            set { nomeTag = value; }
        }

        public TagModel(int idTag, string nomeTag)
        {
            IdTag = idTag;
            NomeTag = nomeTag;
        }

        public TagModel()
        {

        }
    }
}
