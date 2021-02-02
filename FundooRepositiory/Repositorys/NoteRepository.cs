using FundooModel.Models;
using FundooRepositiory.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepositiory.Repositorys
{
    public class NoteRepository : INoteRepository
    {
        private readonly FundooContext fundooContext;

        /// <summary>
        /// Constructor to Initializing FundooContext
        /// </summary>
        /// <param name="fundooContext">fundooContext</param>
        public NoteRepository(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public bool AddNote(NoteModel noteModel)
        {
            try
            {
                fundooContext.NoteTable.Add(noteModel);
                var note = fundooContext.SaveChanges();
                if (note > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NoteModel> RetriveAllNotes()
        {
            try
            {
                IEnumerable<NoteModel> result = fundooContext.NoteTable.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NoteModel RetrieveNotesById(int id)
        {
            try
            {
                NoteModel notes = this.fundooContext.NoteTable.Where(x => x.NoteId == id).SingleOrDefault();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveNote(int noteId)
        {
            try
            {
                var userData = fundooContext.NoteTable.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (userData != null)
                {
                    fundooContext.NoteTable.Remove(userData);
                    fundooContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateNotes(NoteModel model)
        {
            try
            {
                if (model.NoteId != 0)
                {
                    fundooContext.Entry(model).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CheckPin(int id)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == id).SingleOrDefault();
                if (note.Pin == false)
                {
                    note.Pin = true;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string pin= "PIN";
                    return pin;
                }
                else
                {
                    note.Pin = false;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string unpin = "UNPIN";
                    return unpin;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CheckArchive(int id)
        {
            try
            {
                var note = fundooContext.NoteTable.Where(x => x.NoteId == id).SingleOrDefault();
                if (note.Archive == false)
                {
                    note.Archive = true;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string acrch = "ARCHIVE";
                    return acrch;
                }
                else
                {
                    note.Archive = false;
                    fundooContext.Entry(note).State = EntityState.Modified;
                    fundooContext.SaveChanges();
                    string unacrch = "UNARCHIVE";
                    return unacrch;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


