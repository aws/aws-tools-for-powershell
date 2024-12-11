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
using Amazon.IAMRolesAnywhere;
using Amazon.IAMRolesAnywhere.Model;

namespace Amazon.PowerShell.Cmdlets.IAMRA
{
    /// <summary>
    /// Gets a trust anchor.
    /// 
    ///  
    /// <para><b>Required permissions: </b><c>rolesanywhere:GetTrustAnchor</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMRATrustAnchor")]
    [OutputType("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere GetTrustAnchor API operation.", Operation = new[] {"GetTrustAnchor"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail or Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMRATrustAnchorCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TrustAnchorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the trust anchor.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TrustAnchorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustAnchor'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustAnchor";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse, GetIAMRATrustAnchorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TrustAnchorId = this.TrustAnchorId;
            #if MODULAR
            if (this.TrustAnchorId == null && ParameterWasBound(nameof(this.TrustAnchorId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustAnchorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IAMRolesAnywhere.Model.GetTrustAnchorRequest();
            
            if (cmdletContext.TrustAnchorId != null)
            {
                request.TrustAnchorId = cmdletContext.TrustAnchorId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.GetTrustAnchorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "GetTrustAnchor");
            try
            {
                #if DESKTOP
                return client.GetTrustAnchor(request);
                #elif CORECLR
                return client.GetTrustAnchorAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String TrustAnchorId { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.GetTrustAnchorResponse, GetIAMRATrustAnchorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustAnchor;
        }
        
    }
}
