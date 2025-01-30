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
using Amazon.MigrationHubOrchestrator;
using Amazon.MigrationHubOrchestrator.Model;

namespace Amazon.PowerShell.Cmdlets.MHO
{
    /// <summary>
    /// List the migration workflows.
    /// </summary>
    [Cmdlet("Get", "MHOWorkflowList")]
    [OutputType("Amazon.MigrationHubOrchestrator.Model.MigrationWorkflowSummary")]
    [AWSCmdlet("Calls the AWS Migration Hub Orchestrator ListWorkflows API operation.", Operation = new[] {"ListWorkflows"}, SelectReturnType = typeof(Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubOrchestrator.Model.MigrationWorkflowSummary or Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse",
        "This cmdlet returns a collection of Amazon.MigrationHubOrchestrator.Model.MigrationWorkflowSummary objects.",
        "The service call response (type Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMHOWorkflowListCmdlet : AmazonMigrationHubOrchestratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdsApplicationConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the application configured in Application Discovery Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdsApplicationConfigurationName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the migration workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the migration workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubOrchestrator.MigrationWorkflowStatusEnum")]
        public Amazon.MigrationHubOrchestrator.MigrationWorkflowStatusEnum Status { get; set; }
        #endregion
        
        #region Parameter TemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that can be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MigrationWorkflowSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MigrationWorkflowSummary";
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
                context.Select = CreateSelectDelegate<Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse, GetMHOWorkflowListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdsApplicationConfigurationName = this.AdsApplicationConfigurationName;
            context.MaxResult = this.MaxResult;
            context.Name = this.Name;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            context.TemplateId = this.TemplateId;
            
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
            var request = new Amazon.MigrationHubOrchestrator.Model.ListWorkflowsRequest();
            
            if (cmdletContext.AdsApplicationConfigurationName != null)
            {
                request.AdsApplicationConfigurationName = cmdletContext.AdsApplicationConfigurationName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TemplateId != null)
            {
                request.TemplateId = cmdletContext.TemplateId;
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
        
        private Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse CallAWSServiceOperation(IAmazonMigrationHubOrchestrator client, Amazon.MigrationHubOrchestrator.Model.ListWorkflowsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Orchestrator", "ListWorkflows");
            try
            {
                #if DESKTOP
                return client.ListWorkflows(request);
                #elif CORECLR
                return client.ListWorkflowsAsync(request).GetAwaiter().GetResult();
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
            public System.String AdsApplicationConfigurationName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String Name { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.MigrationHubOrchestrator.MigrationWorkflowStatusEnum Status { get; set; }
            public System.String TemplateId { get; set; }
            public System.Func<Amazon.MigrationHubOrchestrator.Model.ListWorkflowsResponse, GetMHOWorkflowListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MigrationWorkflowSummary;
        }
        
    }
}
