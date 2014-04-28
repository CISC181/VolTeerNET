/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_GroupAddr_DAL
    {
        //TODO - DeleteAll from GroupAddr for a given VolID
        public void DelAll_Group_Addr(Guid? VolID)
        {

        }

        //TODO - Add a record for a given VolID, AddrID
       public void Add_Group_Addr(ref sp_GroupAddr_DM _cAddress)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                try
                {
                    var cAddress = new tblGroupAddr
                    {
                        AddrLine1 = _cAddress.AddrLine1,
                        AddrLine2 = _cAddress.AddrLine2,
                        AddrLine3 = _cAddress.AddrLine3,
                        City = _cAddress.City,
                        St = _cAddress.St,
                        Zip = _cAddress.Zip,
                        Zip4 = _cAddress.Zip4,
                        GeoCodeGetSet = _cAddress.GeoCodeGetSet,
                        ActiveFlg = _cAddress.ActiveFlg
                    };
                    context.tblGroupAddr.Add(cAddress);
                    context.SaveChanges();

                    var cVolAddr = new tblGroupAddr
                    {
                      //  VolID = _cVolAddr.VolID,
                        AddrID = cAddress.AddrID,
                       // PrimaryAddr = _cVolAddr.PrimaryAddr
                    };

                    context.tblVolAddrs.Add(cVolAddr);
                    context.SaveChanges();

                    //If the AddrID isn't null, set it equal to the return value
                    if (_cAddress.AddrID != null)
                    {
                        _cAddress.AddrID = cAddress.AddrID;
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        
        }
    }
}
*/