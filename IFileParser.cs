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
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IFileParser
    {
        bool ParseInputFile(IProject pii_Project, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
        bool ParseImportFile(IImportedFile pii_ImportedFile);
    }
}
