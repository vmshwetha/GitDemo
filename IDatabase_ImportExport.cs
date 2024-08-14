
/****************************************************************************************
 *                              COPYRIGHT (c) 2011-2012                                 *
 *                              HONEYWELL INTERNATIONAL INC.                            *
 *                                 ALL RIGHTS RESERVED                                  *
 *                                                                                      *
 *  Legal rights of Honeywell International Inc. in this software is distinct           *
 *  from ownership of any medium in which the software is embodied. Copyright           *
 *  notices must be reproduced in any copies authorized by Honeywell International Inc. *
 *                                                                                      *
 *  File Name    :                                                                      *
 *  Description  :                                                                      *
 *  Author(s)    :                                                                      *
 *  Reviewer(s)  :                                                                      *
 *                                                                                      *
 *  Revision History:                                                                   *
 *  ---------------------------------------------------------------------------------   *
 *  |  Date       |           Description                     |    Author           |   *
 *  ---------------------------------------------------------------------------------   *
 *  | 22-dec-2011 | Initial Version of this document          |   R M Shabu         |   *
 *                                                              Rakshitha Prabhu        *
 *                                                                                      *
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IDatabaseImport
    {
        DataTable ValidateDatabase(IProject pii_Project, string pistr_DestinationFilename, ProgressStatus pii_ProgressStatus,
            UpdateProgress pii_UpdateProgress, out Dictionary<IMigratedData, bool> podict_Files, out List<string> polst_ImportTables);
        bool ImportDatabase(IProject pii_Project, string pistr_DestinationFilename, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress,
            Dictionary<IMigratedData, bool> pidict_Files, List<string> pilst_ImportTables);
        bool ImportPointDetails(IProject pii_Project, string pistr_DestinationFilename, ProgressStatus pii_ProgressStatus,
            UpdateProgress pii_UpdateProgress,   Dictionary<IMigratedData, bool> pidict_Files);
        DataTable ValidatePointDetails(IProject pii_Project, string pistr_DestinationFilename, ProgressStatus pii_ProgressStatus,
            UpdateProgress pii_UpdateProgress, out Dictionary<IMigratedData, bool> podict_Files);
    }

    public interface IDatabaseExport
    {
        bool ExportDatabase(IProject pii_Project, string pistr_DestinationFilename, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
        bool ExportPointDetails(IProject pii_Project, string pistr_DestinationFilename, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
    }
}
