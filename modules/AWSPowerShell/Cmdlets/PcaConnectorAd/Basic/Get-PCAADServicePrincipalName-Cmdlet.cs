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
using Amazon.PcaConnectorAd;
using Amazon.PcaConnectorAd.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCAAD
{
    /// <summary>
    /// Lists the service principal name that the connector uses to authenticate with Active
    /// Directory.
    /// </summary>
    [Cmdlet("Get", "PCAADServicePrincipalName")]
    [OutputType("Amazon.PcaConnectorAd.Model.ServicePrincipalName")]
    [AWSCmdlet("Calls the Pca Connector Ad GetServicePrincipalName API operation.", Operation = new[] {"GetServicePrincipalName"}, SelectReturnType = typeof(Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse))]
    [AWSCmdletOutput("Amazon.PcaConnectorAd.Model.ServicePrincipalName or Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse",
        "This cmdlet returns an Amazon.PcaConnectorAd.Model.ServicePrincipalName object.",
        "The service call response (type Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCAADServicePrincipalNameCmdlet : AmazonPcaConnectorAdClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateConnector.html">CreateConnector</a>.</para>
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
        public System.String ConnectorArn { get; set; }
        #endregion
        
        #region Parameter DirectoryRegistrationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateDirectoryRegistration.html">CreateDirectoryRegistration</a>.</para>
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
        public System.String DirectoryRegistrationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServicePrincipalName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse).
        /// Specifying the name of a property of type Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServicePrincipalName";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse, GetPCAADServicePrincipalNameCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorArn = this.ConnectorArn;
            #if MODULAR
            if (this.ConnectorArn == null && ParameterWasBound(nameof(this.ConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DirectoryRegistrationArn = this.DirectoryRegistrationArn;
            #if MODULAR
            if (this.DirectoryRegistrationArn == null && ParameterWasBound(nameof(this.DirectoryRegistrationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryRegistrationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PcaConnectorAd.Model.GetServicePrincipalNameRequest();
            
            if (cmdletContext.ConnectorArn != null)
            {
                request.ConnectorArn = cmdletContext.ConnectorArn;
            }
            if (cmdletContext.DirectoryRegistrationArn != null)
            {
                request.DirectoryRegistrationArn = cmdletContext.DirectoryRegistrationArn;
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
        
        private Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse CallAWSServiceOperation(IAmazonPcaConnectorAd client, Amazon.PcaConnectorAd.Model.GetServicePrincipalNameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Pca Connector Ad", "GetServicePrincipalName");
            try
            {
                return client.GetServicePrincipalNameAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorArn { get; set; }
            public System.String DirectoryRegistrationArn { get; set; }
            public System.Func<Amazon.PcaConnectorAd.Model.GetServicePrincipalNameResponse, GetPCAADServicePrincipalNameCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServicePrincipalName;
        }
        
    }
}
