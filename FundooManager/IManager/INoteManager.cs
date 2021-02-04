// ----------------------------------------------------------------------------------------------------
// <copyright file="INoteManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;

    public interface INoteManager
    {
        public bool AddNotes(NoteModel model);

        public IEnumerable<NoteModel> RetriveAllNotes();

        public NoteModel RetrieveNotes(int noteId);

        public bool RemoveNotes(int noteId);

        public bool UpdateNotes(NoteModel model);

        public string PinOrUnpin(int noteId);

        public string IsArchive(int noteId);

        public IEnumerable<NoteModel> RetriveArchiveNotes();

        public IEnumerable<NoteModel> RetriveTrashedNotes();

        public string RestoreTrashed(int noteId);

        public bool DeletNoteForever(int noteId);

        public bool EmptyTrash();

        public bool ChangeColor(int id, string color);

        public bool SetReminder(int noteId, string dateTime);

        public IEnumerable<NoteModel> GetAllReminderNotes();

        public bool UnsetReminder(int noteId);

        public bool UploadImage(int noteId, IFormFile noteimage);
    }
}
