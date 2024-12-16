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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Gets the details of a network operation, including the tasks involved in the network
    /// operation and the status of the tasks.
    /// 
    ///  
    /// <para>
    /// A network operation is any operation that is done to your network, such as network
    /// instance instantiation or termination.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TNBSolNetworkOperation")]
    [OutputType("Amazon.Tnb.Model.GetSolNetworkOperationResponse")]
    [AWSCmdlet("Calls the AWS Telco Network Builder GetSolNetworkOperation API operation.", Operation = new[] {"GetSolNetworkOperation"}, SelectReturnType = typeof(Amazon.Tnb.Model.GetSolNetworkOperationResponse))]
    [AWSCmdletOutput("Amazon.Tnb.Model.GetSolNetworkOperationResponse",
        "This cmdlet returns an Amazon.Tnb.Model.GetSolNetworkOperationResponse object containing multiple properties."
    )]
    public partial class GetTNBSolNetworkOperationCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NsLcmOpOccId
        /// <summary>
        /// <para>
        /// <para>The identifier of the network operation.</para>
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
        public System.String NsLcmOpOccId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.GetSolNetworkOperationResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.GetSolNetworkOperationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.GetSolNetworkOperationResponse, GetTNBSolNetworkOperationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NsLcmOpOccId = this.NsLcmOpOccId;
            #if MODULAR
            if (this.NsLcmOpOccId == null && ParameterWasBound(nameof(this.NsLcmOpOccId)))
            {
                WriteWarning("You are passing $null as a value for parameter NsLcmOpOccId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Tnb.Model.GetSolNetworkOperationRequest();
            
            if (cmdletContext.NsLcmOpOccId != null)
            {
                request.NsLcmOpOccId = cmdletContext.NsLcmOpOccId;
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
        
        private Amazon.Tnb.Model.GetSolNetworkOperationResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.GetSolNetworkOperationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "GetSolNetworkOperation");
            try
            {
                #if DESKTOP
                return client.GetSolNetworkOperation(request);
                #elif CORECLR
                return client.GetSolNetworkOperationAsync(request).GetAwaiter().GetResult();
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
            public System.String NsLcmOpOccId { get; set; }
            public System.Func<Amazon.Tnb.Model.GetSolNetworkOperationResponse, GetTNBSolNetworkOperationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
