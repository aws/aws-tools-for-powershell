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
using System.Threading;
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Gets a list of the Amazon Web Services services from which Audit Manager can collect
    /// evidence. 
    /// 
    ///  
    /// <para>
    /// Audit Manager defines which Amazon Web Services services are in scope for an assessment.
    /// Audit Manager infers this scope by examining the assessment’s controls and their data
    /// sources, and then mapping this information to one or more of the corresponding Amazon
    /// Web Services services that are in this list.
    /// </para><note><para>
    /// For information about why it's no longer possible to specify services in scope manually,
    /// see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/evidence-collection-issues.html#unable-to-edit-services">I
    /// can't edit the services in scope for my assessment</a> in the <i>Troubleshooting</i>
    /// section of the Audit Manager user guide.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "AUDMServiceInScope")]
    [OutputType("Amazon.AuditManager.Model.ServiceMetadata")]
    [AWSCmdlet("Calls the AWS Audit Manager GetServicesInScope API operation.", Operation = new[] {"GetServicesInScope"}, SelectReturnType = typeof(Amazon.AuditManager.Model.GetServicesInScopeResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.ServiceMetadata or Amazon.AuditManager.Model.GetServicesInScopeResponse",
        "This cmdlet returns a collection of Amazon.AuditManager.Model.ServiceMetadata objects.",
        "The service call response (type Amazon.AuditManager.Model.GetServicesInScopeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAUDMServiceInScopeCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.GetServicesInScopeResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.GetServicesInScopeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceMetadata";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.GetServicesInScopeResponse, GetAUDMServiceInScopeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.AuditManager.Model.GetServicesInScopeRequest();
            
            
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
        
        private Amazon.AuditManager.Model.GetServicesInScopeResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.GetServicesInScopeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "GetServicesInScope");
            try
            {
                return client.GetServicesInScopeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.AuditManager.Model.GetServicesInScopeResponse, GetAUDMServiceInScopeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceMetadata;
        }
        
    }
}
