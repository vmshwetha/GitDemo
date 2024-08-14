/****************************************************************************************
 *                              COPYRIGHT (c) 2011-2013                                 *
 *                              HONEYWELL INTERNATIONAL INC.                            *
 *                                 ALL RIGHTS RESERVED                                  *
 *                                                                                      *
 *  Legal rights of Honeywell International Inc. in this software is distinct           *
 *  from ownership of any medium in which the software is embodied. Copyright           *
 *  notices must be reproduced in any copies authorized by Honeywell International Inc. *
 *                                                                                      *
 *  File Name    :  IDataBackups.cs                                                     *
 *  Description  :  Interface for Data restore                                          *
 *  Author(s)    :  Rajendra Kumar Pradhan                                              *
 *  Reviewer(s)  :  R.M. Shabu                                                          *
 *                                                                                      *
 *  Revision History:                                                                   *
 *  ---------------------------------------------------------------------------------   *
 *  |  Date       |           Description                     |    Author           |   *
 *  ---------------------------------------------------------------------------------   *
 *  | 29-July-2013 | Initial Version of this document       | Rajendra Kumar Pradhan|   *
 *                                                                                      *
 *                                                                                      *
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 

namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IDataBackups
    {
        int Count
        {
            get;
        }

        IDataBackup this[int index]
        {
            get;
        }
        IProject Project
        {
            get;
        }
        IDataBackup New();

        IDataBackup Search(int pii32_ID);

        bool Delete();

        void Remove(IDataBackup pii_DataBackup);
 
    }

    public interface IDataBackup
    {
        int ID
        {
            get;
            set;
        }
        int ProjectID
        {
            get;          
        }
        DateTime LastModifedDate
        {
            get;
            set;
        }
        string PerformedOperation
        {
            get;
            set;
        }
        string RestoreDBName
        {
            get;
            set;
        }
        bool IsSaved
        {
            get;
        }
        bool IsModified
        {
            get;
            set;
        }
        bool Delete();
        bool Save();
        void RestoreMigratedData();
    }
}
