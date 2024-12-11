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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Adds or modifies account-level configurations in ACM. 
    /// 
    ///  
    /// <para>
    /// The supported configuration option is <c>DaysBeforeExpiry</c>. This option specifies
    /// the number of days prior to certificate expiration when ACM starts generating <c>EventBridge</c>
    /// events. ACM sends one event per day per certificate until the certificate expires.
    /// By default, accounts receive events starting 45 days before certificate expiration.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ACMAccountConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager PutAccountConfiguration API operation.", Operation = new[] {"PutAccountConfiguration"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.PutAccountConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.CertificateManager.Model.PutAccountConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CertificateManager.Model.PutAccountConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteACMAccountConfigurationCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExpiryEvents_DaysBeforeExpiry
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days prior to certificate expiration when ACM starts generating
        /// <c>EventBridge</c> events. ACM sends one event per day per certificate until the certificate
        /// expires. By default, accounts receive events starting 45 days before certificate expiration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ExpiryEvents_DaysBeforeExpiry { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Customer-chosen string used to distinguish between calls to <c>PutAccountConfiguration</c>.
        /// Idempotency tokens time out after one hour. If you call <c>PutAccountConfiguration</c>
        /// multiple times with the same unexpired idempotency token, ACM treats it as the same
        /// request and returns the original result. If you change the idempotency token for each
        /// call, ACM treats each call as a new request.</para>
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
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.PutAccountConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdempotencyToken), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ACMAccountConfiguration (PutAccountConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.PutAccountConfigurationResponse, WriteACMAccountConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpiryEvents_DaysBeforeExpiry = this.ExpiryEvents_DaysBeforeExpiry;
            context.IdempotencyToken = this.IdempotencyToken;
            #if MODULAR
            if (this.IdempotencyToken == null && ParameterWasBound(nameof(this.IdempotencyToken)))
            {
                WriteWarning("You are passing $null as a value for parameter IdempotencyToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CertificateManager.Model.PutAccountConfigurationRequest();
            
            
             // populate ExpiryEvents
            var requestExpiryEventsIsNull = true;
            request.ExpiryEvents = new Amazon.CertificateManager.Model.ExpiryEventsConfiguration();
            System.Int32? requestExpiryEvents_expiryEvents_DaysBeforeExpiry = null;
            if (cmdletContext.ExpiryEvents_DaysBeforeExpiry != null)
            {
                requestExpiryEvents_expiryEvents_DaysBeforeExpiry = cmdletContext.ExpiryEvents_DaysBeforeExpiry.Value;
            }
            if (requestExpiryEvents_expiryEvents_DaysBeforeExpiry != null)
            {
                request.ExpiryEvents.DaysBeforeExpiry = requestExpiryEvents_expiryEvents_DaysBeforeExpiry.Value;
                requestExpiryEventsIsNull = false;
            }
             // determine if request.ExpiryEvents should be set to null
            if (requestExpiryEventsIsNull)
            {
                request.ExpiryEvents = null;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
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
        
        private Amazon.CertificateManager.Model.PutAccountConfigurationResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.PutAccountConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "PutAccountConfiguration");
            try
            {
                #if DESKTOP
                return client.PutAccountConfiguration(request);
                #elif CORECLR
                return client.PutAccountConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ExpiryEvents_DaysBeforeExpiry { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.Func<Amazon.CertificateManager.Model.PutAccountConfigurationResponse, WriteACMAccountConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
