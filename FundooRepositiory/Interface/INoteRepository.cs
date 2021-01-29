using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepositiory.Interface
{
    public interface INoteRepository
    {
        public bool AddNote(NoteModel model);

        public IEnumerable<NoteModel> RetrieveNotes();

        public bool RemoveNote(int Id);

        public bool UpdateNotes(NoteModel model);
    }
}
