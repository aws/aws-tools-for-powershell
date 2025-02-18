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
using Amazon.SSMQuickSetup;
using Amazon.SSMQuickSetup.Model;

namespace Amazon.PowerShell.Cmdlets.SSMQS
{
    /// <summary>
    /// Returns configurations deployed by Quick Setup in the requesting Amazon Web Services
    /// account and Amazon Web Services Region.
    /// </summary>
    [Cmdlet("Get", "SSMQSConfigurationList")]
    [OutputType("Amazon.SSMQuickSetup.Model.ConfigurationSummary")]
    [AWSCmdlet("Calls the AWS Systems Manager QuickSetup ListConfigurations API operation.", Operation = new[] {"ListConfigurations"}, SelectReturnType = typeof(Amazon.SSMQuickSetup.Model.ListConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.SSMQuickSetup.Model.ConfigurationSummary or Amazon.SSMQuickSetup.Model.ListConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.SSMQuickSetup.Model.ConfigurationSummary objects.",
        "The service call response (type Amazon.SSMQuickSetup.Model.ListConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMQSConfigurationListCmdlet : AmazonSSMQuickSetupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationDefinitionId
        /// <summary>
        /// <para>
        /// <para>The ID of the configuration definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationDefinitionId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters the results returned by the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SSMQuickSetup.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ManagerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the configuration manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagerArn { get; set; }
        #endregion
        
        #region Parameter StartingToken
        /// <summary>
        /// <para>
        /// <para>The token to use when requesting a specific set of items from a list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartingToken { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of configurations that are returned by the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationsList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMQuickSetup.Model.ListConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.SSMQuickSetup.Model.ListConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationsList";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMQuickSetup.Model.ListConfigurationsResponse, GetSSMQSConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationDefinitionId = this.ConfigurationDefinitionId;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SSMQuickSetup.Model.Filter>(this.Filter);
            }
            context.ManagerArn = this.ManagerArn;
            context.MaxItem = this.MaxItem;
            context.StartingToken = this.StartingToken;
            
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
            var request = new Amazon.SSMQuickSetup.Model.ListConfigurationsRequest();
            
            if (cmdletContext.ConfigurationDefinitionId != null)
            {
                request.ConfigurationDefinitionId = cmdletContext.ConfigurationDefinitionId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.ManagerArn != null)
            {
                request.ManagerArn = cmdletContext.ManagerArn;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.StartingToken != null)
            {
                request.StartingToken = cmdletContext.StartingToken;
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
        
        private Amazon.SSMQuickSetup.Model.ListConfigurationsResponse CallAWSServiceOperation(IAmazonSSMQuickSetup client, Amazon.SSMQuickSetup.Model.ListConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager QuickSetup", "ListConfigurations");
            try
            {
                return client.ListConfigurationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationDefinitionId { get; set; }
            public List<Amazon.SSMQuickSetup.Model.Filter> Filter { get; set; }
            public System.String ManagerArn { get; set; }
            public System.Int32? MaxItem { get; set; }
            public System.String StartingToken { get; set; }
            public System.Func<Amazon.SSMQuickSetup.Model.ListConfigurationsResponse, GetSSMQSConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationsList;
        }
        
    }
}
