﻿using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static Obsługa_Apteki.Modele.ExpiredMedicines;

namespace Obsługa_Apteki.Entities
{
    public class DbActions
    {

        private AptekaTestDbContext _context = new AptekaTestDbContext();


        public AptekaTestDbContext GetContext()
        {
            return _context;
        }

        public List<Medicine> GetMedicines()
        {
            using (var context = new AptekaTestDbContext()) 
            {
                return context.Medicines.ToList();
            }
        }

        public List<Delivery> GetDeliveries()
        {
            using (var context = _context)
            {

                    return context.Deliveries.ToList();
            }
        }

        public List<Pharmaceut> GetPharmaceuts()
        {
            using (var context = new AptekaTestDbContext())
            {
                return context.Pharmaceuts.ToList();
            }
        }

        public List<Patient> GetPatients()
        {
            using (var context = _context)
            {
                return context.Patients.ToList();
            }
        }

        public List<Bill> GetBills()
        {
            using (var context = _context)
            {
                return context.Bills.ToList();
            }
        }

        public List<Doctor> GetDoctors()
        {
            using (var context = _context)
            {
                return context.Doctors.ToList();
            }
        }

        public List<ExpiredDate> GetExpiredDates()
        {
            using (var context = _context)
            {
                return context.ExpiredDates.ToList();
            }
        }

        public List<QuantityOnMagazine> GetQuantityOnMagazine()
        {
            using (var context = _context)
            {
                return context.QuantitiesOnMagazine.ToList();
            }
        }

        public List<Reciept> GetReciepts()
        {
            using (var context = _context)
            {
                return context.Reciepts.ToList();
            }
        }

        public List<string> GetColumnNames<T>() where T : class
        {
             var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
             var columnNames = properties.Select(p => p.Name).ToList();
             return columnNames;
        }

        public List<ExpiredMedicineInfo> GetExpiredMedicinesWithQuantities()
        {
            using (var context = _context)
            {
                var currentDate = DateTime.Now;

                var expiredMedicines = context.Medicines
                    .Select(m => new ExpiredMedicineInfo
                    {
                        MedicineId = m.MedicineId,
                        Name = m.Name,
                        Category = m.Category,
                        DateOfExpire = m.ExpiredDates.FirstOrDefault(ed => ed.DateofExpire < currentDate).DateofExpire,
                        ExpiredQuantity = m.QuantityOnMagazines
                                         .Where(q => q.ExpiredDates.Any(ed => ed.DateofExpire < currentDate))
                                         .Sum(q => q.Quantities)
                    })
                    .Where(em => em.DateOfExpire < currentDate)
                    .ToList();

                return expiredMedicines;
            }
        }
    }
}
