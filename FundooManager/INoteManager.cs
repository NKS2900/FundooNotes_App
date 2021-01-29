using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager
{
    public interface INoteManager
    {
        public bool AddNotes(NoteModel model);

        public IEnumerable<NoteModel> RetrieveNotes();

        public bool RemoveNotes(int noteId);

        public bool UpdateNotes(NoteModel model);
    }
}
