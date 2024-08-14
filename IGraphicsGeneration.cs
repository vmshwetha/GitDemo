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
using System.Data;
using System.Drawing;
using System.ComponentModel;
namespace Honeywell.Tools.GraphicsMatch.Library
{
    public interface IGraphicsGeneration
    {
	  DataTable GenerateGraphics(IProject pii_Project, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress, bool pib_IgnoreShapes);

      SizeF GetResolution(IProject pii_Project, string pistr_TemplateLocation);

      SizeF GetResolution(IDestinationSystemType pii_DestinationSystemType, string pistr_TemplateLocation);

      void GetResolution(IProject pii_Project, ProgressStatus pii_ProgressStatus, UpdateProgress pii_UpdateProgress);
    }
}
