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
    /// Provides details regarding the entity used with the connector, with a description
    /// of the data model for each field in that entity.
    /// </summary>
    [Cmdlet("Get", "AFConnectorEntity")]
    [OutputType("Amazon.Appflow.Model.ConnectorEntityField")]
    [AWSCmdlet("Calls the Amazon Appflow DescribeConnectorEntity API operation.", Operation = new[] {"DescribeConnectorEntity"}, SelectReturnType = typeof(Amazon.Appflow.Model.DescribeConnectorEntityResponse))]
    [AWSCmdletOutput("Amazon.Appflow.Model.ConnectorEntityField or Amazon.Appflow.Model.DescribeConnectorEntityResponse",
        "This cmdlet returns a collection of Amazon.Appflow.Model.ConnectorEntityField objects.",
        "The service call response (type Amazon.Appflow.Model.DescribeConnectorEntityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAFConnectorEntityCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiVersion
        /// <summary>
        /// <para>
        /// <para>The version of the API that's used by the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiVersion { get; set; }
        #endregion
        
        #region Parameter ConnectorEntityName
        /// <summary>
        /// <para>
        /// <para> The entity name for that connector. </para>
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
        public System.String ConnectorEntityName { get; set; }
        #endregion
        
        #region Parameter ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para> The name of the connector profile. The name is unique for each <c>ConnectorProfile</c>
        /// in the Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter ConnectorType
        /// <summary>
        /// <para>
        /// <para> The type of connector application, such as Salesforce, Amplitude, and so on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Appflow.ConnectorType")]
        public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorEntityFields'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.DescribeConnectorEntityResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.DescribeConnectorEntityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorEntityFields";
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
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.DescribeConnectorEntityResponse, GetAFConnectorEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiVersion = this.ApiVersion;
            context.ConnectorEntityName = this.ConnectorEntityName;
            #if MODULAR
            if (this.ConnectorEntityName == null && ParameterWasBound(nameof(this.ConnectorEntityName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorEntityName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectorProfileName = this.ConnectorProfileName;
            context.ConnectorType = this.ConnectorType;
            
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
            var request = new Amazon.Appflow.Model.DescribeConnectorEntityRequest();
            
            if (cmdletContext.ApiVersion != null)
            {
                request.ApiVersion = cmdletContext.ApiVersion;
            }
            if (cmdletContext.ConnectorEntityName != null)
            {
                request.ConnectorEntityName = cmdletContext.ConnectorEntityName;
            }
            if (cmdletContext.ConnectorProfileName != null)
            {
                request.ConnectorProfileName = cmdletContext.ConnectorProfileName;
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
        
        private Amazon.Appflow.Model.DescribeConnectorEntityResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.DescribeConnectorEntityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "DescribeConnectorEntity");
            try
            {
                return client.DescribeConnectorEntityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiVersion { get; set; }
            public System.String ConnectorEntityName { get; set; }
            public System.String ConnectorProfileName { get; set; }
            public Amazon.Appflow.ConnectorType ConnectorType { get; set; }
            public System.Func<Amazon.Appflow.Model.DescribeConnectorEntityResponse, GetAFConnectorEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorEntityFields;
        }
        
    }
}
