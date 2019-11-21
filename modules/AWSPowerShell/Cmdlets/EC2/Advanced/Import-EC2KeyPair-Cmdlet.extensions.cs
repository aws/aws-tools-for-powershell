/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    public partial class ImportEC2KeyPairCmdlet
    {
        #region Parameter PublicKeyMaterial
        /// <summary>
        /// <para>
        /// This parameter is obsolete and will be removed in a future version. Use 'PublicKey' instead.
        /// The public key. For API calls, the text must be base64-encoded.
        /// </para>
        /// </summary>
#if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = "PreEncodedToBase64")]
#else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "PreEncodedToBase64")]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
#endif
        [System.ObsoleteAttribute("This parameter is obsolete and will be removed in a future version. Use 'PublicKey' instead.")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PublicKeyMaterial { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.PublicKeyMaterial != null)
            {
                cmdletContext.PublicKey = PublicKeyMaterial;
            }
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
        }
    }
}
