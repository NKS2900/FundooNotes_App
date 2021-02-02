using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager
{
    public interface INoteManager
    {
        public bool AddNotes(NoteModel model);

        public IEnumerable<NoteModel> RetriveAllNotes();

        public NoteModel RetrieveNotes(int noteId);

        public bool RemoveNotes(int noteId);

        public bool UpdateNotes(NoteModel model);

        public string CheckPin(int noteId);

        public string CheckArchive(int noteId);
    }
}
