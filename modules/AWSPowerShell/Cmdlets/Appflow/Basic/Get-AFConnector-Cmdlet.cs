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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Describes the given custom connector registered in your Amazon Web Services account.
    /// This API can be used for custom connectors that are registered in your account and
    /// also for Amazon authored connectors.
    /// </summary>
    [Cmdlet("Get", "AFConnector")]
    [OutputType("Amazon.Appflow.Model.ConnectorConfiguration")]
    [AWSCmdlet("Calls the Amazon Appflow DescribeConnector API operation.", Operation = new[] {"DescribeConnector"}, SelectReturnType = typeof(Amazon.Appflow.Model.DescribeConnectorResponse))]
    [AWSCmdletOutput("Amazon.Appflow.Model.ConnectorConfiguration or Amazon.Appflow.Model.DescribeConnectorResponse",
        "This cmdlet returns an Amazon.Appflow.Model.ConnectorConfiguration object.",
        "The service call response (type Amazon.Appflow.Model.DescribeConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAFConnectorCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorLabel
        /// <summary>
        /// <para>
        /// <para>The label of the connector. The label is unique for each <c>ConnectorRegistration</c>
        /// in your Amazon Web Services account. Only needed if calling for CUSTOMCONNECTOR connector
        /// type/.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorLabel { get; set; }
        #endregion
        
        #region Parameter ConnectorType
        /// <summary>
        /// <para>
        /// <para>The connector type, such as CUSTOMCONNECTOR, Saleforce, Marketo. Please choose CUSTOMCONNECTOR
        /// for Lambda based custom connectors.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Appflow.ConnectorType")]
        public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.DescribeConnectorResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.DescribeConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorConfiguration";
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
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.DescribeConnectorResponse, GetAFConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorLabel = this.ConnectorLabel;
            context.ConnectorType = this.ConnectorType;
            #if MODULAR
            if (this.ConnectorType == null && ParameterWasBound(nameof(this.ConnectorType)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Appflow.Model.DescribeConnectorRequest();
            
            if (cmdletContext.ConnectorLabel != null)
            {
                request.ConnectorLabel = cmdletContext.ConnectorLabel;
            }
            if (cmdletContext.ConnectorType != null)
            {
                request.ConnectorType = cmdletContext.ConnectorType;
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
        
        private Amazon.Appflow.Model.DescribeConnectorResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.DescribeConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "DescribeConnector");
            try
            {
                return client.DescribeConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorLabel { get; set; }
            public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
            public System.Func<Amazon.Appflow.Model.DescribeConnectorResponse, GetAFConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorConfiguration;
        }
        
    }
}
