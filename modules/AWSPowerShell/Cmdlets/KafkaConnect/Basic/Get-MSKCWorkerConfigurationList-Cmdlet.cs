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
using Amazon.KafkaConnect;
using Amazon.KafkaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.MSKC
{
    /// <summary>
    /// Returns a list of all of the worker configurations in this account and Region.
    /// </summary>
    [Cmdlet("Get", "MSKCWorkerConfigurationList")]
    [OutputType("Amazon.KafkaConnect.Model.WorkerConfigurationSummary")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka Connect ListWorkerConfigurations API operation.", Operation = new[] {"ListWorkerConfigurations"}, SelectReturnType = typeof(Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.KafkaConnect.Model.WorkerConfigurationSummary or Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.KafkaConnect.Model.WorkerConfigurationSummary objects.",
        "The service call response (type Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMSKCWorkerConfigurationListCmdlet : AmazonKafkaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NamePrefix
        /// <summary>
        /// <para>
        /// <para>Lists worker configuration names that start with the specified text string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NamePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of worker configurations to list in one response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response of a ListWorkerConfigurations operation is truncated, it will include
        /// a NextToken. Send this NextToken in a subsequent request to continue listing from
        /// where the previous operation left off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkerConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkerConfigurations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NamePrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NamePrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NamePrefix' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse, GetMSKCWorkerConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NamePrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.KafkaConnect.Model.ListWorkerConfigurationsRequest();
            
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
        
        private Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse CallAWSServiceOperation(IAmazonKafkaConnect client, Amazon.KafkaConnect.Model.ListWorkerConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka Connect", "ListWorkerConfigurations");
            try
            {
                #if DESKTOP
                return client.ListWorkerConfigurations(request);
                #elif CORECLR
                return client.ListWorkerConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NamePrefix { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.KafkaConnect.Model.ListWorkerConfigurationsResponse, GetMSKCWorkerConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkerConfigurations;
        }
        
    }
}
