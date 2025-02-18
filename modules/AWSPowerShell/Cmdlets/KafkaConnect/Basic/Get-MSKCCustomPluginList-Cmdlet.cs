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
using Amazon.KafkaConnect;
using Amazon.KafkaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.MSKC
{
    /// <summary>
    /// Returns a list of all of the custom plugins in this account and Region.
    /// </summary>
    [Cmdlet("Get", "MSKCCustomPluginList")]
    [OutputType("Amazon.KafkaConnect.Model.CustomPluginSummary")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka Connect ListCustomPlugins API operation.", Operation = new[] {"ListCustomPlugins"}, SelectReturnType = typeof(Amazon.KafkaConnect.Model.ListCustomPluginsResponse))]
    [AWSCmdletOutput("Amazon.KafkaConnect.Model.CustomPluginSummary or Amazon.KafkaConnect.Model.ListCustomPluginsResponse",
        "This cmdlet returns a collection of Amazon.KafkaConnect.Model.CustomPluginSummary objects.",
        "The service call response (type Amazon.KafkaConnect.Model.ListCustomPluginsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMSKCCustomPluginListCmdlet : AmazonKafkaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NamePrefix
        /// <summary>
        /// <para>
        /// <para>Lists custom plugin names that start with the specified text string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NamePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of custom plugins to list in one response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response of a ListCustomPlugins operation is truncated, it will include a NextToken.
        /// Send this NextToken in a subsequent request to continue listing from where the previous
        /// operation left off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomPlugins'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KafkaConnect.Model.ListCustomPluginsResponse).
        /// Specifying the name of a property of type Amazon.KafkaConnect.Model.ListCustomPluginsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomPlugins";
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
                context.Select = CreateSelectDelegate<Amazon.KafkaConnect.Model.ListCustomPluginsResponse, GetMSKCCustomPluginListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NamePrefix = this.NamePrefix;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.KafkaConnect.Model.ListCustomPluginsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NamePrefix != null)
            {
                request.NamePrefix = cmdletContext.NamePrefix;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.KafkaConnect.Model.ListCustomPluginsResponse CallAWSServiceOperation(IAmazonKafkaConnect client, Amazon.KafkaConnect.Model.ListCustomPluginsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka Connect", "ListCustomPlugins");
            try
            {
                return client.ListCustomPluginsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NamePrefix { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.KafkaConnect.Model.ListCustomPluginsResponse, GetMSKCCustomPluginListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomPlugins;
        }
        
    }
}
