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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// For a batch of security controls and standards, identifies whether each control is
    /// currently enabled or disabled in a standard.
    /// </summary>
    [Cmdlet("Get", "SHUBGetStandardsControlAssociation")]
    [OutputType("Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse")]
    [AWSCmdlet("Calls the AWS Security Hub BatchGetStandardsControlAssociations API operation.", Operation = new[] {"BatchGetStandardsControlAssociations"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse object containing multiple properties."
    )]
    public partial class GetSHUBGetStandardsControlAssociationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StandardsControlAssociationId
        /// <summary>
        /// <para>
        /// <para> An array with one or more objects that includes a security control (identified with
        /// <c>SecurityControlId</c>, <c>SecurityControlArn</c>, or a mix of both parameters)
        /// and the Amazon Resource Name (ARN) of a standard. This field is used to query the
        /// enablement status of a control in a specified standard. The security control ID or
        /// ARN is the same across standards. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StandardsControlAssociationIds")]
        public Amazon.SecurityHub.Model.StandardsControlAssociationId[] StandardsControlAssociationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse, GetSHUBGetStandardsControlAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.StandardsControlAssociationId != null)
            {
                context.StandardsControlAssociationId = new List<Amazon.SecurityHub.Model.StandardsControlAssociationId>(this.StandardsControlAssociationId);
            }
            #if MODULAR
            if (this.StandardsControlAssociationId == null && ParameterWasBound(nameof(this.StandardsControlAssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter StandardsControlAssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsRequest();
            
            if (cmdletContext.StandardsControlAssociationId != null)
            {
                request.StandardsControlAssociationIds = cmdletContext.StandardsControlAssociationId;
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
        
        private Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "BatchGetStandardsControlAssociations");
            try
            {
                #if DESKTOP
                return client.BatchGetStandardsControlAssociations(request);
                #elif CORECLR
                return client.BatchGetStandardsControlAssociationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.StandardsControlAssociationId> StandardsControlAssociationId { get; set; }
            public System.Func<Amazon.SecurityHub.Model.BatchGetStandardsControlAssociationsResponse, GetSHUBGetStandardsControlAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
