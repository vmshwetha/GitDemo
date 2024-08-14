/****************************************************************************************
 *                              COPYRIGHT © 2011-2012                                 *
 *                              HONEYWELL INTERNATIONAL INC.                            *
 *                                 ALL RIGHTS RESERVED                                  *
 *                                                                                      *
 *  Legal rights of Honeywell International Inc. in this software is distinct           *
 *  from ownership of any medium in which the software is embodied. Copyright           *
 *  notices must be reproduced in any copies authorized by Honeywell International Inc. *
 *                                                                                      *
 *  File Name    : IDynamicMapping.cs                                                   *
 *  Description  : Create dynamic mapping                                               *
 *  Author(s)    :                                                                      *
 *  Reviewer(s)  :                                                                      *
 *                                                                                      *
 *  Revision History:                                                                   *
 *  ---------------------------------------------------------------------------------   *
 *  |  Date       |           Description                     |    Author           |   *
 *  ---------------------------------------------------------------------------------   *
 *  |             | Initial Version of this document          |                     |   *
 ****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IPointTypeParameterMapCollection
    {
        IPointTypeParameterMap this[int index]
        {
            get;
        }
        int Count
        {
            get;
        }

        IPointTypeParameterMap New();
        IPointTypeParameterMap Search(string pistr_Name);
        IPointTypeParameterMap Search(int pii32_ID);
        void Remove(IPointTypeParameterMap pii_PointTypeParameterMap);
        void ClearUnsavedPointTypeParameterMap();
    }

    public interface IPointTypeParameterMap
    { 
        IPointTypeParameterMapCollection PointTypeParameterMapCollection
        {
            get;
        }

        int ID
        {
            get;
        }

        string Name
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

        string Delimiter
        {
            get;
            set;
        }

        DataTable PointTypeParameterMapData
        {
            get;
            set;
        }

        //Start : Added for Dynamic Objects
        string SourceSystemTypeName
        {
            get;
            set;
        }
        //End : Added for Dynamic Objects


        bool IsSaved
        {
            get;
        }
        bool IsSelected
        {
            get;
            set;
        }
        bool IsDefault
        {
            get;
        }

        bool Save(string pistr_Delimiter);
        bool Delete();
        bool ImportPointTypeParameterMap(string pistr_Delimiter,string pistr_FilePath, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
        void Export(string pistr_FilePath, DataTable pidt_PointTypeParameterMapData);
        void Reset();
        IPointTypeParameterMap Copy();
        bool ApplyDelimiter(string pistr_Delimiter);
        bool Delete(int pii32_PointTypeParameterMapID);
    }

    public interface IKeywordMapCollection
    {
        IKeywordMap this[int index]
        {
            get;
        }
        int Count
        {
            get;
        }

        IKeywordMap New();
        IKeywordMap Search(string pistr_Name);
        IKeywordMap Search(int pii32_ID);
        void Remove(IKeywordMap pii_KeywordMap);
        void ClearUnsavedKeywordMap();
    }

    public interface IKeywordMap
    {
        IKeywordMapCollection KeywordMapCollection
        {
            get;
        }

        int ID
        {
            get;
        }

        string Name
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

        //Start : Added for Dynamic Objects
        string SourceSystemTypeName
        {
            get;
            set;
        }
        //End : Added for Dynamic Objects

        DataTable KeywordMapData
        {
            get;
            set;
        }

        bool IsSaved
        {
            get;
        }
        bool IsSelected
        {
            get;
            set;
        }
        bool IsDefault
        {
            get;
            set;
        }
        bool Save();
        bool Delete();
        bool Delete(int KeywordMapsetID, int KeywordMapID);
        bool ImportKeywordMap(DataTable pidt_KeywordMapData, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
        void Export(string pistr_FilePath, DataTable pidt_KeywordMapData);
        void Reset();
    }
}
