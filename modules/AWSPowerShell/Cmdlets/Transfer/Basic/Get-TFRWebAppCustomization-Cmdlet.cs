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
using Amazon.Transfer;
using Amazon.Transfer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Describes the web app customization object that's identified by <c>WebAppId</c>.
    /// </summary>
    [Cmdlet("Get", "TFRWebAppCustomization")]
    [OutputType("Amazon.Transfer.Model.DescribedWebAppCustomization")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP DescribeWebAppCustomization API operation.", Operation = new[] {"DescribeWebAppCustomization"}, SelectReturnType = typeof(Amazon.Transfer.Model.DescribeWebAppCustomizationResponse))]
    [AWSCmdletOutput("Amazon.Transfer.Model.DescribedWebAppCustomization or Amazon.Transfer.Model.DescribeWebAppCustomizationResponse",
        "This cmdlet returns an Amazon.Transfer.Model.DescribedWebAppCustomization object.",
        "The service call response (type Amazon.Transfer.Model.DescribeWebAppCustomizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTFRWebAppCustomizationCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WebAppId
        /// <summary>
        /// <para>
        /// <para>Provide the unique identifier for the web app.</para>
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
        public System.String WebAppId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WebAppCustomization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.DescribeWebAppCustomizationResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.DescribeWebAppCustomizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WebAppCustomization";
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
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.DescribeWebAppCustomizationResponse, GetTFRWebAppCustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.WebAppId = this.WebAppId;
            #if MODULAR
            if (this.WebAppId == null && ParameterWasBound(nameof(this.WebAppId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebAppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.DescribeWebAppCustomizationRequest();
            
            if (cmdletContext.WebAppId != null)
            {
                request.WebAppId = cmdletContext.WebAppId;
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
        
        private Amazon.Transfer.Model.DescribeWebAppCustomizationResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.DescribeWebAppCustomizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "DescribeWebAppCustomization");
            try
            {
                return client.DescribeWebAppCustomizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String WebAppId { get; set; }
            public System.Func<Amazon.Transfer.Model.DescribeWebAppCustomizationResponse, GetTFRWebAppCustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WebAppCustomization;
        }
        
    }
}
