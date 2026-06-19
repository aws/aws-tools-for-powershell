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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Attaches a data source to an OpenSearch application. The data source can be an Amazon
    /// OpenSearch Service domain or an Amazon OpenSearch Serverless collection. If both the
    /// application and data source are in the <c>ACTIVE</c> state, the attachment completes
    /// immediately and returns a status of <c>ATTACHED</c>. If either resource is not yet
    /// active, the operation stores the request and returns a status of <c>PENDING</c>. A
    /// background process then completes the attachment when both resources become active.
    /// Pending attachments that are not completed within 24 hours are marked as <c>FAILED</c>.
    /// This operation is idempotent. If a data source is already attached or pending for
    /// the same application, the existing attachment is returned.
    /// </summary>
    [Cmdlet("Mount", "OSDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.AttachDataSourceResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service AttachDataSource API operation.", Operation = new[] {"AttachDataSource"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.AttachDataSourceResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.AttachDataSourceResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.AttachDataSourceResponse object containing multiple properties."
    )]
    public partial class MountOSDataSourceCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataSourceArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DataSourceArn { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier or name of the OpenSearch application to attach the data source
        /// to. This is the same identifier used with <c>UpdateApplication</c>, <c>GetApplication</c>,
        /// and <c>DeleteApplication</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter WorkspaceConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>The name of the workspace to create. Must be between 1 and 40 characters and can contain
        /// alphanumeric characters, parentheses, brackets, hyphens, underscores, and spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The identifier of an existing workspace to update with the new data source. Mutually
        /// exclusive with <c>workspaceConfiguration</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter WorkspaceConfiguration_WorkspaceType
        /// <summary>
        /// <para>
        /// <para>The type of workspace to create, which determines the use-case features enabled for
        /// the workspace. Valid values are <c>OBSERVABILITY</c>, <c>SECURITY_ANALYTICS</c>, and
        /// <c>SEARCH</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceConfiguration_WorkspaceType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. If you retry
        /// a request with the same client token and the same parameters, the retry succeeds without
        /// performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.AttachDataSourceResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.AttachDataSourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Mount-OSDataSource (AttachDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.AttachDataSourceResponse, MountOSDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DataSourceArn = this.DataSourceArn;
            #if MODULAR
            if (this.DataSourceArn == null && ParameterWasBound(nameof(this.DataSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceConfiguration_Name = this.WorkspaceConfiguration_Name;
            context.WorkspaceConfiguration_WorkspaceType = this.WorkspaceConfiguration_WorkspaceType;
            context.WorkspaceId = this.WorkspaceId;
            
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
            var request = new Amazon.OpenSearchService.Model.AttachDataSourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataSourceArn != null)
            {
                request.DataSourceArn = cmdletContext.DataSourceArn;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate WorkspaceConfiguration
            var requestWorkspaceConfigurationIsNull = true;
            request.WorkspaceConfiguration = new Amazon.OpenSearchService.Model.WorkspaceConfigurationInput();
            System.String requestWorkspaceConfiguration_workspaceConfiguration_Name = null;
            if (cmdletContext.WorkspaceConfiguration_Name != null)
            {
                requestWorkspaceConfiguration_workspaceConfiguration_Name = cmdletContext.WorkspaceConfiguration_Name;
            }
            if (requestWorkspaceConfiguration_workspaceConfiguration_Name != null)
            {
                request.WorkspaceConfiguration.Name = requestWorkspaceConfiguration_workspaceConfiguration_Name;
                requestWorkspaceConfigurationIsNull = false;
            }
            System.String requestWorkspaceConfiguration_workspaceConfiguration_WorkspaceType = null;
            if (cmdletContext.WorkspaceConfiguration_WorkspaceType != null)
            {
                requestWorkspaceConfiguration_workspaceConfiguration_WorkspaceType = cmdletContext.WorkspaceConfiguration_WorkspaceType;
            }
            if (requestWorkspaceConfiguration_workspaceConfiguration_WorkspaceType != null)
            {
                request.WorkspaceConfiguration.WorkspaceType = requestWorkspaceConfiguration_workspaceConfiguration_WorkspaceType;
                requestWorkspaceConfigurationIsNull = false;
            }
             // determine if request.WorkspaceConfiguration should be set to null
            if (requestWorkspaceConfigurationIsNull)
            {
                request.WorkspaceConfiguration = null;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.OpenSearchService.Model.AttachDataSourceResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.AttachDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "AttachDataSource");
            try
            {
                return client.AttachDataSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DataSourceArn { get; set; }
            public System.String Id { get; set; }
            public System.String WorkspaceConfiguration_Name { get; set; }
            public System.String WorkspaceConfiguration_WorkspaceType { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.AttachDataSourceResponse, MountOSDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
