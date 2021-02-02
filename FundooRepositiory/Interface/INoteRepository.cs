using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepositiory.Interface
{
    public interface INoteRepository
    {
        public bool AddNote(NoteModel model);

        public NoteModel RetrieveNotesById(int id);

        public IEnumerable<NoteModel> RetriveAllNotes();

        public bool RemoveNote(int Id);

        public bool UpdateNotes(NoteModel model);

        public string CheckPin(int uid);

        public string CheckArchive(int uid);

    }
}
