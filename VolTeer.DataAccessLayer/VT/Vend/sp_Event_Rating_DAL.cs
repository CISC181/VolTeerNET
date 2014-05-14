using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;


namespace VolTeer.DataAccessLayer.VT.Vend
{
    public class sp_EventRating_DAL
    {

        #region Select Statements
        public List<sp_EventRating_DM> ListEventRatings()
        {
            List<sp_EventRating_DM> list = new List<sp_EventRating_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_EventRating_Select(null,null)
                            select new sp_EventRating_DM
                            {
                                RatingID = result.RatingID,
                                EventID = result.EventID,
                                VolID = result.VolID,
                                RatingValue = result.RatingValue,
                                ActiveFlg = result.ActiveFlg
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        public List<sp_EventRating_DM> ListEventRatings(int? RatingID)
        {
            List<sp_EventRating_DM> list = new List<sp_EventRating_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_EventRating_Select(RatingID,null)
                            select new sp_EventRating_DM
                            {
                                RatingID = result.RatingID,
                                EventID = result.EventID,
                                VolID = result.VolID,
                                RatingValue = result.RatingValue,
                                ActiveFlg = result.ActiveFlg
                            }).ToList();
                } // Guaranteed to close the Connection
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;

        }

        #endregion

        #region Insert Statements
        public sp_EventRating_DM InsertEventRatingContext(sp_EventRating_DM InputRating)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var NewEventRating = new tblEventRating
                {
                    RatingID = InputRating.RatingID,
                    EventID = InputRating.EventID,
                    VolID = InputRating.VolID,
                    RatingValue = InputRating.RatingValue,
                    ActiveFlg = InputRating.ActiveFlg

                };
                context.tblEventRatings.Add(NewEventRating);
                context.SaveChanges();

                InputRating.RatingID = NewEventRating.RatingID;
                return InputRating;
            }
        }
        #endregion

        #region Update Statements

        public void UpdateEventRatingContext(sp_EventRating_DM InputRating)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var ExistingRating = context.tblEventRatings.Find(InputRating.RatingID);

                if (ExistingRating != null)
                {
                    ExistingRating.EventID = InputRating.EventID;
                    ExistingRating.RatingID = InputRating.RatingID;
                    ExistingRating.RatingValue = InputRating.RatingValue;
                    ExistingRating.ActiveFlg = InputRating.ActiveFlg;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete Statements
        public void DeleteEventRatingContext(sp_EventRating_DM InputRating)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                var RatingToRemove = (from n in context.tblEventRatings where n.RatingID == InputRating.RatingID select n).FirstOrDefault();
                context.tblEventRatings.Remove(RatingToRemove);
                context.SaveChanges();

            }
        }
        #endregion
    }
}
