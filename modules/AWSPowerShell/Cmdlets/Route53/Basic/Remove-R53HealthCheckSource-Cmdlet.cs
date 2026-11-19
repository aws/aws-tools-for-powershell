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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Deletes a health check source. Before you delete a health check source, delete or
    /// update any health checks that reference it. Otherwise, the request fails with <c>InvalidInput</c>.
    /// The request also fails with <c>InvalidInput</c> if the status of the health check
    /// source is <c>CREATE_PENDING</c> or <c>CREATE_IN_PROGRESS</c>. Wait until the status
    /// is <c>CREATE_COMPLETED</c> or <c>CREATE_FAILED</c>, and then try again.
    /// 
    ///  
    /// <para>
    /// Route 53 deletes a health check source asynchronously, and the initial <c>HealthCheckSourceStatus</c>
    /// is <c>DELETE_PENDING</c>. Call <c>GetHealthCheckSource</c> to track progress. After
    /// the deletion completes, <c>GetHealthCheckSource</c> returns <c>NoSuchHealthCheckSource</c>
    /// and the health check source no longer appears in the results of <c>ListHealthCheckSources</c>.
    /// If you delete a health check source that is already deleted, the request fails with
    /// <c>NoSuchHealthCheckSource</c>.
    /// </para><para>
    /// To use this operation, you must have the <c>route53:DeleteHealthCheckSource</c> permission.
    /// You must also have permission to create a service-linked role.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "R53HealthCheckSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Route53.Model.DeleteHealthCheckSourceResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 DeleteHealthCheckSource API operation.", Operation = new[] {"DeleteHealthCheckSource"}, SelectReturnType = typeof(Amazon.Route53.Model.DeleteHealthCheckSourceResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.DeleteHealthCheckSourceResponse",
        "This cmdlet returns an Amazon.Route53.Model.DeleteHealthCheckSourceResponse object containing multiple properties."
    )]
    public partial class RemoveR53HealthCheckSourceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HealthCheckSourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the health check source that you want to delete.</para>
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
        public System.String HealthCheckSourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.DeleteHealthCheckSourceResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.DeleteHealthCheckSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HealthCheckSourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-R53HealthCheckSource (DeleteHealthCheckSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.DeleteHealthCheckSourceResponse, RemoveR53HealthCheckSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HealthCheckSourceId = this.HealthCheckSourceId;
            #if MODULAR
            if (this.HealthCheckSourceId == null && ParameterWasBound(nameof(this.HealthCheckSourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheckSourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53.Model.DeleteHealthCheckSourceRequest();
            
            if (cmdletContext.HealthCheckSourceId != null)
            {
                request.HealthCheckSourceId = cmdletContext.HealthCheckSourceId;
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
        
        private Amazon.Route53.Model.DeleteHealthCheckSourceResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.DeleteHealthCheckSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "DeleteHealthCheckSource");
            try
            {
                return client.DeleteHealthCheckSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HealthCheckSourceId { get; set; }
            public System.Func<Amazon.Route53.Model.DeleteHealthCheckSourceResponse, RemoveR53HealthCheckSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
