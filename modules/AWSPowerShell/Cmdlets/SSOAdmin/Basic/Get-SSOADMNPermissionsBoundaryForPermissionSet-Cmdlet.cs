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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Obtains the permissions boundary for a specified <a>PermissionSet</a>.
    /// </summary>
    [Cmdlet("Get", "SSOADMNPermissionsBoundaryForPermissionSet")]
    [OutputType("Amazon.SSOAdmin.Model.PermissionsBoundary")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin GetPermissionsBoundaryForPermissionSet API operation.", Operation = new[] {"GetPermissionsBoundaryForPermissionSet"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse))]
    [AWSCmdletOutput("Amazon.SSOAdmin.Model.PermissionsBoundary or Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse",
        "This cmdlet returns an Amazon.SSOAdmin.Model.PermissionsBoundary object.",
        "The service call response (type Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSOADMNPermissionsBoundaryForPermissionSetCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Identity Center instance under which the operation will be executed.
        /// </para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter PermissionSetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>PermissionSet</c>.</para>
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
        public System.String PermissionSetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PermissionsBoundary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PermissionsBoundary";
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
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse, GetSSOADMNPermissionsBoundaryForPermissionSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionSetArn = this.PermissionSetArn;
            #if MODULAR
            if (this.PermissionSetArn == null && ParameterWasBound(nameof(this.PermissionSetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionSetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetRequest();
            
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.PermissionSetArn != null)
            {
                request.PermissionSetArn = cmdletContext.PermissionSetArn;
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
        
        private Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "GetPermissionsBoundaryForPermissionSet");
            try
            {
                return client.GetPermissionsBoundaryForPermissionSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceArn { get; set; }
            public System.String PermissionSetArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.GetPermissionsBoundaryForPermissionSetResponse, GetSSOADMNPermissionsBoundaryForPermissionSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PermissionsBoundary;
        }
        
    }
}
