/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MediaStoreData;
using Amazon.MediaStoreData.Model;

namespace Amazon.PowerShell.Cmdlets.EMSD
{
    public partial class WriteEMSDObjectCmdlet
    {

        #region Parameter FilePath
        /// <summary>
        /// This parameter is obsolete and will be removed in a future version. Use 'Body' instead.
        /// The path to the file containing the content to be uploaded.
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is obsolete and will be removed in a future version. Use 'Body' instead.")]
        public System.String FilePath { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FilePath != null)
            {
                cmdletContext.Body = new System.IO.FileInfo(this.FilePath);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
        }
    }
}
