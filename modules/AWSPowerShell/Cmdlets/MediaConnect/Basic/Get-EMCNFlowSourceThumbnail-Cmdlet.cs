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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Displays the thumbnail details of a flow's source stream.
    /// </summary>
    [Cmdlet("Get", "EMCNFlowSourceThumbnail")]
    [OutputType("Amazon.MediaConnect.Model.ThumbnailDetails")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect DescribeFlowSourceThumbnail API operation.", Operation = new[] {"DescribeFlowSourceThumbnail"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.ThumbnailDetails or Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.ThumbnailDetails object.",
        "The service call response (type Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMCNFlowSourceThumbnailCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the flow.
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ThumbnailDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ThumbnailDetails";
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
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse, GetEMCNFlowSourceThumbnailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailRequest();
            
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
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
        
        private Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "DescribeFlowSourceThumbnail");
            try
            {
                #if DESKTOP
                return client.DescribeFlowSourceThumbnail(request);
                #elif CORECLR
                return client.DescribeFlowSourceThumbnailAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowArn { get; set; }
            public System.Func<Amazon.MediaConnect.Model.DescribeFlowSourceThumbnailResponse, GetEMCNFlowSourceThumbnailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ThumbnailDetails;
        }
        
    }
}
