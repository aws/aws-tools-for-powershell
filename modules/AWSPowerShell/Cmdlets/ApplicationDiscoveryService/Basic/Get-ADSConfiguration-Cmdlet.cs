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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Retrieves attributes for a list of configuration item IDs.
    /// 
    ///  <note><para>
    /// All of the supplied IDs must be for the same asset type from one of the following:
    /// </para><ul><li><para>
    /// server
    /// </para></li><li><para>
    /// application
    /// </para></li><li><para>
    /// process
    /// </para></li><li><para>
    /// connection
    /// </para></li></ul><para>
    /// Output fields are specific to the asset type specified. For example, the output for
    /// a <i>server</i> configuration item includes a list of attributes about the server,
    /// such as host name, operating system, number of network cards, etc.
    /// </para><para>
    /// For a complete list of outputs for each asset type, see <a href="https://docs.aws.amazon.com/application-discovery/latest/userguide/discovery-api-queries.html#DescribeConfigurations">Using
    /// the DescribeConfigurations Action</a> in the <i>Amazon Web Services Application Discovery
    /// Service User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "ADSConfiguration")]
    [OutputType("System.Collections.Generic.Dictionary<System.String, System.String>")]
    [AWSCmdlet("Calls the AWS Application Discovery Service DescribeConfigurations API operation.", Operation = new[] {"DescribeConfigurations"}, SelectReturnType = typeof(Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse))]
    [AWSCmdletOutput("System.Collections.Generic.Dictionary<System.String, System.String> or Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse",
        "This cmdlet returns a collection of Dictionary<System.String, System.String> objects.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetADSConfigurationCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationId
        /// <summary>
        /// <para>
        /// <para>One or more configuration IDs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConfigurationIds")]
        public System.String[] ConfigurationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configurations";
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
                context.Select = CreateSelectDelegate<Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse, GetADSConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConfigurationId != null)
            {
                context.ConfigurationId = new List<System.String>(this.ConfigurationId);
            }
            #if MODULAR
            if (this.ConfigurationId == null && ParameterWasBound(nameof(this.ConfigurationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsRequest();
            
            if (cmdletContext.ConfigurationId != null)
            {
                request.ConfigurationIds = cmdletContext.ConfigurationId;
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
        
        private Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Application Discovery Service", "DescribeConfigurations");
            try
            {
                return client.DescribeConfigurationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ConfigurationId { get; set; }
            public System.Func<Amazon.ApplicationDiscoveryService.Model.DescribeConfigurationsResponse, GetADSConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configurations;
        }
        
    }
}
