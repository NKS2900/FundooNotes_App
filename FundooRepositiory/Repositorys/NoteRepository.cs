﻿using FundooModel.Models;
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
        public IEnumerable<NoteModel> RetrieveNotes()
        {
            try
            { 
                IEnumerable<NoteModel> notes = this.fundooContext.NoteTable;
                if (notes != null)
                {
                    return notes;
                }
                else
                {
                    return notes;
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}