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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a certificate provider.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateCertificateProvider</a>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTCertificateProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateCertificateProviderResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateCertificateProvider API operation.", Operation = new[] {"UpdateCertificateProvider"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateCertificateProviderResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateCertificateProviderResponse",
        "This cmdlet returns an Amazon.IoT.Model.UpdateCertificateProviderResponse object containing multiple properties."
    )]
    public partial class UpdateIOTCertificateProviderCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountDefaultForOperation
        /// <summary>
        /// <para>
        /// <para>A list of the operations that the certificate provider will use to generate certificates.
        /// Valid value: <c>CreateCertificateFromCsr</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountDefaultForOperations")]
        public System.String[] AccountDefaultForOperation { get; set; }
        #endregion
        
        #region Parameter CertificateProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the certificate provider.</para>
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
        public System.String CertificateProviderName { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The Lambda function ARN that's associated with the certificate provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateCertificateProviderResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateCertificateProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTCertificateProvider (UpdateCertificateProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateCertificateProviderResponse, UpdateIOTCertificateProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountDefaultForOperation != null)
            {
                context.AccountDefaultForOperation = new List<System.String>(this.AccountDefaultForOperation);
            }
            context.CertificateProviderName = this.CertificateProviderName;
            #if MODULAR
            if (this.CertificateProviderName == null && ParameterWasBound(nameof(this.CertificateProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LambdaFunctionArn = this.LambdaFunctionArn;
            
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
            var request = new Amazon.IoT.Model.UpdateCertificateProviderRequest();
            
            if (cmdletContext.AccountDefaultForOperation != null)
            {
                request.AccountDefaultForOperations = cmdletContext.AccountDefaultForOperation;
            }
            if (cmdletContext.CertificateProviderName != null)
            {
                request.CertificateProviderName = cmdletContext.CertificateProviderName;
            }
            if (cmdletContext.LambdaFunctionArn != null)
            {
                request.LambdaFunctionArn = cmdletContext.LambdaFunctionArn;
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
        
        private Amazon.IoT.Model.UpdateCertificateProviderResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateCertificateProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateCertificateProvider");
            try
            {
                #if DESKTOP
                return client.UpdateCertificateProvider(request);
                #elif CORECLR
                return client.UpdateCertificateProviderAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountDefaultForOperation { get; set; }
            public System.String CertificateProviderName { get; set; }
            public System.String LambdaFunctionArn { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateCertificateProviderResponse, UpdateIOTCertificateProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
