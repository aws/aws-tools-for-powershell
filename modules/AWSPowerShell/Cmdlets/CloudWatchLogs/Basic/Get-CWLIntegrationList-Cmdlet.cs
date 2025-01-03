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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Returns a list of integrations between CloudWatch Logs and other services in this
    /// account. Currently, only one integration can be created in an account, and this integration
    /// must be with OpenSearch Service.
    /// </summary>
    [Cmdlet("Get", "CWLIntegrationList")]
    [OutputType("Amazon.CloudWatchLogs.Model.IntegrationSummary")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs ListIntegrations API operation.", Operation = new[] {"ListIntegrations"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.ListIntegrationsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.IntegrationSummary or Amazon.CloudWatchLogs.Model.ListIntegrationsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.IntegrationSummary objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.ListIntegrationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLIntegrationListCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IntegrationNamePrefix
        /// <summary>
        /// <para>
        /// <para>To limit the results to integrations that start with a certain name prefix, specify
        /// that name prefix here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntegrationNamePrefix { get; set; }
        #endregion
        
        #region Parameter IntegrationStatus
        /// <summary>
        /// <para>
        /// <para>To limit the results to integrations with a certain status, specify that status here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.IntegrationStatus")]
        public Amazon.CloudWatchLogs.IntegrationStatus IntegrationStatus { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>To limit the results to integrations of a certain type, specify that type here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.IntegrationType")]
        public Amazon.CloudWatchLogs.IntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IntegrationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.ListIntegrationsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.ListIntegrationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IntegrationSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.ListIntegrationsResponse, GetCWLIntegrationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IntegrationNamePrefix = this.IntegrationNamePrefix;
            context.IntegrationStatus = this.IntegrationStatus;
            context.IntegrationType = this.IntegrationType;
            
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
            var request = new Amazon.CloudWatchLogs.Model.ListIntegrationsRequest();
            
            if (cmdletContext.IntegrationNamePrefix != null)
            {
                request.IntegrationNamePrefix = cmdletContext.IntegrationNamePrefix;
            }
            if (cmdletContext.IntegrationStatus != null)
            {
                request.IntegrationStatus = cmdletContext.IntegrationStatus;
            }
            if (cmdletContext.IntegrationType != null)
            {
                request.IntegrationType = cmdletContext.IntegrationType;
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
        
        private Amazon.CloudWatchLogs.Model.ListIntegrationsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.ListIntegrationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "ListIntegrations");
            try
            {
                #if DESKTOP
                return client.ListIntegrations(request);
                #elif CORECLR
                return client.ListIntegrationsAsync(request).GetAwaiter().GetResult();
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
            public System.String IntegrationNamePrefix { get; set; }
            public Amazon.CloudWatchLogs.IntegrationStatus IntegrationStatus { get; set; }
            public Amazon.CloudWatchLogs.IntegrationType IntegrationType { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.ListIntegrationsResponse, GetCWLIntegrationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IntegrationSummaries;
        }
        
    }
}
