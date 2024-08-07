﻿using Obsługa_Apteki.Modele;
using Obsługa_Apteki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static Obsługa_Apteki.Modele.ExpiredMedicines;
using ModeleReciept = Obsługa_Apteki.Modele.Reciept;
using ModelsReciept = Obsługa_Apteki.Models.Reciept;

namespace Obsługa_Apteki.Entities
{
    public class DbActions
    {

        private AptekaTestDbContext _context = new AptekaTestDbContext();


        public AptekaTestDbContext GetContext()
        {
            return _context;
        }

        public List<Modele.Medicine> GetMedicines()
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

        public List<Modele.Reciept> GetReciepts()
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

        public void AddToStock(Delivery delivery)
        {
            _context = new AptekaTestDbContext();
            foreach (var medicine in delivery.OrderedMedicines)
            {
                
                var existingStock = _context.Stocks
                                            .SingleOrDefault(q => q.MedicineId == medicine.MedicineId);

                if (existingStock != null)
                {
                    
                    existingStock.Quantity += medicine.Quantity;
                }
                else
                {
                    
                    var newStock = new QuantityOnMagazine
                    {
                        MedicineId = medicine.MedicineId,
                        Quantities = medicine.Quantity
                    };
                    _context.QuantitiesOnMagazine.Add(newStock);
                }
            }
            _context.SaveChanges();
        }

        public void RemoveFromStock(Bill bill)
        {
            foreach (var medicine in bill.Medicines) 
            {
                var existingStock = _context.Stocks.SingleOrDefault(p => p.MedicineId == medicine.MedicineId);
                if ( existingStock != null )
                {
                    existingStock.Quantity -= medicine.Quantity;
                }
                else
                {
                    MessageBox.Show("Brak wystarczającej ilości leku na magazynie");
                }
            }
            _context.SaveChanges();
        }

        public void RemoveDelivery(Delivery delivery)
        {
            _context = new AptekaTestDbContext();
                var existingDelivery = _context.Deliveries.SingleOrDefault(p => p.DeliveryId == delivery.DeliveryId);
                if (existingDelivery != null)
                {
                _context.Deliveries.Remove(existingDelivery);
                }
                else
                {
                    MessageBox.Show("Brak wystarczającej ilości leku na magazynie");
                }
            
            _context.SaveChanges();
        }

        public void RemoveReciept(Modele.Reciept reciept)
        {
            _context = new AptekaTestDbContext();
            var existingReciept = _context.Reciepts.SingleOrDefault(p => p.RecieptId == reciept.RecieptId);
            if(existingReciept != null)
            {
                _context.Reciepts.Remove(existingReciept);
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnej recepty");
            }

            _context.SaveChanges();
        }

        public void RemovePatient(Patient patient)
        {
            _context = new AptekaTestDbContext();
            var existingPatient = _context.Patients.SingleOrDefault(p => p.PatientId == patient.PatientId);
            if (existingPatient != null)
            {
                _context.Patients.Remove(existingPatient);
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego pacjenta");
            }

            _context.SaveChanges();
        }

        public void RemoveMedicine(Modele.Medicine medicine)
        {
            _context = new AptekaTestDbContext();
            var existingMedicine = _context.Medicines.SingleOrDefault(p => p.MedicineId == medicine.MedicineId);
            if (existingMedicine != null)
            {
                _context.Medicines.Remove(existingMedicine);
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego leku");
            }

            _context.SaveChanges();
        }

        public void RemovePharmaceut(Pharmaceut pharmaceut)
        {
            _context = new AptekaTestDbContext();
            var existingPharmaceut = _context.Pharmaceuts.SingleOrDefault(p => p.PharmaceutId == pharmaceut.PharmaceutId);
            if (existingPharmaceut != null)
            {
                _context.Pharmaceuts.Remove(existingPharmaceut);
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego leku");
            }

            _context.SaveChanges();
        }

        public void AddDeliveryWithMedicines(Delivery delivery, List<MedicineDelivery> medicineDeliveries)
        {
            using (var context = new AptekaTestDbContext())
            {
                context.Deliveries.Add(delivery);

                foreach (var medicineInDelivery in medicineDeliveries)
                {
                    // Upewnij się, że usuwasz wszelkie poprzednie referencje
                    medicineInDelivery.Delivery = null;
                    medicineInDelivery.Medicine = null;

                    medicineInDelivery.DeliveryId = delivery.DeliveryId;

                    var existingMedicine = context.Medicines.Find(medicineInDelivery.MedicineId);
                    if (existingMedicine != null)
                    {
                        existingMedicine.Quantity += medicineInDelivery.Quantity;
                    }

                    context.MedicineDeliveries.Add(medicineInDelivery);
                }

                context.SaveChanges();
            }
        }


        public void AddRecieptWithMedicines(Modele.Reciept reciept, List<MedicineReciept> medicineReciepts)
        {
            using (var context = new AptekaTestDbContext())
            {
                // Sprawdź zakres daty przed dodaniem
            //    if (reciept.DateOfExpire < new DateTime(1753, 1, 1) || reciept.DateOfExpire > new DateTime(9999, 12, 31))
             //   {
           //         throw new ArgumentOutOfRangeException("Data wygaśnięcia musi mieścić się w zakresie od 1753-01-01 do 9999-12-31.");
          //      }

                context.Reciepts.Add(reciept);

                foreach (var medicineInReciept in medicineReciepts)
                {
                    medicineInReciept.RecieptId = reciept.RecieptId;
                    context.MedicineReciepts.Add(medicineInReciept);
                }

                context.SaveChanges();
            }
        }



        public List<MedicineDelivery> GetMedicineDeliveries()
        {
           AptekaTestDbContext _context = new AptekaTestDbContext();
            using (var context = _context)
            {
                return context.MedicineDeliveries.ToList();
            }
        }

        public List<MedicineReciept> GetMedicinesFromReciept(int recieptId)
        {
            
            AptekaTestDbContext _context = new AptekaTestDbContext();
           return _context.MedicineReciepts
                .Where(mr => mr.RecieptId == recieptId)
                .ToList();
        }
    }
    
}
