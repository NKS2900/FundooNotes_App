// ----------------------------------------------------------------------------------------------------
// <copyright file="INoteRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory.IRepositorys
{
    using FundooModel.Models;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;

    public interface INoteRepository
    {
        public bool AddNote(NoteModel model);

        public NoteModel RetrieveNotesById(int id);

        public IEnumerable<NoteModel> RetriveAllNotes();

        public bool RemoveNote(int Id);

        public bool UpdateNotes(NoteModel model);

        public string PinOrUnpin(int uid);

        public string IsArchive(int uid);

        public IEnumerable<NoteModel> RetriveArchiveNotes();

        public IEnumerable<NoteModel> RetriveTrashedNotes();

        public string RestoreTrash(int noteId);

        public bool DeletNoteForever(int noteId);

        public bool EmptyTrash();

        public bool ChangeColor(int id, string color);

        public bool SetReminder(int noteId, string dateTime);

        public IEnumerable<NoteModel> GetAllReminderNotes();

        public bool UnsetReminder(int noteId);

        public bool UploadImage(int noteId, IFormFile noteimage);

    }
}
