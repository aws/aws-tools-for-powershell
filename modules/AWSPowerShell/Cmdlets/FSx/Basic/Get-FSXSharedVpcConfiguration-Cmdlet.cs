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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Indicates whether participant accounts in your organization can create Amazon FSx
    /// for NetApp ONTAP Multi-AZ file systems in subnets that are shared by a virtual private
    /// cloud (VPC) owner. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/creating-file-systems.html#fsxn-vpc-shared-subnets">Creating
    /// FSx for ONTAP file systems in shared subnets</a>.
    /// </summary>
    [Cmdlet("Get", "FSXSharedVpcConfiguration")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon FSx DescribeSharedVpcConfiguration API operation.", Operation = new[] {"DescribeSharedVpcConfiguration"}, SelectReturnType = typeof(Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetFSXSharedVpcConfigurationCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnableFsxRouteTableUpdatesFromParticipantAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnableFsxRouteTableUpdatesFromParticipantAccounts";
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
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse, GetFSXSharedVpcConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.FSx.Model.DescribeSharedVpcConfigurationRequest();
            
            
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
        
        private Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.DescribeSharedVpcConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "DescribeSharedVpcConfiguration");
            try
            {
                return client.DescribeSharedVpcConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.FSx.Model.DescribeSharedVpcConfigurationResponse, GetFSXSharedVpcConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnableFsxRouteTableUpdatesFromParticipantAccounts;
        }
        
    }
}
