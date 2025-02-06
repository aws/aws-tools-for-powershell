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
using Amazon.ServiceQuotas;
using Amazon.ServiceQuotas.Model;

namespace Amazon.PowerShell.Cmdlets.SQ
{
    /// <summary>
    /// Retrieves information about the specified quota increase request.
    /// </summary>
    [Cmdlet("Get", "SQRequestedServiceQuotaChange")]
    [OutputType("Amazon.ServiceQuotas.Model.RequestedServiceQuotaChange")]
    [AWSCmdlet("Calls the AWS Service Quotas GetRequestedServiceQuotaChange API operation.", Operation = new[] {"GetRequestedServiceQuotaChange"}, SelectReturnType = typeof(Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse))]
    [AWSCmdletOutput("Amazon.ServiceQuotas.Model.RequestedServiceQuotaChange or Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse",
        "This cmdlet returns an Amazon.ServiceQuotas.Model.RequestedServiceQuotaChange object.",
        "The service call response (type Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSQRequestedServiceQuotaChangeCmdlet : AmazonServiceQuotasClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the quota increase request.</para>
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
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestedQuota'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse).
        /// Specifying the name of a property of type Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestedQuota";
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
                context.Select = CreateSelectDelegate<Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse, GetSQRequestedServiceQuotaChangeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RequestId = this.RequestId;
            #if MODULAR
            if (this.RequestId == null && ParameterWasBound(nameof(this.RequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeRequest();
            
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
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
        
        private Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse CallAWSServiceOperation(IAmazonServiceQuotas client, Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Quotas", "GetRequestedServiceQuotaChange");
            try
            {
                #if DESKTOP
                return client.GetRequestedServiceQuotaChange(request);
                #elif CORECLR
                return client.GetRequestedServiceQuotaChangeAsync(request).GetAwaiter().GetResult();
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
            public System.String RequestId { get; set; }
            public System.Func<Amazon.ServiceQuotas.Model.GetRequestedServiceQuotaChangeResponse, GetSQRequestedServiceQuotaChangeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestedQuota;
        }
        
    }
}
