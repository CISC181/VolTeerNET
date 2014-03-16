using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;
namespace VolTeer.DataAccessLayer.VT
{
    public class sp_Sample_Address_DAL
    {

        public List<sp_Sample_Address_Select_DM> ListSampleAddress()
        {
            List<sp_Sample_Address_Select_DM> list = new List<sp_Sample_Address_Select_DM>();
            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.sp_Sample_Address_Select()
                        select new sp_Sample_Address_Select_DM
                        {
                            AddrID = result.AddrID,
                            ActiveFlg = result.ActiveFlg,
                            AddrLine1 = result.AddrLine1,
                            AddrLine2 = result.AddrLine2,
                            AddrLine3 = result.AddrLine3,
                            City = result.City,
                            St = result.St,
                            Zip = result.Zip,
                            Zip4 = result.Zip4

                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }

        public void UpdateSampleAddress(Nullable<int> addrID, string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)       
        {         
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Sample_Address_Update(addrID, addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);

            }
        }

        public void InsertSampleAddress(string addrLine1, string addrLine2, string addrLine3, string city, string st, Nullable<int> zip, Nullable<int> zip4, Nullable<bool> activeFlg)       
        {         
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Sample_Address_Insert( addrLine1, addrLine2, addrLine3, city, st, zip, zip4, activeFlg);

            }
        }

        public void DeleteSampleAddress(int addrID)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Sample_Address_Delete(addrID);

            }
        }

    }
}
