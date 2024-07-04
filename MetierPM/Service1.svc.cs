using MetierPM.Model;
using MetierPM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierPM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        bdMemoireM1Context db= new bdMemoireM1Context();
        Logger logger = new Logger();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expert"></param>
        /// <returns></returns>
        public bool AddExpert(Expert expert)
        {
            try
            {
                db.experts.Add(expert);
                db.SaveChanges();
                return true;
            }
            catch(Exception e) {
                logger.WriteDataError("Serice1-AddExpert",e.ToString());
                return false;
            }
        }
        
        public bool UpdateExpert(Expert expert)
        {
            try
            {
                var leExpert=db.experts.Find(expert.Id);
                if (leExpert == null) {
                    leExpert.Prenom=expert.Prenom;
                    leExpert.Nom=expert.Nom;
                    leExpert.Specialite=expert.Specialite;  
                    db.SaveChanges();
                    return true;
                }
               
            }
            catch (Exception e)
            {
                logger.WriteDataError("Serice1-UpdateExpert", e.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Idexpert"></param>
        /// <returns></returns>
        public bool DeleteExpert(int? Idexpert)
        {
            try
            {
                var leExpert = db.experts.Find(Idexpert);
                if (leExpert == null)
                {
                    db.experts.Remove(leExpert);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                logger.WriteDataError("Serice1-DeleteExpert", e.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Expert>GetAllExpert()
        { 
            return db.experts.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdExpert"></param>
        /// <returns></returns>
        public Expert GetExpert(int? IdExpert)
        {
            return db.experts.Find(IdExpert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Prenom"></param>
        /// <param name="Specialite"></param>
        /// <returns></returns>

        public List<Expert> GetExperts(string Nom,string Prenom,string Specialite)
        {
            var liste = db.experts.ToList();
            if (!string.IsNullOrEmpty(Nom)) 
            { 
                liste=liste.Where(a => a.Nom.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.Prenom.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Specialite))
            {
                liste = liste.Where(a => a.Specialite.ToUpper().Contains(Specialite.ToUpper())).ToList();
            }
            return liste;
        }
    }
}
